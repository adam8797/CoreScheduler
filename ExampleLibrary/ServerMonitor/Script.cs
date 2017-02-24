//css_ref System.Data;
//css_ref System.Management;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Management;
using CoreScheduler.Api;

namespace CoreScheduler.Jobs.Example.ServerMonitor
{
    public class Script : MarshalByRefObject, IRunnable
    {
        //Tables in the database
        //Metrics is where the disk information is stored
        private const string MetricsTable = "server_monitor_metrics";

        //Servers table contains a single nvarchar(50) column holding server hostnames
        private const string ServersTable = "server_monitor_servers";

        public void Main(IContext ctx)
        {
            var watch = Stopwatch.StartNew();

            //Prepare the database interface
            var db = new SqlInterface(ctx.ConnectionStrings[0], ctx, MetricsTable, ServersTable);

            //For each target server
            foreach (var server in db.TargetedServers())
            {
                //Load the credential from the database context
                var wmiCred = (IDomainCredential)ctx.Credentials[0];

                //Open a WMI connection, and retrieve the capture information
                var wmi = new ServerInterface(server, wmiCred, ctx);
                var captures = wmi.Capture();

                //Add each capture to the database
                foreach (var capture in captures)
                {
                    db.SaveCapture(capture);
                }
            }
            watch.Stop();
            ctx.Events.Add(EventLevel.Success, "Process completed in {0}ms", watch.ElapsedMilliseconds);
        }
    }

    /// <summary>
    /// Facilitates WMI communication from each target server.
    /// </summary>
    public class ServerInterface
    {
        private readonly string _hostname;
        private readonly IDomainCredential _credential;
        private readonly IContext _ctx;

        public ServerInterface(string hostname, IDomainCredential credential, IContext ctx)
        {
            _hostname = hostname;
            _credential = credential;
            _ctx = ctx;
        }

        /// <summary>
        /// Capture the current state of the disks on the remote server
        /// </summary>
        /// <returns>A list of disk captures</returns>
        public List<Capture> Capture()
        {
            Console.WriteLine("Attempting to retrieve disk information from " + _hostname);
            var watch = Stopwatch.StartNew();

            var options = new ConnectionOptions()
            {
                Username = _credential.Username,
                Password = _credential.Password,
                Authority = "NTLMDOMAIN:" + _credential.Domain,
            };

            if (string.IsNullOrEmpty(_hostname.Trim()))
                return new List<Capture>();

            //This path is specified by the WMI documentation. Do not change
            var scopePath = string.Format("\\\\{0}\\root\\cimv2", _hostname.Trim());

            var scope = new ManagementScope(scopePath, options);

            try
            {
                scope.Connect();
            }
            catch (Exception ex)
            {
                _ctx.Events.Add(EventLevel.Error, "Exception thrown while connecting to " + _hostname);
                //Console.WriteLine(ex);

                //Dont crash the program, just continue
                return new List<Capture>();
            }

            //Query only selects disks. Multiple queries would have to be used to expand this tool.
            var query = new ObjectQuery("SELECT * FROM Win32_LogicalDisk");
            var searcher = new ManagementObjectSearcher(scope, query);

            //Run the query
            //May hang here. WMI can be slow
            var disks = searcher.Get().Cast<ManagementBaseObject>();

            var captures = new List<Capture>();

            foreach (var v in disks)
            {
                //Simplify the data to something we can use.
                var props = v.Properties.Cast<PropertyData>().ToDictionary(y => y.Name, y => y.Value);

                var capture = new Capture()
                {
                    ServerHostname = _hostname,
                    TotalSpace = Convert.ToInt64(props["Size"]),
                    SpaceFree = Convert.ToInt64(props["FreeSpace"])
                };

                if (capture.TotalSpace == 0)
                    continue;

                var name = (string)props["VolumeName"];
                var deviceId = (string)props["DeviceID"];

                //If there is no name, dont include the []
                if (!string.IsNullOrEmpty(name))
                    capture.Drive = string.Format("{0} [{1}]", deviceId, name);
                else
                    capture.Drive = deviceId;

                captures.Add(capture);

            }

            watch.Stop();
            _ctx.Events.Add(EventLevel.Debug, "Finished query to {0} ({1} ms)", _hostname, watch.ElapsedMilliseconds);

            return captures;
        }
    }

    /// <summary>
    /// Facilitates communication to the SQL server, for loading target servers and for saving captured metrics
    /// </summary>
    public class SqlInterface
    {
        private readonly string _metricsTable;
        private readonly string _serversTable;
        private readonly IConnectionString _connectionString;
        private readonly IContext _ctx;
            

        public SqlInterface(IConnectionString connectionString, IContext ctx, string metricsTable, string serversTable)
        {
            _metricsTable = metricsTable;
            _serversTable = serversTable;
            _connectionString = connectionString;
            _ctx = ctx;
        }

        /// <summary>
        /// Saves a retrieved capture to the SQL Database
        /// </summary>
        /// <param name="cap">Capture that was gathered from a server</param>
        public void SaveCapture(Capture cap)
        {
            Console.WriteLine("Saving Capture to DB: " + cap);

            //Open the connection
            using (SqlConnection con = new SqlConnection(_connectionString.Value))
            {
                //Basic INSERT query. The @params are for the SQL client to deal with. It makes sure input is sanitized.
                var query =
                    "INSERT INTO " + _metricsTable + " (ServerHostname, Drive, SpaceFree, TotalSpace, PercentUsed, Timestamp) " +
                    "VALUES (@ServerHostname, @Drive, @SpaceFree, @TotalSpace, @PercentUsed, @Timestamp)";

                //Build the command
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    //Add the unopened connection 
                    cmd.Connection = con;

                    //Add all parameters
                    cmd.Parameters.Add("@ServerHostName", SqlDbType.NVarChar).Value = cap.ServerHostname;
                    cmd.Parameters.Add("@Drive", SqlDbType.NVarChar).Value = cap.Drive;
                    cmd.Parameters.Add("@SpaceFree", SqlDbType.BigInt).Value = cap.SpaceFree;
                    cmd.Parameters.Add("@TotalSpace", SqlDbType.BigInt).Value = cap.TotalSpace;
                    cmd.Parameters.Add("@PercentUsed", SqlDbType.Decimal).Value = cap.PercentUsed;
                    cmd.Parameters.Add("@Timestamp", SqlDbType.DateTime2).Value = DateTime.Now;

                    try
                    {
                        //Open the connection and fire the statement
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        _ctx.Events.Add(EventLevel.Fatal, "Error thrown while saving drive capture\n"+ ex);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Queries the database for a list of servers that are being targeted.
        /// </summary>
        /// <returns>A list of IP addresses or resolvable hostnames</returns>
        public List<string> TargetedServers()
        {
            var servers = new List<string>();

            Console.WriteLine("Loading servers from DB...");

            //setup the connection
            using (SqlConnection con = new SqlConnection(_connectionString.Value))
            {
                //super simple query
                var query = "SELECT * FROM " + _serversTable;

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    //Set the connection, and run the query
                    cmd.Connection = con;
                    try
                    {
                        con.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            servers.Add(reader.GetString(0));
                        }
                    }
                    catch (SqlException ex)
                    {
                        _ctx.Events.Add(EventLevel.Fatal, "Error thrown while loading server list\n" + ex);
                        throw;
                    }
                }
            }

            _ctx.Events.Add(EventLevel.Info, "Loaded {0} servers", servers.Count);

            return servers;
        }

    }

    /// <summary>
    /// Struct used to represent a snapshot of the disks on a targeted server.
    /// </summary>
    public struct Capture
    {
        public string ServerHostname { get; set; }
        public string Drive { get; set; }
        public long SpaceFree { get; set; }
        public long TotalSpace { get; set; }

        public decimal PercentUsed
        {
            //get { return (decimal) SpaceFree/TotalSpace; } //Percent Free
            get { return 1 - (decimal)SpaceFree / TotalSpace; } //Percent Used
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} => {2}KB / {3}KB ({4:P} Used)", ServerHostname, Drive, SpaceFree / 1000, TotalSpace / 1000,
            PercentUsed);
        }
    }
}

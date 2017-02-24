import sys
import clr
clr.AddReference("System.Data")
clr.AddReference("System.Management")
import System
clr.ImportExtensions(System.Linq)
from CoreScheduler.Api import EventLevel
from System.Diagnostics import Stopwatch
from System.Data.SqlClient import SqlConnection
from System.Data.SqlClient import SqlCommand
from System.Data import SqlDbType
from System import DateTime
from System import Convert
from System.Management import ConnectionOptions
from System.Management import ManagementScope
from System.Management import ObjectQuery
from System.Management import ManagementObjectSearcher
from System.Management import PropertyData


metricsTable = "server_monitor_metrics"
serversTable = "server_monitor_servers"


def main():
    print "main()"
    db = SqlInterface(ctx.ConnectionStrings[0])
    watch = Stopwatch()
    watch.Start()
    for server in db.targetedServers():
        wmi = ServerInterface(ctx.Credentials[0], server)

        captures = wmi.capture()

        for capture in captures:
            db.saveCapture(capture)
    watch.Stop()
    ctx.Events.Add(EventLevel.Success, "Process completed in {0}ms", watch.ElapsedMilliseconds)

class ServerInterface(object):
    _cred = None
    _hostname = None

    def __init__(self, cred, host):
        print "ServerInterface()"
        self._cred = cred
        self._hostname = host

    def capture(self):
        print "ServerInterface.capture()"

        options = ConnectionOptions()
        options.Username = self._cred.Username
        options.Password = self._cred.Password
        options.Authority = "NTLMDOMAIN:" + self._cred.Domain

        if not self._hostname.strip():
            return []

        scopePath = "\\\\{}\\root\cimv2".format(self._hostname.strip())

        scope = ManagementScope(scopePath, options)

        try:
            scope.Connect()
        except Exception:
            ctx.Events.Add(EventLevel.Error, "Exception thrown while connecting to " + self._hostname)
            return []
        
        query = ObjectQuery("SELECT * FROM Win32_LogicalDisk")
        searcher = ManagementObjectSearcher(scope, query)

        disks = searcher.Get()

        captures = []

        for v in disks:

            propData = v.Properties.Cast[PropertyData]()
            
            props = {}
            
            for prop in propData:
                props[prop.Name] = prop.Value
             

            capture = Capture(self._hostname, "", Convert.ToInt64(props["FreeSpace"]), Convert.ToInt64(props["Size"]))

            if capture.TotalSpace == 0:
                continue

            name = props["VolumeName"]
            deviceId = props["DeviceID"]

            if not name:
                capture.Drive = "{} [{}]".format(deviceId, name)
            else:
                capture.Drive = deviceId

            captures.append(capture)
        
        return captures

class SqlInterface(object):
    _connectionString = None

    def __init__(self, connectionString):
        print "SqlInterface()"
        self._connectionString = connectionString

    def targetedServers(self):
        print "SqlInterface.targetedServers()"
        servers = []

        with SqlConnection(self._connectionString.Value) as con:
            query = "SELECT * FROM " + serversTable

            with SqlCommand(query) as cmd:
                cmd.Connection = con

                try:
                    con.Open()
                    reader = cmd.ExecuteReader()
                    while (reader.Read()):
                        servers.append(reader.GetString(0))
                except Exception:
                    ctx.Events.Add(EventLevel.Error, "Exception thrown while trying to load servers")

        ctx.Events.Add(EventLevel.Info, "Loaded {0} servers", len(servers))
        return servers

    def saveCapture(self, cap):
        print "SqlInterface.saveCapture()"
        with SqlConnection(self._connectionString.Value) as con:
            query = "INSERT INTO " + metricsTable + " (ServerHostname, Drive, SpaceFree, TotalSpace, PercentUsed, Timestamp) VALUES (@ServerHostname, @Drive, @SpaceFree, @TotalSpace, @PercentUsed, @Timestamp)"
            with SqlCommand(query) as cmd:
                cmd.Connection = con

                cmd.Parameters.Add("@ServerHostName", SqlDbType.NVarChar).Value = cap.ServerHostname
                cmd.Parameters.Add("@Drive", SqlDbType.NVarChar).Value = cap.Drive
                cmd.Parameters.Add("@SpaceFree", SqlDbType.BigInt).Value = cap.SpaceFree
                cmd.Parameters.Add("@TotalSpace", SqlDbType.BigInt).Value = cap.TotalSpace
                cmd.Parameters.Add("@PercentUsed", SqlDbType.Decimal).Value = cap.percentUsed()
                cmd.Parameters.Add("@Timestamp", SqlDbType.DateTime2).Value = DateTime.Now

                try:
                    con.Open()
                    cmd.ExecuteNonQuery()
                except Exception:
                    ctx.Events.Add(EventLevel.Error, "Exception thrown while trying to save capture")


class Capture(object):
    ServerHostname = ""
    Drive = ""
    SpaceFree = 0
    TotalSpace = 0

    def __init__(self, serverHostname, drive, spaceFree, totalSpace):
        print "Capture()"
        self.Drive = drive
        self.ServerHostname = serverHostname
        self.SpaceFree = spaceFree
        self.TotalSpace = totalSpace

    def percentUsed(self):
        print "Capture.percentUsed"
        return 1 - (self.SpaceFree/self.TotalSpace)


main()


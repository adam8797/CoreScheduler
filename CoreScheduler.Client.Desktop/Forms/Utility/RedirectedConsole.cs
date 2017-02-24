using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CoreScheduler.Client.Desktop.Base;

namespace CoreScheduler.Client.Desktop.Forms
{
    public partial class RedirectedConsole : FormBase
    {
        private readonly int _port;
        private readonly string _sessionId;
        private TcpListener _server;
        private Thread _listener;


        public RedirectedConsole(int port, string sessionId)
        {
            _port = port;
            _sessionId = sessionId;
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _loopRunning = false;
            _server.Stop();
        }

        protected override void OnLoad(EventArgs e)
        {
            _listener = new Thread(ListenerThread);
            _listener.Start();

            Text += " - ID: " + _sessionId;
            txtConsole.AppendText("Awaiting connection from server...\n");
        }

        private volatile bool _loopRunning = true;

        private void ListenerThread()
        {
            try
            {
                // Set the TcpListener on port 13000.
                var port = _port;
                var localAddr = IPAddress.Parse(GetLocalIpAddress());

                // TcpListener server = new TcpListener(port);
                _server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                _server.Start();

                // Buffer for reading data
                var bytes = new byte[256];

                // Enter the listening loop.
                while (_loopRunning)
                {
                    if (!_server.Pending())
                    {
                        Thread.Sleep(100);
                        continue;
                    }

                    var client = _server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    // Get a stream object for reading and writing
                    var stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        var data = Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        if (data.Contains("__CORE_END_STREAM__"))
                        {
                            txtConsole.BeginInvoke(new Action(() =>
                            {
                                MessageBox.Show("Process finished at " + DateTime.Now.ToString("G"));
                                txtConsole.AppendText("======= Process Finished =======");
                                txtConsole.ScrollToCaret();
                            }));
                            break;
                        }
                        txtConsole.BeginInvoke(new Action(() =>
                        {
                            txtConsole.AppendText(data);
                            txtConsole.ScrollToCaret();
                        }));
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // Stop listening for new clients.
                _server.Stop();
                UsedPorts.Remove(((IPEndPoint) _server.LocalEndpoint).Port);
            }

        }

        private static readonly List<int> UsedPorts = new List<int>();

        public static int ReservePort()
        {
            int startPort = 8899;
            while (UsedPorts.Contains(startPort))
            {
                startPort++;
            }
            UsedPorts.Add(startPort);
            return startPort;
        }

        public static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}

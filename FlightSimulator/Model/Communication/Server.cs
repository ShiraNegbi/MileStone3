using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Communication
{
    public class Server
    {

        //holding the instance of the SINGLETON model in a member for readability
        private ApplicationSettingsModel settingsModelInstance;

        private ServerConnectivityInfo info;

        private TcpClient client;
        private TcpListener listener;

        //a singleton - a single instance of the server
        private static Server singletonServer = null;
        //a property for getting the server instance from the class
        public static Server Instance 
        {
            get 
            {
                if(singletonServer == null)
                {
                   Server.singletonServer = new Server();
                }
                return singletonServer;
            }
        }
        private Server()
        {
        }
        public delegate void ValuesUpdated(string[] values);
        public event ValuesUpdated ServerValuesUpdated;

        // Send info about the current state of the airplane from the sever to the client
        public void Connect()
        {
            string serverIP = settingsModelInstance.FlightServerIP;
            int serverPort = settingsModelInstance.FlightInfoPort; //???? which is which
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
            TcpListener listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("Waiting for client connections...");
            this.client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");
        }
        public void StartReadingData()
        {
            while (!info.Stop)
            {
                using (NetworkStream stream = client.GetStream())
                {
                    StreamReader r = new StreamReader(stream);

                    string data = r.ReadLine();
                    string[] values = data.Split(',');
                    ServerValuesUpdated?.Invoke(values);

                }
                client.Close();
                listener.Stop();
            }
        }

        public void Disconnect()
        {
            client.Close();
            listener.Stop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Communication
{
    public class Client
    {
        //a singleton - a single instance of the client
        private static Client singletonClient = null;
        private TcpClient client;
        //a property for getting the server instance from the class
        public static Client Instance
        {
            get
            {
                if (singletonClient == null)
                {
                    Client.singletonClient = new Client();
                }
                return singletonClient;
            }
        }
        private Client() { }

        public bool IsConnect { get; set; }
        public void Connect()
        {
            this.IsConnect = true;
            string flightServerIp = ApplicationSettingsModel.Instance.FlightServerIP;
            int flightCommandPort = ApplicationSettingsModel.Instance.FlightCommandPort;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(flightServerIp), flightCommandPort);
            client = new TcpClient(ep);
            client.Connect(ep);

            Console.WriteLine("You are connected");
        }
        // Send commands to move the airplane
        public void SendCommandToServer(string setContent)
        {
            using (
                NetworkStream stream = client.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
              // Send data to server
                writer.Write(setContent);
            }
           
        }

        public void Disconnect()
        {
            this.IsConnect = false;
            client.Close();

        }
    }
}

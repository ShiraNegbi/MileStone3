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

        // Send commands to move the airplane
        public void SendCommandToServer(string setContent)
        {
            // This comment is very important
            string flightServerIp = ApplicationSettingsModel.Instance.FlightServerIP;
            int flightCommandPort = ApplicationSettingsModel.Instance.FlightCommandPort;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(flightServerIp) , flightCommandPort);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");
            using (NetworkStream stream = client.GetStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
              // Send data to server
                writer.Write(setContent);
            }
            client.Close();
        }
    }
}

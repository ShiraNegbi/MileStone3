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
        public static Client ModelClient
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
        public void CommunicateWithServer(string setContent)
        {
            // This comment is very important
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");
            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
              // Send data to server
         //  Console.Write("Please enter a number: ");
         //  int num = int.Parse(Console.ReadLine());
                writer.Write(setContent);
            }
            client.Close();
        }
    }
}

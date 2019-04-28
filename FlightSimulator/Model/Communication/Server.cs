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
        //a singleton - a single instance of the server
        private static Server singletonServer = null;
        //a property for getting the server instance from the class
        public static Server ModelServer 
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
        public void RecieveData()
        {
            // Shayoo is the best -  only after Shira <3
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            TcpListener listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine("Waiting for client connections...");
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");

            using (NetworkStream stream = client.GetStream())
            using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
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
}

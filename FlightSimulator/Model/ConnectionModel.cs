using FlightSimulator.Model.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ConnectionModel : IConnectionModel
    {

        public void DoConnection()
        {
            #region handleClient
            //if the client is currently connected, disconnect
            if(Client.Instance.IsConnect)
            {
                Client.Instance.Disconnect();
            }

            //Connect the client
            Client.Instance.Connect();
            #endregion

            #region handleServer
            if (Server.Instance.IsConnect)
            {
                Server.Instance.Disconnect();
            }
            Server.Instance.Connect();

        }
        public void Disconnect()
        {
            //Disconnect the client
            Client.Instance.Disconnect();
            //Disconnect the server
            Server.Instance.Disconnect();
        }

    }
}

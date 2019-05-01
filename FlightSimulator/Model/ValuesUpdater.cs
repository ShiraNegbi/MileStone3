using FlightSimulator.Model.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ValuesUpdater
    {
        public const string LON = "Lon";
        public const string LAT = "Lat";
        public ValuesUpdater()
        {
            //Subscribe to when the server updates new data from the flightgear client.
            Server.Instance.ServerValuesUpdated += UpdateValuesToSymbolTable;
        }

        private void UpdateValuesToSymbolTable(string[] values)
        {
            double lon = double.Parse(values[0]);
            double lat = double.Parse(values[1]);

            //Add the Lon and the Lat values to the symbol table
            SymbolTable.Instance.Add(LON, lon);
            SymbolTable.Instance.Add(LAT, lat);
        }
        
    }
}

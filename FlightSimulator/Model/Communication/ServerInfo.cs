using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Communication
{
    class ServerConnectivityInfo
    {
        public bool Connected { get; set; } = false;
        public bool Stop { get; set; } = false;
    }
}

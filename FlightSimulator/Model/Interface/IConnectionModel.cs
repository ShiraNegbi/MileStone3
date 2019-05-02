using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public interface IConnectionModel
    {
        void DoConnection();
        void Disconnect();
    }
}

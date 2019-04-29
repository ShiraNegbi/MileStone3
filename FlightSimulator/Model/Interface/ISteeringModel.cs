using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    class ISteeringModel
    {
        public double Aileron { get; set; }  //The value of Aileron
        public double Elevator { get; set; } //The value of Elevator
        public double Rudder { get; set; }   //The value of Rudder
        public double Throttle { get; set; } //The value of Throttle
    }
}

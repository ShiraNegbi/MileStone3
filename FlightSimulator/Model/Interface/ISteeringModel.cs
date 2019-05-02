using FlightSimulator.Model.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    interface ISteeringModel
    {
        double Aileron { get; set; }  //The value of Aileron
        double Elevator { get; set; } //The value of Elevator
        double Rudder { get; set; }   //The value of Rudder
        double Throttle { get; set; } //The value of Throttle
    }
}

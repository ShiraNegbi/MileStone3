using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FlightSimulator;
using FlightSimulator.Model.Communication;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.Model
{
    public class SteeringModel :ISteeringModel
    { 
        //constant string values to send to server
        private const string AILERON_PATH_SET = "set controls/flight/aileron ";
        private const string ELEVATOR_PATH_SET = "set controls/flight/elevator ";
        private const string RUDDER_PATH_SET = "set controls/flight/rudder ";
        private const string THROTTLE_PATH_Set = "set controls/engines/current-engine/throttle ";

        private double aileron;
        private double elevator;
        private double rudder;
        private double throttle;
        
        
    public double Aileron
        {
            get { return aileron; }
            set
            {
                this.aileron = value;
                string sendValueMsg = AILERON_PATH_SET + value + "\r\n";
                Client.Instance.SendCommandToServer(sendValueMsg);
            }
        }
        public double Elevator
        {
            get { return elevator; }
            set
            {
                this.elevator = value;
                string sendValueMsg = ELEVATOR_PATH_SET + value + "\r\n";
                Client.Instance.SendCommandToServer(sendValueMsg);
            }
        }
        public double Rudder
        {
            get { return rudder; }
            set
            {
                this.rudder = value;
                string sendValueMsg = RUDDER_PATH_SET + value + "\r\n";
                Client.Instance.SendCommandToServer(sendValueMsg);
            }
        }
        public double Throttle
        {
            get { return throttle; }
            set
            {
                this.throttle = value;
                string sendValueMsg = THROTTLE_PATH_Set + value + "\r\n";
                Client.Instance.SendCommandToServer(sendValueMsg);
            }
        }

    }
}
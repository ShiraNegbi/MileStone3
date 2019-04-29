using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels.Windows
{
    class SteeringWindowViewModel : BaseNotify
    {
        private ISteeringModel model;

        public SteeringWindowViewModel(ISteeringModel model)
        {
            this.model = model;
        }

        public double Aileron
        {
            get { return model.Aileron; }
            set
            {
                model.Aileron = value;
                NotifyPropertyChanged("Aileron");
            }
        }

        public double Elevator
        {
            get { return model.Elevator; }
            set
            {
                model.Elevator = value;
                NotifyPropertyChanged("Elevator");
            }
        }

        public double Rudder
        {
            get { return model.Rudder; }
            set
            {
                model.Rudder = value;
                NotifyPropertyChanged("Rudder");
            }
        }
        public double Throttle
        {
            get { return model.Throttle; }
            set
            {
                model.Throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }

    }
}

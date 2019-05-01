using FlightSimulator.Model;
using FlightSimulator.Model.Communication;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

        public FlightBoardViewModel()
        {
            SymbolTable.Instance.PropertyChanged += onDataUpdate;
        }

        public void onDataUpdate(string var)
        {
            if(var=="Lon")
            {
                Lon = SymbolTable.Instance.GetVal("Lon");
            }
            if (var == "Lat")
            {
                Lon = SymbolTable.Instance.GetVal("Lat");
            }
        }
        private double lon;
        private double lat;

        public double Lon
        {
            get
            {
                return lon;
            }
            set
            {
                this.lon = value;
                NotifyPropertyChanged("Lon");
            }
        }
        public double Lat
        {
            get { return lat; }
            set
            {
                this.lat = value;
                NotifyPropertyChanged("Lat");
            }
        }
    }
}

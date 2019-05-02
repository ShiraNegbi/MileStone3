using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels.Windows
{
    class FlightButtonsViewModel
    {
        private IConnectionModel model;
        public FlightButtonsViewModel(IConnectionModel model)
        {
            this.model = model;
        }
        

        #region ClickCommand
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            model.SaveSettings();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LedControlApp.Controllers;
using LedControlApp.Helpers;
using Xamarin.Forms;

namespace LedControlApp.ViewModels
{
    public class LedControllerPageViewModel:ViewModelBase
    {
        private Timer _timer;
        private LedController _ledController;

        public byte LedIntensity { get; set; } = 0;
        public string Log { get; set; } = "log";
        public Command ConnectCommand { get; set; }
        public LedControllerPageViewModel(LedController controller)
        {
            _ledController = controller;
            ConnectCommand = new Command(ConnectCommandExecute);
            
        }

        private async void ConnectCommandExecute()
        {
            try
            {

                var isConnected = false;
                while (!isConnected)
                {
                    isConnected = await _ledController.FindAndConnectToDevice();
                }

                _timer = new Timer(null, TimeSpan.FromMilliseconds(100), WriteValueTo);
                _timer.StartTimer();
            }
            catch (AggregateException ex)
            {

                var fEx = ex.Flatten();
                foreach (var e in fEx.InnerExceptions)
                {
                    throw e;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task WriteValueTo(object state)
        {
            await _ledController.SetLedValue(LedIntensity);
        }

    }
}

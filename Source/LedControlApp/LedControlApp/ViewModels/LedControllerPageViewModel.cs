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
        private byte _ledIntensity = 0;
        public byte LedIntensity { get { return _ledIntensity; } set { _ledIntensity = value; this.PublishPropertyChanged(nameof(LedIntensity)); } }
        public string Log { get; set; } = "log";
        public Command GetValueCommad { get; set; }
        public LedControllerPageViewModel(LedController controller)
        {
            _ledController = controller;
            GetValueCommad = new Command(async () =>
            {
                LedIntensity = (await _ledController.GetLedValue()).Value;
            });
            _timer = new Timer(null, TimeSpan.FromMilliseconds(100), WriteValueTo);
            _timer.StartTimer();

        }
        private async Task WriteValueTo(object state)
        {
            await _ledController.SetLedValue(LedIntensity);
        }

    }
}

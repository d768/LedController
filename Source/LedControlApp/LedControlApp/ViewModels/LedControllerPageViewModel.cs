using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LedControlApp.Controllers;

namespace LedControlApp.ViewModels
{
    public class LedControllerPageViewModel
    {
        private Timer _timer;
        private LedController _ledController;
        public byte LedIntensity { get; set; } = 0;

        public LedControllerPageViewModel(LedController controller)
        {
            _ledController = controller;
        }

    }
}

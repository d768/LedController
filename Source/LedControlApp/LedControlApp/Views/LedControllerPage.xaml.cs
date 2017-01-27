using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LedControlApp.Controllers;
using LedControlApp.ViewModels;
using Xamarin.Forms;

namespace LedControlApp.Views
{
    public partial class LedControllerPage : ContentPage
    {
        public LedControllerPage()
        {
            var vm = new LedControllerPageViewModel(new LedController(App.Adapter.ConnectedDevices.First()));
            this.BindingContext = vm;
            InitializeComponent();
        }
    }
}

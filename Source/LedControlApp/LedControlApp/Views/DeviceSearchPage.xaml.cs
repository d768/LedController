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
    public partial class DeviceSearchPage : ContentPage
    {
        public DeviceSearchPage()
        {
            var vm = new DeviceSearchViewModel(App.Adapter);
            this.BindingContext = vm;
            InitializeComponent();
        }
    }
}

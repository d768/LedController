using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LedControlApp.Views;
using Plugin.BLE.Abstractions.Contracts;
using Xamarin.Forms;

namespace LedControlApp
{
    public partial class App : Application
    {
        public static IAdapter Adapter { get; set; }
        public static NavigationPage Navigation { get; set; }
        public App()
        {
            InitializeComponent();
            Navigation = new NavigationPage(new DeviceSearchPage());
            MainPage = Navigation;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

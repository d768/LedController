using System;

using Android.App;
using Android.Bluetooth;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using LedControlApp.Helpers;

namespace LedControlApp.Droid
{
    [Activity(Label = "LedControlApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            var appContext = Android.App.Application.Context;
            // get a reference to the bluetooth system service
            var manager = (BluetoothManager)appContext.GetSystemService("bluetooth");
            var adapter = manager.Adapter;     
            App.Adapter = new Plugin.BLE.Android.Adapter(manager);
            Plugin.BLE.Abstractions.Trace.TraceImplementation = Console.WriteLine;
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}


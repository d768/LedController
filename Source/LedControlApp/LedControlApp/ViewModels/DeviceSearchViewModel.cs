using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LedControlApp.Helpers;
using LedControlApp.Views;
using Plugin.BLE.Abstractions.Contracts;
using Xamarin.Forms;

namespace LedControlApp.ViewModels
{
    public class DeviceData
    {
        public string Name { get; set; }
        public string Rssi { get; set; }
        public string Mac { get; set; }

    }
    public class DeviceSearchViewModel:ViewModelBase
    {
        private IAdapter _adapter;

        public ObservableCollection<DeviceData> DeviceDataCollection { get; set; } = new ObservableCollection<DeviceData>(); 

        public ICommand ConnectCommand { get; set; }
        public ICommand StartSearchCommand { get; set; }
        public DeviceSearchViewModel(IAdapter adapter)
        {

            ConnectCommand = new Command(ConnectExecute);
            StartSearchCommand = new Command(StartSearchExecute);
            _adapter = adapter;
            _adapter.DeviceDiscovered += (sender, args) =>
            {
                if (DeviceDataCollection.FirstOrDefault(x => x.Mac == args.Device.Id.ToString()) == null)
                {
                    DeviceDataCollection.Add(new DeviceData()
                    {
                        Name = args.Device.Name,
                        Mac = args.Device.Id.ToString()
                    });
                }
            };
        }

        private async void ConnectExecute(object obj)
        {
            var data = (DeviceData) obj;
            _adapter.StopScanningForDevicesAsync();
            var device = _adapter.DiscoveredDevices.FirstOrDefault(x => x.Name == data.Name);
            if (device != null)
            {
                await _adapter.ConnectToDeviceAsync(device);
                if (_adapter.ConnectedDevices.Contains(device))
                {
                   await App.Navigation.PushAsync(new LedControllerPage());
                }
            }
        }

        private void StartSearchExecute()
        {
            _adapter.StartScanningForDevicesAsync();
        }

    }
}

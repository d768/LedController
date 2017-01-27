using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;

namespace LedControlApp.Controllers
{
    public class LedController
    {
        private Guid _serviceGuid = Guid.Parse("0000fff0-0000-1000-8000-00805f9b34fb");
        private Guid _charGuid = Guid.Parse("0000fff1-0000-1000-8000-00805f9b34fb");

        private IDevice _device;
        public LedController(IDevice device)
        {
            _device = device;
        }

        public async Task<byte?> GetLedValue()
        {
            var service = await _device.GetServiceAsync(_serviceGuid);
            var charact = await service.GetCharacteristicAsync(_charGuid);
            return (await charact.ReadAsync()).First();
        }

        public async Task<bool> SetLedValue(byte value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            var service = await _device.GetServiceAsync(_serviceGuid);
            var charact = await service.GetCharacteristicAsync(_charGuid);
            return await charact.WriteAsync(new byte[] {value});
        }

    }
}

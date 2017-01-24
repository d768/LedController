using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.BLE.Abstractions.Contracts;

namespace LedControlApp.Controllers
{
    public class LedController
    {
        private IAdapter _adapter;

        public LedController(IAdapter adapter)
        {
            _adapter = adapter;
        }

        public async Task<byte?> GetLedValue()
        {
            return byte.MaxValue;
        }

        public async Task<bool> SetLedValue(byte value)
        {
            return true;
        }
    }
}

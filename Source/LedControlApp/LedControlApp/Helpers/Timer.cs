using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControlApp.Helpers
{
    public class Timer
    {
        private bool _isPolling = false;
        private TimeSpan _timeout;
        private Func<object,Task> _action;
        private object _state;

        public Timer(object state, TimeSpan timeout, Func<object, Task> action)
        {
            _state = state;
            _timeout = timeout;
            _action = action;
        }
        public async Task StartTimer()
        {
            _isPolling = true;
            while (_isPolling)
            {
                await Task.Delay(_timeout);
                await _action(_state);
            }
        }

        public void StopTimer()
        {
            _isPolling = false;
        }
    }
}

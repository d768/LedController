using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedControlApp.Helpers
{
    public interface IEnvironmentChecker
    {
        bool IsRealDevice();
        double[] GetScreenDimensions(float viewWidth, float viewHeight);
    }
}

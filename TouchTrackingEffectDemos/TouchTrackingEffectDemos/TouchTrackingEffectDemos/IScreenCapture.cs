using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchTrackingEffectDemos
{
    public interface IScreenCapture
    {
        void CaptureScreen(SkiaSharp.SKData data);//SkiaSharp.SKData data
    }
}

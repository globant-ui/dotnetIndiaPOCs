using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TouchTrackingEffectDemos.Droid;
using Android.Graphics;
using System.IO;
using Android.Media;
using Android.Util;
using TouchTrackingEffectDemos;
//using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(ScreenCaptureDroid))]

namespace TouchTrackingEffectDemos.Droid
{
    public class ScreenCaptureDroid : IScreenCapture
    {
        public static Activity Activity { get; set; }

        public void CaptureScreen(SkiaSharp.SKData data) //SkiaSharp.SKData data
        {
            using (var stream = File.OpenWrite(Android.OS.Environment.ExternalStorageDirectory + "/image44.png"))
            {
                data.SaveTo(stream);
            }
        }


        public byte[] CaptureTaggedImage()
        {
            if (Activity == null)
            {
                throw new Exception("You have to set ScreenshotManager.Activity in your Android project");
            }
            var view = Activity.Window.DecorView.RootView;
            view.DrawingCacheEnabled = true;

            Bitmap bitmap = view.GetDrawingCache(true);

            byte[] bitmapData;

            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
         
            File.WriteAllBytes(Android.OS.Environment.ExternalStorageDirectory + "/ScreenShot.jpg", bitmapData);
            return bitmapData;
        }
    }
}
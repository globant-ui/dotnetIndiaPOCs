using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TouchTrackingEffectDemos.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(GetImageDroid))]

namespace TouchTrackingEffectDemos.Droid
{
    public class GetImageDroid : IGetImage
    {
        public GetImageDroid() { }

        public string GetImage(string imageName)
        {
            return Android.OS.Environment.ExternalStorageDirectory.Path + "/" + imageName;

            //var memoryStream = new MemoryStream();

            //using (var source = System.IO.File.OpenRead(Android.OS.Environment.ExternalStorageDirectory + "/" + "image43.png"))
            //{
            //    source.CopyToAsync(memoryStream);
            //}

            //return memoryStream;
        }
    }
}
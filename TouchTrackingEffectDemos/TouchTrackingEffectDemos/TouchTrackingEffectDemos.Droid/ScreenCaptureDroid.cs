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
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(ScreenCaptureDroid))]

namespace TouchTrackingEffectDemos.Droid
{
    public class ScreenCaptureDroid : IScreenCapture
    {
        public static Activity Activity { get; set; }

        public void CaptureScreen(SkiaSharp.SKData data) //SkiaSharp.SKData data
        {

            using (var stream = File.OpenWrite(Android.OS.Environment.ExternalStorageDirectory + "/image39.png"))
            {
                data.SaveTo(stream);
            }
            //Toast.MakeText(Activity, "Image saved", ToastLength.Long);
            //if (Activity == null)
            //{
            //    throw new Exception("You have to set ScreenshotManager.Activity in your Android project");
            //}










            //Final screenshot
            //var view = ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView; //Activity.Window.DecorView;
            //view.DrawingCacheEnabled = true;
            //Bitmap bitmap = view.GetDrawingCache(true);
            //var stream1 = new FileStream(Android.OS.Environment.ExternalStorageDirectory + "/screenshot34.png", FileMode.Create);
            //bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream1);
            //stream1.Close();
            //End - Final screenshot




            //view.SetFitsSystemWindows(false);
            //view.SetTag(1, "qqqq");



            //byte[] bitmapData;

            //using (var stream = new MemoryStream())
            //{
            //    bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
            //    bitmapData = stream.ToArray();
            //}

            //Bitmap bmp = BitmapFactory.DecodeByteArray(bitmapData, 0, bitmapData.Length);






            //File.WriteAllBytes(Android.OS.Environment.ExternalStorageDirectory + "/screenshot44.png", bitmapData);

            //var documentsDirectory = System.Environment.GetFolderPath
            //                          (System.Environment.SpecialFolder.Personal);
            //var stream1 = new FileStream(System.IO.Path.Combine(documentsDirectory, "screenshot88.png"), FileMode.OpenOrCreate);
            //bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream1);
            //stream1.Close();


            //File.WriteAllBytes(documentsDirectory + "/screenshot88.png", bitmapData);



            //var documentsDirectory = System.Environment.GetFolderPath
            //                          (System.Environment.SpecialFolder.Personal);
            //string jpgFilename = System.IO.Path.Combine(documentsDirectory, "screenshot11.png"); // hardcoded filename, overwritten each time
            //NSData imgData = bitmapData; // photo.AsJPEG();
            //NSError err = null;
            //if (imgData.Save(jpgFilename, false, out err))
            //{
            //    Console.WriteLine("saved as " + jpgFilename);
            //}
            //else
            //{
            //    Console.WriteLine("NOT saved as " + jpgFilename + " because" + err.LocalizedDescription);
            //}


        }
    }
}
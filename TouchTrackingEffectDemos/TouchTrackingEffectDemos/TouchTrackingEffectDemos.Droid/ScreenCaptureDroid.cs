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
//using Foundation;

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
            //  string filePath = Android.OS.Environment.ExternalStorageDirectory + "TaggedImages";
            //  string filename = System.IO.Path.Combine(filePath, DateTime.Now.ToShortTimeString());

            ////  var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            ////  var pictures = dir.AbsolutePath;
            //  //adding a time stamp time file name to allow saving more than one image... otherwise it overwrites the previous saved image of the same name
            //  string name = filename + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
            // // string filePath = System.IO.Path.Combine(pictures, name);
            //  try
            //  {
            //      System.IO.File.WriteAllBytes(filename, bitmapData);
            //      //mediascan adds the saved image into the gallery
            //      var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            //      mediaScanIntent.SetData(Android.Net.Uri.FromFile(Java.IO.File(filename)));
            //      Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
            //  }
            //  catch (Exception ex)
            //  {
            //      Log.Error("ERROR OCCURED", ex.Message);
            //  }
            File.WriteAllBytes(Android.OS.Environment.ExternalStorageDirectory + "/ScreenShot.jpg", bitmapData);
            return bitmapData;
        }
    }
}
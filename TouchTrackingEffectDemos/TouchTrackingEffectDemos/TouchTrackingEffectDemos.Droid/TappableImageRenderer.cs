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
using Xamarin.Forms.Platform.Android;
using TagImage;
using Xamarin.Forms;
using TagImage.Droid;

[assembly: ExportRenderer(typeof(TappableImage), typeof(TappableImageRenderer))]
namespace TagImage.Droid
{
  public  class TappableImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control != null)
                {
                    Control.Clickable = true;
                    Control.SetOnTouchListener(ImageTouchListener.Instance.Value);
                    Control.SetTag(Control.Id, new JavaObjectWrapper<TappableImage> { Obj = Element as TappableImage });
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Control != null)
                {
                    Control.SetOnTouchListener(null);
                }
            }

            base.Dispose(disposing);
        }

        private class ImageTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
        {
            public static readonly Lazy<ImageTouchListener> Instance = new Lazy<ImageTouchListener>(
                () => new ImageTouchListener());

            public bool OnTouch(Android.Views.View v, MotionEvent e)
            {
                var obj = v.GetTag(v.Id) as JavaObjectWrapper<TappableImage>;
                var element = obj.Obj;
                var controller = element as ITappableImage;
                if (e.Action == Android.Views.MotionEventActions.Down)
                {
                    var x = e.GetX();
                    var y = e.GetY();
                    element.TouchedCoordinate = new Tuple<float, float>(x, y);
                    controller?.SendTouched();
                }
                else if (e.Action == Android.Views.MotionEventActions.Up)
                {
                }
                return false;
            }
        }
    }
    public class JavaObjectWrapper<T> : Java.Lang.Object
    {
        public T Obj { get; set; }
    }
}
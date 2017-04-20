using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

using TouchTracking;
using System.IO;


namespace TouchTrackingEffectDemos
{
    public partial class FingerPaintPage : ContentPage
    {
        Dictionary<long, FingerPaintPolyline> inProgressPolylines = new Dictionary<long, FingerPaintPolyline>();
        List<FingerPaintPolyline> completedPolylines = new List<FingerPaintPolyline>();

        static SKBitmap resourceBitmap;
        //static SKSurface surf;
        static SKImage image1;

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeCap = SKStrokeCap.Round,
            StrokeJoin = SKStrokeJoin.Round
        };

        public FingerPaintPage()
        {
            InitializeComponent();
        }

        void OnClearButtonClicked(object sender, EventArgs args)
        {
            //completedPolylines.Clear();
            //canvasView.InvalidateSurface();

            //using (var image = SKImage.FromBitmap(resourceBitmap))
            //using (var data = image.Encode(SKImageEncodeFormat.Png, 80))
            //{
            //    // save the data to a stream

            //    using (var stream = System.IO.StreamWriter .OpenWrite("image1.png"))
            //    {
            //        data.SaveTo(stream);
            //    }
            //}

            //image1 = surf.Snapshot();
            //var image = SKImage.FromBitmap(resourceBitmap);
            var data = image1.Encode(SKImageEncodeFormat.Png, 80);
            
            DependencyService.Get<IScreenCapture>().CaptureScreen(data);//data
            


        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (!inProgressPolylines.ContainsKey(args.Id))
                    {
                        Color strokeColor = (Color)typeof(Color).GetRuntimeField(colorPicker.Items[colorPicker.SelectedIndex]).GetValue(null);
                        float strokeWidth = ConvertToPixel(new float[] { 1, 2, 5, 10, 20 }[widthPicker.SelectedIndex]);

                        FingerPaintPolyline polyline = new FingerPaintPolyline
                        {
                            StrokeColor = strokeColor,
                            StrokeWidth = strokeWidth
                        };
                        polyline.Path.MoveTo(ConvertToPixel(args.Location));

                        inProgressPolylines.Add(args.Id, polyline);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Moved:
                    if (inProgressPolylines.ContainsKey(args.Id))
                    {
                        FingerPaintPolyline polyline = inProgressPolylines[args.Id];
                        polyline.Path.LineTo(ConvertToPixel(args.Location));
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Released:
                    if (inProgressPolylines.ContainsKey(args.Id))
                    {
                        completedPolylines.Add(inProgressPolylines[args.Id]);
                        inProgressPolylines.Remove(args.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Cancelled:
                    if (inProgressPolylines.ContainsKey(args.Id))
                    {
                        inProgressPolylines.Remove(args.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;
            }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            //var stream = new SKFileStream("temp.jpg");
            //var bitmap = SKBitmap.Decode(stream);

            //
            //Assembly assembly = GetType().GetTypeInfo().Assembly;
            //or from the entry point to the application - there is a difference!
           // assembly.GetManifestResourceNames();//.GetExecutingAssembly().GetManifestResourceNames()

            SKImageInfo info = args.Info;
            //surf = args.Surface;
           // surf.Snapshot();
            ////string resourceID = "temp.jpg";

            //Stream fileStream = File.OpenRead("temp.png");
            //using (var stream = new SKManagedStream(fileStream))
            //using (var bitmap = SKBitmap.Decode(stream))
            //using (var paint = new SKPaint())
            //{
            //    canvas.DrawBitmap(bitmap, SKRect.Create(Width, Height), paint);
            //}

            //Assembly assembly = GetType().GetTypeInfo().Assembly;

            //using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            //using (SKManagedStream skStream = new SKManagedStream(stream))
            //{
            //    resourceBitmap = SKBitmap.Decode(skStream);
            //}
            //

            string resourceID = "TouchTrackingEffectDemos.DrawBG.png";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            using (SKManagedStream skStream = new SKManagedStream(stream))
            {
                resourceBitmap = SKBitmap.Decode(skStream);
            }

            SKCanvas canvas = args.Surface.Canvas;

            
            //SKCanvas canvas = new SKCanvas(bitmap);
            canvas.Clear();

            //if (bitmap != null)
            //{
            //    float x = (info.Width - bitmap.Width) / 2;
            //    float y = (info.Height / 3 - bitmap.Height) / 2;
            //    canvas.DrawBitmap(bitmap, x, y);
            //}

            if (resourceBitmap != null)
            {
                float x = (info.Width - resourceBitmap.Width) / 2;
                float y = (info.Height / 3 - resourceBitmap.Height) / 2;

                canvas.DrawBitmap(resourceBitmap, x, y);
            }

            foreach (FingerPaintPolyline polyline in completedPolylines)
            {
                paint.Color = polyline.StrokeColor.ToSKColor();
                paint.StrokeWidth = polyline.StrokeWidth;
                canvas.DrawPath(polyline.Path, paint);
            }

            foreach (FingerPaintPolyline polyline in inProgressPolylines.Values)
            {
                paint.Color = polyline.StrokeColor.ToSKColor();
                paint.StrokeWidth = polyline.StrokeWidth;
                canvas.DrawPath(polyline.Path, paint);
            }

            image1 = args.Surface.Snapshot();
            //canvas.SaveLayer(paint);
        }

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                               (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));
        }

        float ConvertToPixel(float fl)
        {
            return (float)(canvasView.CanvasSize.Width * fl / canvasView.Width);
        }
    }
}
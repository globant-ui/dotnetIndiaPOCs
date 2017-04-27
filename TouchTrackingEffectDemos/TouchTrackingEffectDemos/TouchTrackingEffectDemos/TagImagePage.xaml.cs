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
    public partial class TagImagePage : ContentPage
    {
        Dictionary<long, FingerPaintPolyline> inProgressPolylines = new Dictionary<long, FingerPaintPolyline>();
        List<FingerPaintPolyline> completedPolylines = new List<FingerPaintPolyline>();

        static SKBitmap resourceBitmap;
        //static SKSurface surf;
        static SKImage image1;
        static Entry txt = new Entry();
        
        static Point touchPoint;
        static SKPoint touchPoint1;

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeCap = SKStrokeCap.Round,
            StrokeJoin = SKStrokeJoin.Round
        };


        public TagImagePage()
        {
            InitializeComponent();
        }

        void OnClearButtonClicked(object sender, EventArgs args)
        {
            completedPolylines.Clear();
            canvasView.InvalidateSurface();


            //image1 = surf.Snapshot();
            //var image = SKImage.FromBitmap(resourceBitmap);

            //Final
            //var data = image1.Encode(SKImageEncodeFormat.Png, 80);            
            //DependencyService.Get<IScreenCapture>().CaptureScreen(data);//data



        }

        void OnSaveButtonClicked(object sender, EventArgs args)
        {
            var data = image1.Encode(SKImageEncodeFormat.Png, 80);
            DependencyService.Get<IScreenCapture>().CaptureScreen(data);//data

            DisplayAlert("", "Image saved successfully!", "OK");
        }

        void OnGetButtonClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ImageView("image44.png"));
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (!inProgressPolylines.ContainsKey(args.Id))
                    {
                        //Color strokeColor = (Color)typeof(Color).GetRuntimeField(colorPicker.Items[colorPicker.SelectedIndex]).GetValue(null);
                        //float strokeWidth = ConvertToPixel(new float[] { 1, 2, 5, 10, 20 }[widthPicker.SelectedIndex]);

                        //FingerPaintPolyline polyline = new FingerPaintPolyline
                        //{
                        //    StrokeColor = strokeColor,
                        //    StrokeWidth = strokeWidth
                        //};
                        //polyline.Path.MoveTo(ConvertToPixel(args.Location));

                        //inProgressPolylines.Add(args.Id, polyline);


                        
                        touchPoint = args.Location;
                        touchPoint1 = ConvertToPixel(args.Location);
                        txt.Text = "";

                        txt.TextChanged += Txt_TextChanged;
                            
                                          
                        txt.WidthRequest = 300;
                        txt.HeightRequest = 40;
                        txt.VerticalOptions = LayoutOptions.Start;
                        txt.HorizontalOptions = LayoutOptions.Start;
                        //txt.BackgroundColor = Color.Yellow;
                        txt.InputTransparent=true;
                        txt.TextColor = Color.White;
                        txt.BackgroundColor = Color.Transparent;

                        gridCanvas.Children.Add(txt, 0, 0);
                       
                        //gridCanvas.Children[1].
                        gridCanvas.Children[1].TranslationX = args.Location.X; //ConvertToPixel(args.Location).X;
                        gridCanvas.Children[1].TranslationY = args.Location.Y; //ConvertToPixel(args.Location).Y;
                        //canvasView.InputTransparent = true;
                        gridCanvas.Children[1].Focus();

                        gridCanvas.RowDefinitions[0].Height = GridLength.Star;
                        //gridCanvas.RowDefinitions[1].Height = GridLength.Star;

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

        private void Txt_TextChanged(object sender, TextChangedEventArgs e)
        {

            //txt.BackgroundColor = Color.Tan;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {

            

            SKImageInfo info = args.Info;


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


                if (resourceBitmap != null)
                {
                    float x = (info.Width - resourceBitmap.Width) / 2;
                    float y = (info.Height / 3 - resourceBitmap.Height) / 2;

                    canvas.DrawBitmap(resourceBitmap, x, y);
                }

                //foreach (FingerPaintPolyline polyline in completedPolylines)
                //{
                //    paint.Color = polyline.StrokeColor.ToSKColor();
                //    paint.StrokeWidth = polyline.StrokeWidth;
                //    canvas.DrawPath(polyline.Path, paint);
                //}

                //foreach (FingerPaintPolyline polyline in inProgressPolylines.Values)
                //{
                //    paint.Color = polyline.StrokeColor.ToSKColor();
                //    paint.StrokeWidth = polyline.StrokeWidth;
                //    canvas.DrawPath(polyline.Path, paint);
                //}

                //
                var brush = new SKPaint
                {
                    TextSize = 35.0f,
                    IsAntialias = true,
                    Color = new SKColor(255, 255, 255, 255)
                };
                //ConvertToPixel(args.Location)
                if (txt.Text == null)
                    txt.Text = "";
            if (txt.Text != "")
            {
                //
                // Adjust TextSize property so text is 90% of screen width
                //float textWidth = brush.MeasureText(txt.Text);
                //brush.TextSize = 0.9f * args.Info.Width * brush.TextSize / textWidth;

                // Find the text bounds
                SKRect textBounds;
                brush.MeasureText(txt.Text, ref textBounds);
                //

                canvas.DrawText(txt.Text, Convert.ToSingle(touchPoint1.X), Convert.ToSingle(touchPoint1.Y+30), brush);
                txt.Text = "";
                //txt.Unfocus();



                //
                // Create a new SKRect object for the frame around the text
                SKRect frameRect = textBounds;
                frameRect.Offset(Convert.ToSingle(touchPoint1.X), Convert.ToSingle(touchPoint1.Y + 30));
                frameRect.Inflate(10, 10);

                // Create an SKPaint object to display the frame
                SKPaint framePaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 5,
                    Color = SKColors.White
                };

                // Draw one frame
                //canvas.DrawRoundRect(frameRect, 20, 20, framePaint);
                canvas.DrawRect(frameRect,framePaint);

                // Inflate the frameRect and draw another
                //frameRect.Inflate(10, 10);
                //framePaint.Color = SKColors.DarkBlue;
                //canvas.DrawRoundRect(frameRect, 30, 30, framePaint);
                //


            }

            
            //canvas.DrawPositionedText(.DrawNamedDestinationAnnotation(point, "");
            //canvas.DrawText("Sample text", ConvertToPixel(args.Surface.Canvas..Location), brush);
            //

            
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

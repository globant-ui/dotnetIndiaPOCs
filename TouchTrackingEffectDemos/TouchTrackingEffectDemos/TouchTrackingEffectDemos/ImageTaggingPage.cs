using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TagImage;
using Xamarin.Forms;

namespace TouchTrackingEffectDemos
{
    public class ImageTaggingPage : ContentPage
    {
        TappableImage newimage = new TappableImage();
        StackLayout content = null;
        Tuple<float, float> cor;
        RelativeLayout layout;
        Grid grid;
        public ImageTaggingPage()
        {
            Image image = new Image();
           // InitializeComponent();
            var page = new ContentPage();
            page.Title = "Image Tagging";
            content = new StackLayout();
            // add content controls to layout here
            var sampleimage = new Image();

            newimage.Source = "waterfront.jpg";
            content.Children.Add(newimage);
            page.Content = content;
            newimage.Touched += Newimage_Touched;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, "TapCommand");

            tapGestureRecognizer.Tapped += (s, e) => {
                // handle the tap
                Entry txt = new Entry();
                //   e.ViewPoint.
                double d = this.Content.X;
                double w = this.Content.Y;
                txt.TranslationX = d;
                txt.TranslationY = w;
                content.Children.Add(txt);
                txt.Focus();
                //txt.Completed += (sender, e) => {
                //    Label lblTag = new Label();
                //    lblTag.Text = txt.Text;
                //};

            };

            sampleimage.GestureRecognizers.Add(tapGestureRecognizer);
            newimage.GestureRecognizers.Add(tapGestureRecognizer);
            grid = new Grid();
            grid.Children.Add(newimage);
            layout = new RelativeLayout();
            //   Button btnSave = new Button();
            //  btnSave.Text = "SAVE";
            // btnSave.Clicked += BtnSave_Clicked;
            var myLabel = new Label()
            {
                Text = "Hello World",
                //Font = Font.SystemFontOfSize(20),
                //TextColor = Color.White,
                //XAlign = TextAlignment.Center,
                //YAlign = TextAlignment.Center
            };
            layout.Children.Add(grid,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            //layout.Children.Add(myLabel,
            //    Constraint.Constant(0),
            //    Constraint.Constant(0),
            //    Constraint.RelativeToParent((parent) => { return parent.Width; }),
            //    Constraint.RelativeToParent((parent) => { return parent.Height; }));

            //return new ContentPage
            //{
            //    Content = layout
            //};
            layout.GestureRecognizers.Add(tapGestureRecognizer);
            tapGestureRecognizer.Tapped += (s, e) => {
                // handle the tap
                Entry txt = new Entry();
                //   e.ViewPoint.
                double d = this.Content.X;
                double w = this.Content.Y;
                txt.TranslationX = d;
                txt.TranslationY = w;
                txt.TextColor = Color.Red;
                layout.Children.Add(txt,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width / 3; }),
                Constraint.RelativeToParent((parent) => { return parent.Height / 3; }));
                txt.Margin = new Thickness(40, 40, 40, 40);
                txt.Focus();
                //txt.Completed += (sender, e) => {
                //    Label lblTag = new Label();
                //    lblTag.Text = txt.Text;
                //};

            };
            //this.Content = content;
            this.Content = layout;
        }
        private void Newimage_Touched(object sender, EventArgs e)
        {
            cor = newimage.TouchedCoordinate;
            double x, y;
            // if (cor != null)
            //  {
            x = cor.Item1;
            y = cor.Item2;
            //   }
            //Entry txt = new Entry();
            //txt.Margin = new Thickness(20, 20, 0, 0);
            //txt.HeightRequest =400;
            //txt.WidthRequest = 400;
            //layout.Children.Add(txt);


            Entry txt = new Entry();
            //   e.ViewPoint.
            double d = this.Content.X;
            double w = this.Content.Y;
            txt.TextColor = Color.Red;
            txt.TranslationX = d;
            txt.TranslationY = w;
            RelativeLayout child = new RelativeLayout();
            //layout.Children.Add(txt,
            //Constraint.Constant(0),
            //Constraint.Constant(0),
            //Constraint.Constant(x),
            //Constraint.Constant(y));
            //Rectangle ract = new Rectangle(d, w, 100, 100);
            //RelativeLayout.LayoutChildIntoBoundingRegion(txt, ract);
            txt.Margin = new Thickness(x, y, 0, 0);
            grid.Children.Add(txt);

            txt.Focus();
            // this.Content = content;
        }
    }
}

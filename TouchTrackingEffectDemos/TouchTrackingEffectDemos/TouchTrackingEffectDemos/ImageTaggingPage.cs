﻿using System;
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
        //StackLayout content = null;
        Tuple<float, float> cor;
        RelativeLayout layout;
        Grid grid;
        Button btnSave;
        Button btnShow;
        public ImageTaggingPage()
        {
            Image image = new Image();          
            var page = new ContentPage();        
            var sampleimage = new Image();
            newimage.Source = "waterfront.jpg";
         
            newimage.Touched += Newimage_Touched;
            grid = new Grid();

            // created rows & columns for grid
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1,GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

            // add first child to grid
            grid.Children.Add(newimage, 0, 0);
            Grid.SetColumn(newimage, 0);
            Grid.SetRow(newimage, 0);
            Grid.SetColumnSpan(newimage, 2);
         

        
            layout = new RelativeLayout();
            btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.HeightRequest = 50;
            btnSave.WidthRequest = 100;
           // btnSave.Height = 50;
            btnSave.Clicked += BtnSave_Clicked;
        //    btnSave.HorizontalOptions = LayoutOptions.Center;
            grid.Children.Add(btnSave,1,0);
           Grid.SetColumn(btnSave,0);
           Grid.SetRow(btnSave, 1);

            btnShow = new Button();
            btnShow.Text = "Show";
            btnShow.HeightRequest = 50;
            btnShow.WidthRequest = 100;

            // btnSave.Height = 50;
            btnShow.Clicked += BtnShow_Clicked;
         //   btnShow.HorizontalOptions = LayoutOptions.Center;
            grid.Children.Add(btnShow, 1, 1);
            Grid.SetColumn(btnShow, 1);
            Grid.SetRow(btnShow, 1);
            var myLabel = new Label()
            {
                Text = "Hello World",
            
            };
            layout.Children.Add(grid,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => { return parent.Width; }),
                Constraint.RelativeToParent((parent) => { return parent.Height; }));

            btnShow.IsVisible = false;
            btnSave.IsVisible = false;
            this.Content = layout;
        }

        private void BtnShow_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImageView("ScreenShot.jpg"));
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            btnSave.IsVisible = false;
            DependencyService.Get<IScreenCapture>().CaptureTaggedImage();//data
            DisplayAlert("", "Image saved successfully!", "OK");
            btnShow.IsVisible = true;
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
            txt.WidthRequest = 200;
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
            btnSave.IsVisible = true;
            // this.Content = content;
        }
       
    }
}

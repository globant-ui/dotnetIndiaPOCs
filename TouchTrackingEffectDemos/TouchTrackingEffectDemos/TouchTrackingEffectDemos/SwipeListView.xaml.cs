using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TouchTrackingEffectDemos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeListView : ContentPage
    {
        //ListView lsvData = new ListView()
        //{
        //    VerticalOptions = LayoutOptions.Fill,
        //    HorizontalOptions = LayoutOptions.Fill,
        //    BackgroundColor = Color.White,
        //    HasUnevenRows = true,
        //};
        List<WaterControllers> Controllers = new List<WaterControllers>();
        public SwipeListView()
        {
            InitializeComponent();
            #region DataTemplate
            DataTemplate ListDataTemplate = new DataTemplate(() =>
            {
                #region DataArea of Template
                SwipeGestureGrid gridData = new SwipeGestureGrid()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = 60,
                    RowDefinitions =
                        {
                            new RowDefinition { },
                        },
                    ColumnDefinitions =
                        {
                            new ColumnDefinition { },
                        }
                };
                #endregion
                #region Base of Template
                Grid gridBase = new Grid()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = 60,
                    RowDefinitions =
                    {
                        new RowDefinition { },
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { },                                                   //Put Cells Data here
                        new ColumnDefinition { Width = new GridLength(0, GridUnitType.Absolute)},   //Button for Cells here
                        new ColumnDefinition { Width = new GridLength(0, GridUnitType.Absolute)},   //Button for Cells here
                    },
                };
                #endregion
                Label lblText = new Label
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    FontAttributes = FontAttributes.Bold,
                    VerticalTextAlignment = TextAlignment.End,
                    TextColor = Color.Black,
                    BackgroundColor = Color.White,
                    LineBreakMode = LineBreakMode.TailTruncation,
                    FontSize = 18,
                };
                lblText.SetBinding(Label.TextProperty, "Name");

                // lblText.BindingContext = Controllers;

                Button btnCellDelete = new Button() { Text = "Delete" };

                Button btnCellView = new Button() { Text = "View" };

                gridData.Children.Add(lblText, 0, 0);

                gridBase.Children.Add(gridData, 0, 0);
                gridBase.Children.Add(btnCellDelete, 1, 0);
                gridBase.Children.Add(btnCellView, 2, 0);
                Grid.SetColumn(btnCellView, 2);

                gridData.SwipeLeft += GridTemplate_SwipeLeft;
                gridData.SwipeRight += GridTemplate_SwipeRight; ;
                gridData.Tapped += GridTemplate_Tapped; ;
                btnCellDelete.Clicked += BtnCellDelete_Clicked;
                btnCellView.Clicked += BtnCellView_Clicked; ;

                return new ViewCell
                {
                    View = gridBase,
                    Height = 60,
                };
            });
            #endregion
            // LoadData();
            lsvData.ItemTemplate = ListDataTemplate;
            List<WaterControllers> Controllers = new List<WaterControllers>();
            Controllers.Add(new WaterControllers { Name = "Controller 1", ControllerDetails = "3232 Dallas", ControllerAlerts = "2" });
            Controllers.Add(new WaterControllers { Name = "Controller 2", ControllerDetails = "34 Dallas", ControllerAlerts = "5" });
            Controllers.Add(new WaterControllers { Name = "Controller 3", ControllerDetails = "556 Dallas", ControllerAlerts = "1" });
            Controllers.Add(new WaterControllers { Name = "Controller 4", ControllerDetails = "2324 Dallas", ControllerAlerts = "3" });
            lsvData.ItemsSource = Controllers;

            //Content = lsvData;
            //     this.BindingContext = Controllers;
        }

        private void BtnCellView_Clicked(object sender, EventArgs e)
        {
            //
            if (sender is Button)
            {
                var templateGrid = ((Button)sender);
                WaterControllers w = (WaterControllers)templateGrid.Parent.Parent.BindingContext;

                if (Slider.Bounds.Height == 0)
                {
                    //Slider.MinimumHeightRequest = 400;
                    var originalposition = Slider.Bounds;
                    var newposition = Slider.Bounds;
                    newposition.Height = 300;
                    newposition.Y = originalposition.Y - newposition.Height; //325;
                                                                             // this.Height * 2; // - Slider.Height;
                    Slider.LayoutTo(newposition, 1000, Easing.CubicInOut);
                    lblSliderHeader.Text = w.Name;
                    //Slider.ScaleTo(2, 2000, Easing.Linear);

                }
                else
                {
                    var originalposition = Slider.Bounds;
                    var newposition = Slider.Bounds;
                    newposition.Y = originalposition.Y + newposition.Height; //325;
                    newposition.Height = 0;
                    // this.Height * 2; // - Slider.Height;
                    Slider.LayoutTo(newposition, 1000, Easing.CubicInOut);
                    //Slider.ScaleTo(2, 2000, Easing.Linear);
                    lblSliderHeader.Text = w.Name;

                }
            }

            //WaterControllers w = (WaterControllers)templateGrid.Parent.Parent.BindingContext;
            //DisplayAlert("Title", w.Name, "OK");
            //
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Message", "Button Clicked", "OK");
        }

        //public async void LoadData()
        //{
        //    List<WaterControllers> Controllers = new List<WaterControllers>();
        //    Controllers.Add(new WaterControllers { Name = "ABCD", ControllerDetails = "3232 Dallas", ControllerAlerts = "2" });
        //    Controllers.Add(new WaterControllers { Name = "EFDF", ControllerDetails = "34 Dallas", ControllerAlerts = "5" });
        //    Controllers.Add(new WaterControllers { Name = "SDFD", ControllerDetails = "556 Dallas", ControllerAlerts = "1" });
        //    Controllers.Add(new WaterControllers { Name = "RERW", ControllerDetails = "2324 Dallas", ControllerAlerts = "3" });

        //    lb_Users.ItemsSource = Controllers;
        //}
        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            WaterControllers x = (WaterControllers)mi.CommandParameter;
            DisplayAlert("Delete Context Action", x.Name + " delete context action", "OK");
        }
        /// <summary>
        /// SwipeLeft to Show DeleteButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridTemplate_SwipeLeft(object sender, EventArgs e)
        {
            try
            {
                if (sender is SwipeGestureGrid)
                {
                    var templateGrid = ((SwipeGestureGrid)sender).Parent;
                    if (templateGrid != null && templateGrid is Grid)
                    {
                        var CellTemplateGrid = (Grid)templateGrid;
                        CellTemplateGrid.ColumnDefinitions[1].Width = new GridLength(100, GridUnitType.Absolute);
                        CellTemplateGrid.ColumnDefinitions[2].Width = new GridLength(100, GridUnitType.Absolute);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// SwipeRight to Hide DeleteButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridTemplate_SwipeRight(object sender, EventArgs e)
        {
            try
            {
                if (sender is SwipeGestureGrid)
                {
                    var templateGrid = ((SwipeGestureGrid)sender).Parent;
                    if (templateGrid != null && templateGrid is Grid)
                    {
                        var CellTemplateGrid = (Grid)templateGrid;
                        CellTemplateGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);
                        CellTemplateGrid.ColumnDefinitions[2].Width = new GridLength(0, GridUnitType.Absolute);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// DeleteButton Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCellDelete_Clicked(object sender, EventArgs e)
        {
            
            try
            {
                if (sender is Button)
                {
                    var templateGrid = ((Button)sender);
                    //templateGrid.Parent = gridBase
                    //templateGrid.Parent.Parent = cell
                    if (templateGrid.Parent != null && templateGrid.Parent.Parent != null && templateGrid.Parent.Parent.BindingContext != null && templateGrid.Parent.Parent.BindingContext is string)
                    {
                        var deletedate = templateGrid.Parent.Parent.BindingContext as string;

                        
                        //lstData.RemoveAll(f => f == deletedate);
                        //lsvData.ItemsSource = null;
                        //lsvData.ItemsSource = lstData;
                    }

                    
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GridTemplate_Tapped(object sender, EventArgs e)
        {
            try
            {
                if (sender is SwipeGestureGrid)
                {
                    var templateGrid = ((SwipeGestureGrid)sender);
                    if (templateGrid.Parent != null && templateGrid.Parent.Parent != null && templateGrid.Parent.Parent.BindingContext != null && templateGrid.Parent.Parent.BindingContext is string)
                    {
                        //   Debug.WriteLine(templateGrid.Parent.Parent.BindingContext.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
    public class WaterControllers
    {
        public string Name { get; set; }
        public string ControllerDetails { get; set; }
        public string ControllerAlerts { get; set; }
    }
}

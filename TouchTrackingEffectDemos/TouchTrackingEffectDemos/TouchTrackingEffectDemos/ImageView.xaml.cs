using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TouchTrackingEffectDemos
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageView : ContentPage
    {
        public ImageView(string imageName)
        {
            InitializeComponent();
            string s = DependencyService.Get<IGetImage>().GetImage(imageName);
            imgSaved.Source = ImageSource.FromFile(s);
        }

        void OnBackButtonClicked(object sender, EventArgs args)
        {
            //Navigation.PushModalAsync(new FingerPaintPage());
            Navigation.PopAsync();
        }
    }
}


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TouchTrackingEffectDemos
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowImageGallery : ContentPage
    {
         public ShowImageGallery()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
       
        }

      
     
    }

}

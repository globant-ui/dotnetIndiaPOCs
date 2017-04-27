
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
            TapGestureRecognizer tapgesture = new TapGestureRecognizer();
            tapgesture.Tapped += Tapgesture_Tapped;
            // CameraImage.GestureRecognizers.Add(tapgesture);
            //   CameraImage.SetBinding(Bind,this)
            CameraButton.Image = "cameraicon.png";
            CameraButton.Orientation = XLabs.Enums.ImageOrientation.ImageOnTop;
        }

        private void Tapgesture_Tapped(object sender, System.EventArgs e)
        {
           // CameraImage.SetBinding(new Binding("CameraCommand"));
        }
    }

}

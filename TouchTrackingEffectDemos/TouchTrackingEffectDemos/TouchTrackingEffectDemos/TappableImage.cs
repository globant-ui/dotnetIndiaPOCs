using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TagImage
{
   public class TappableImage :  Image, ITappableImage
    {
        public event EventHandler Touched;
        public void SendTouched()
        {
            Touched?.Invoke(this, EventArgs.Empty);
        }

        public Tuple<float, float> TouchedCoordinate
        {
            get { return (Tuple<float, float>)GetValue(TouchedCoordinateProperty); }
            set { SetValue(TouchedCoordinateProperty, value); }
        }

        public static readonly BindableProperty TouchedCoordinateProperty =
            BindableProperty.Create(
                propertyName: "TouchedCoordinate",
                returnType: typeof(Tuple<float, float>),
                declaringType: typeof(TappableImage),
                defaultValue: new Tuple<float, float>(0, 0),
                propertyChanged: OnPropertyChanged);

        public static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }
    }
}

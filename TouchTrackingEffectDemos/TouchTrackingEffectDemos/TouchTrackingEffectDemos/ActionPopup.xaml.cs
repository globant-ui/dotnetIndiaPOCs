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
    public partial class ActionPopup : ContentPage
    {
        public ActionPopup()
        {
            InitializeComponent();

            //aInstructions.TranslationY = 200;

            var people = new List<Person> {
                new Person ("Steve", 21, "USA"),
                new Person ("John", 37, "USA"),
                new Person ("Tom", 42, "UK"),
                new Person ("Lucas", 29, "Germany"),
                new Person ("Tariq", 39, "UK"),
                new Person ("Jane", 30, "USA")
            };

            listViewPerson.ItemsSource = people;
        }

        private void Show_Clicked(object sender, EventArgs e)
        {


            if (btnShow.Text == "Show Slider")
            {
                //Slider.MinimumHeightRequest = 400;
                var originalposition = Slider.Bounds;
                var newposition = Slider.Bounds;
                newposition.Height = 200;
                newposition.Y = originalposition.Y - newposition.Height; //325;
                                                                         // this.Height * 2; // - Slider.Height;
                Slider.LayoutTo(newposition, 1000, Easing.CubicInOut);
                //Slider.ScaleTo(2, 2000, Easing.Linear);
                btnShow.Text = "Hide Slider";
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
                btnShow.Text = "Show Slider";
            }

        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Message", "Button1 Clicked","OK");
        }
    }
    public class Person
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Location { get; private set; }

        public Person(string name, int age, string location)
        {
            Name = name;
            Age = age;
            Location = location;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

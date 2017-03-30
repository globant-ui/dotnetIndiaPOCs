using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormsApp1
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();

            var people = new List<Person> {
                new Person ("Steve", 21, "USA"),
                new Person ("John", 37, "USA"),
                new Person ("Tom", 42, "UK"),
                new Person ("Lucas", 29, "Germany"),
                new Person ("Tariq", 39, "UK"),
                new Person ("Jane", 30, "USA")
            };

            listView.ItemsSource = people;

            //Button gotoFirstTabButton = new Button { Text = "Go to FirstTab Page", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.CenterAndExpand };
            //gotoFirstTabButton.Clicked += async (sender, args) => { await Navigation.PushAsync(new FirstTab()); };
        }

        //void OnbtnNavigatorClicked(object sender, EventArgs args)
        //{
        //    btnNavigator.Text = "CLicked";
        //}

    }
}

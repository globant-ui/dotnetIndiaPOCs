using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FormsApp1
{
	public partial class FirstTab : ContentPage
	{
		public FirstTab ()
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
        }
	}
}

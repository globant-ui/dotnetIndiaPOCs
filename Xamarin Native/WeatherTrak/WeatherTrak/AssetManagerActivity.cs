using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CurrentLocation
{
    [Activity(Label = "Asset Manager")]
    public class AssetManagerActivity : TabActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AssetManager);

            //ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            
            //// Add the tabs to Action Bar  
            //AddTab("List");
            //AddTab("Map");
            //AddTab("Search");


            CreateTab(typeof(AssetListActivity), "AssetList", "List");
            CreateTab(typeof(AssetMapActivity), "Asset Map", "Map");
            CreateTab(typeof(AssetSearchActivity), "Asset Search", "Search");
            //CreateTab(typeof(SpeakersActivity), "speakers", "Speakers", Resource.Drawable.ic_tab_speakers);
            //CreateTab(typeof(SessionsActivity), "sessions", "Sessions", Resource.Drawable.ic_tab_sessions);
            //CreateTab(typeof(MyScheduleActivity), "my_schedule", "My Schedule", Resource.Drawable.ic_tab_my_schedule);

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void CreateTab(Type activityType, string tag, string label)
        {
            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);

            var spec = TabHost.NewTabSpec(tag);
            //var drawableIcon = Resources.GetDrawable(drawableId);
            spec.SetIndicator(label);
            spec.SetContent(intent);

            TabHost.AddTab(spec);
        }


        //private void AddTab(string tabText)
        //{
        //    ActionBar.Tab tab = ActionBar.NewTab();
        //    tab.SetText(tabText);
        //    tab.TabSelected += OnTabSelected;
        //    ActionBar.AddTab(tab);
        //}

        //private void OnTabSelected(object sender, ActionBar.TabEventArgs args)
        //{
        //    var CurrentTab = (ActionBar.Tab)sender;

        //    if (CurrentTab.Position == 0)
        //    {
        //        //textView.Text = "Tab One Selected";
        //        Toast.MakeText(this, "List", ToastLength.Short).Show();
        //    }

        //    else if (CurrentTab.Position == 1)
        //    {
        //        //textView.Text = "Tab Two Selected";
        //        Toast.MakeText(this, "Map", ToastLength.Short).Show();
        //    }
        //    else if (CurrentTab.Position == 2)
        //    {
        //        //textView.Text = "Tab Two Selected";
        //        Toast.MakeText(this, "Search", ToastLength.Short).Show();
        //    }
        //}

    }
}
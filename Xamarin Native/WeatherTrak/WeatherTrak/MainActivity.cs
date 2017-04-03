using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;
using System.Collections.Generic;
using Android.Util;
using System.Linq;

namespace CurrentLocation
{
    [Activity(Label = "Add Asset", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ILocationListener
    {
        TextView txtlatitu;
        TextView txtlong;
        TextView assetNameTxt;
        TextView descriptionTxt;
        TextView identifierText;

        public static double latitude;
        public static double longitude;
        public static string assetName;
        public static string description;

        TextView _addressText;
        Location _currentLocation;
        LocationManager _locationManager;
        string _locationProvider;
        TextView _locationText;

        public string TAG { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Spinner spinner = FindViewById<Spinner>(Resource.Id.assettype);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.assets_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            txtlatitu = FindViewById<TextView>(Resource.Id.gpslatitude);
            txtlong = FindViewById<TextView>(Resource.Id.gpslongitude);
            assetNameTxt = FindViewById<TextView>(Resource.Id.assetname);
            descriptionTxt = FindViewById<TextView>(Resource.Id.description);
            identifierText = FindViewById<TextView>(Resource.Id.identifier);

            Button btnWatchMap = FindViewById<Button>(Resource.Id.watchOnMap);
            btnWatchMap.Click += BtnWatchMap_Click;

            Switch togglebutton = FindViewById<Switch>(Resource.Id.togglebutton);
            togglebutton.Click += Togglebutton_Click;

            InitializeLocationManager();
        }

        private void BtnWatchMap_Click(object sender, EventArgs e)
        {
            latitude = Convert.ToDouble(txtlatitu.Text);
            longitude = Convert.ToDouble(txtlong.Text);
            assetName = assetNameTxt.Text;
            description = descriptionTxt.Text;
            StartActivity(typeof(AssetMapActivity));
        }

        private void Togglebutton_Click(object sender, EventArgs e)
        {
            // Perform action on clicks
            if (((Switch)sender).Checked)
            {
                txtlatitu.Enabled = false;
                txtlatitu.Enabled = false;

                txtlatitu.Text = latitude.ToString();
                txtlong.Text = longitude.ToString();
            }
            else
            {
                txtlatitu.Enabled = true;
                txtlatitu.Enabled = true;
            }
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //Spinner spinner = (Spinner)sender;

            //string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.NoRequirement
            };
            IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();
                identifierText.Text = _locationProvider;
            }
            else
            {
                identifierText.Text = "provider empty";
                _locationProvider = string.Empty;
            }
            Log.Debug(TAG, "Using " + _locationProvider + ".");
            OnLocationChanged(_locationManager.GetLastKnownLocation("gps"));
        }
        protected override void OnResume()
        {
            base.OnResume();
            _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);

        }
        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
        }

        public void OnLocationChanged(Location location)
        {
            _currentLocation = location;
            if (_currentLocation == null)
            {
                //Error Message
            }
            else
            {
                latitude = _currentLocation.Latitude;
                longitude = _currentLocation.Longitude;
            }
        }

        public void OnProviderDisabled(string provider)
        {
         
        }

        public void OnProviderEnabled(string provider)
        {
           
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
           
        }

    }
}


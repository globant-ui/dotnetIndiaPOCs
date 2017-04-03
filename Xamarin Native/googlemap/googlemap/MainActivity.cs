using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Gms.Common;

namespace googlemap
{
    [Activity(Label = "googlemap", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {

        private GoogleMap GMap;
        protected override void OnCreate(Bundle bundle)
        {
            try
            { 
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            SetUpMap();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }

        private void SetUpMap()
        {
            try
            {
                if (GMap == null)
                {
                    FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);

                }
            }
            catch(Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            try
            {
                this.GMap = googleMap;
            GMap.UiSettings.ZoomControlsEnabled = true;
           
         

            LatLng latlng = new LatLng(Convert.ToDouble(13.0291), Convert.ToDouble(80.2083));
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            GMap.MoveCamera(camera);
            GMap.MapClick += GMap_MapClick;

            MarkerOptions options = new MarkerOptions()
                        .SetPosition(latlng)
                        .SetTitle("Chennai");

            GMap.AddMarker(options);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }

        private void GMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            LatLng latlng = new LatLng(e.Point.Latitude, e.Point.Longitude);
            MarkerOptions markerOpt1 = new MarkerOptions();
            markerOpt1.SetPosition(latlng);
            markerOpt1.SetTitle("Title");
            GMap.AddMarker(markerOpt1);
        }
    }
}


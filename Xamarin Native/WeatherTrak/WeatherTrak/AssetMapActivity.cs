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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace CurrentLocation
{
    [Activity(Label = "Map")]
    public class AssetMapActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap GMap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AssetMap);

            SetUpMap();
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
            catch (Exception ex)
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

                LatLng latlng = new LatLng(MainActivity.latitude, MainActivity.longitude);
                CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
                GMap.MoveCamera(camera);

                GMap.MapClick += GMap_MapClick;

                MarkerOptions options = new MarkerOptions()
                            .SetPosition(latlng).SetSnippet(MainActivity.description)
                            .SetTitle(MainActivity.assetName);

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
            markerOpt1.SetSnippet("Description");
            GMap.AddMarker(markerOpt1);
        }
    }
}
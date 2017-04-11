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
using CurrentLocation.Models;
using CurrentLocation.MockData;

namespace CurrentLocation
{
    [Activity(Label = "Asset Management", MainLauncher = true, Icon = "@drawable/icon")]
    public class AssetMapActivity : Activity, IOnMapReadyCallback, GoogleMap.IInfoWindowAdapter
    {
        private GoogleMap GMap;
        private List<Marker> markerList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AssetMap);

            Spinner spinner = FindViewById<Spinner>(Resource.Id.maptype);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.maptype_array, Android.Resource.Layout.SimpleSpinnerItem);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            SetUpMap();

            Button btnResetMap = FindViewById<Button>(Resource.Id.btnResetMap);
            btnResetMap.Click += btnResetMap_Click;
        }

        private void btnResetMap_Click(object sender, EventArgs e)
        {
            GMap.Clear();
            
            GetMainMap();

            GMap.InfoWindowClick += GMap_InfoWindowClick;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            
            if (e.Position == 0)
                GMap.MapType = GoogleMap.MapTypeNormal;
            else if (e.Position == 1)
                GMap.MapType = GoogleMap.MapTypeSatellite;
            else if (e.Position == 2)
                GMap.MapType = GoogleMap.MapTypeHybrid;
            else if (e.Position == 3)
                GMap.MapType = GoogleMap.MapTypeTerrain;
            else
                GMap.MapType = GoogleMap.MapTypeSatellite;
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

        public void GetMainMap()
        {
            LatLngBounds.Builder builder = new LatLngBounds.Builder();
            List<LatLng> markers = new List<LatLng>();
                        
            AssetPositionsData positionsObj = new MockData.AssetPositionsData();
            List<MainAssetPositions> listAssetPositions = positionsObj.GetAssetPositonsData();

            for (int i = 0; i < listAssetPositions.Count; i++)
            {
                LatLng latlng1 = new LatLng(listAssetPositions[i].AssetLatitude, listAssetPositions[i].AssetLongitude);
                markers.Add(latlng1);

                MarkerOptions options1 = new MarkerOptions()
                            .SetPosition(latlng1).SetSnippet(listAssetPositions[i].Description)
                            .SetTitle(listAssetPositions[i].Title)
                            .SetIcon(BitmapDescriptorFactory.FromResource((int)typeof(Resource.Drawable).GetField(listAssetPositions[i].MarkerIcon).GetValue(null)));
                GMap.AddMarker(options1);

            }

            foreach (LatLng item in markers)
            {
                builder.Include(item);
            }
            if (markers.Count > 0)
            {
                LatLngBounds bounds = builder.Build();
                int width = Resources.DisplayMetrics.WidthPixels;//  600;
                int height = Resources.DisplayMetrics.HeightPixels;// 800;                
                int padding = (int)(width * 0.20);
                CameraUpdate camera = CameraUpdateFactory.NewLatLngBounds(bounds, width, height, padding);
                GMap.MoveCamera(camera);
            }
        }
        
        public void OnMapReady(GoogleMap googleMap)
        {
            try
            {
                this.GMap = googleMap;
                GMap.UiSettings.ZoomControlsEnabled = true;
                
                GMap.MapType = GoogleMap.MapTypeSatellite;
                //GMap.MapClick += GMap_MapClick;

                //
                GetMainMap();
                //

                GMap.InfoWindowClick += GMap_InfoWindowClick;

                GMap.SetInfoWindowAdapter(this);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }

        private void GMap_InfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            LatLngBounds.Builder builder = new LatLngBounds.Builder();
            List<LatLng> submarkers = new List<LatLng>();

            AssetPositionsData positionsObj = new MockData.AssetPositionsData();
            List<MainAssetPositions> listAssetPositions = positionsObj.GetAssetPositonsData();

            for (int i = 0; i < listAssetPositions.Count; i++)
            {
                if (e.Marker.Title == listAssetPositions[i].Title)
                {
                    GMap.Clear();
                    for (int j = 0; j < listAssetPositions[i].SubAssetList.Count; j++)
                    {
                        LatLng sublatlng = new LatLng(listAssetPositions[i].SubAssetList[j].SubAssetLatitude, listAssetPositions[i].SubAssetList[j].SubAssetLongitude);
                        //CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(sublatlng, 15);
                        //GMap.MoveCamera(camera);
                        submarkers.Add(sublatlng);
                        MarkerOptions suboptions = new MarkerOptions()
                                    .SetPosition(sublatlng).SetSnippet(listAssetPositions[i].SubAssetList[j].SubDescription)
                                    .SetTitle(listAssetPositions[i].SubAssetList[j].SubTitle)
                                    .SetIcon(BitmapDescriptorFactory.FromResource((int)typeof(Resource.Drawable).GetField(listAssetPositions[i].SubAssetList[j].SubMarkerIcon).GetValue(null)));                                    
                        GMap.AddMarker(suboptions);
                    }
                }
            }

            foreach (LatLng item in submarkers)
            {
                builder.Include(item);
            }
            if (submarkers.Count > 0)
            {
                LatLngBounds bounds = builder.Build();
                int width = Resources.DisplayMetrics.WidthPixels;//  600;
                int height = Resources.DisplayMetrics.HeightPixels;// 800;                
                int padding = (int)(width * 0.20);
                CameraUpdate camera = CameraUpdateFactory.NewLatLngBounds(bounds, width, height, padding);
                GMap.MoveCamera(camera);
            }

            
        }


        //private void GMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
        //{
        //    LatLng latlng = new LatLng(e.Point.Latitude, e.Point.Longitude);
        //    MarkerOptions markerOpt1 = new MarkerOptions();
        //    markerOpt1.SetPosition(latlng);
        //    markerOpt1.SetTitle("Title");
        //    markerOpt1.SetSnippet("Description");
        //    GMap.AddMarker(markerOpt1);
        //}


        public View GetInfoContents(Marker marker)
        {
            throw new NotImplementedException();
        }

        public View GetInfoWindow(Marker marker)
        {
            View view = LayoutInflater.Inflate(Resource.Layout.InfoWindow, null, false);
            view.FindViewById<TextView>(Resource.Id.SiteName).Text = "Allegator Park";
            view.FindViewById<TextView>(Resource.Id.TotalMetersNumber).Text = "2";
            view.FindViewById<TextView>(Resource.Id.TotalControllerNumbers).Text = "0";
            view.FindViewById<TextView>(Resource.Id.Lattitude).Text = "30.312455";
            view.FindViewById<TextView>(Resource.Id.Longitude).Text = "-97.755658";
            return view;
        }


    }
}
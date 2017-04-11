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
        private List<MainAssetPositions> listAssetPositions;
        private string SelectedMarker;

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

            AssetPositionsData positionsObj = new MockData.AssetPositionsData();
            listAssetPositions = positionsObj.GetAssetPositonsData();

            SetUpMap();

            Button btnResetMap = FindViewById<Button>(Resource.Id.btnResetMap);
            Button btnAddAssests = FindViewById<Button>(Resource.Id.btnAddAssets);
            Button btnGoToAssets = FindViewById<Button>(Resource.Id.btnGoToAssets);

            btnAddAssests.Click += BtnAddAssests_Click; 
            btnResetMap.Click += btnResetMap_Click;
            btnGoToAssets.Click += BtnGoToAssets_Click;
        }

        private void BtnGoToAssets_Click(object sender, EventArgs e)
        {
            LatLngBounds.Builder builder = new LatLngBounds.Builder();
            List<LatLng> submarkers = new List<LatLng>();

            //AssetPositionsData positionsObj = new MockData.AssetPositionsData();
            //List<MainAssetPositions> listAssetPositions = positionsObj.GetAssetPositonsData();

            for (int i = 0; i < listAssetPositions.Count; i++)
            {
                if (SelectedMarker == listAssetPositions[i].Title)
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

        private void BtnAddAssests_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void btnResetMap_Click(object sender, EventArgs e)
        {
            MainActivity.fromAddAsset = false;
            GMap.Clear();
            GMap.MapClick += GMap_MapClick;
            GetMainMap();
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            
            if (e.Position == 0)
                GMap.MapType = GoogleMap.MapTypeHybrid;
            else if (e.Position == 1)
                GMap.MapType = GoogleMap.MapTypeSatellite;
            else if (e.Position == 2)
                GMap.MapType = GoogleMap.MapTypeNormal;
            else if (e.Position == 3)
                GMap.MapType = GoogleMap.MapTypeTerrain;
            else
                GMap.MapType = GoogleMap.MapTypeHybrid;
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
            //GMap.MarkerClick += GMap_MarkerClick;  
            //AssetPositionsData positionsObj = new MockData.AssetPositionsData();
            //List<MainAssetPositions> listAssetPositions = positionsObj.GetAssetPositonsData();

            if (MainActivity.fromAddAsset)
            {
                LatLng latlng1 = new LatLng(MainActivity.latitude, MainActivity.longitude);
                markers.Add(latlng1);

                MarkerOptions options1 = new MarkerOptions()
                            .SetPosition(latlng1).SetSnippet(MainActivity.description)
                            .SetTitle(MainActivity.assetName)
                            .SetIcon(BitmapDescriptorFactory.FromResource((int)typeof(Resource.Drawable).GetField("SubAsset2").GetValue(null)));
                GMap.AddMarker(options1);
                MainActivity.fromAddAsset = false;
            }
            else
            {
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

        //private void GMap_MarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
        //{
        //    SelectedMarker = e.Marker.Title;
        //}

        public void GetSubMap(string currentTitle)
        {
            LatLngBounds.Builder builder = new LatLngBounds.Builder();
            List<LatLng> submarkers = new List<LatLng>();

            //AssetPositionsData positionsObj = new MockData.AssetPositionsData();
            //List<MainAssetPositions> listAssetPositions = positionsObj.GetAssetPositonsData();

            for (int i = 0; i < listAssetPositions.Count; i++)
            {
                if (currentTitle == listAssetPositions[i].Title)
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

        public void OnMapReady(GoogleMap googleMap)
        {
            try
            {
                this.GMap = googleMap;
                GMap.UiSettings.ZoomControlsEnabled = true;
                
                GMap.MapType = GoogleMap.MapTypeHybrid;
                //GMap.MapClick += GMap_MapClick;

                //
                GetMainMap();
                //
                GMap.MapClick += GMap_MapClick;
                GMap.SetInfoWindowAdapter(this);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }

        private void GMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            
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
            SelectedMarker = marker.Title;
            View view = LayoutInflater.Inflate(Resource.Layout.InfoWindow, null, false);
            view.FindViewById<TextView>(Resource.Id.SiteName).Text = marker.Title;
            view.FindViewById<TextView>(Resource.Id.TotalMetersNumber).Text = "2,504";
            //view.FindViewById<TextView>(Resource.Id.TotalControllerNumbers).Text = "0";
            view.FindViewById<TextView>(Resource.Id.Lattitude).Text = marker.Position.Latitude.ToString().Substring(0, 7);
            view.FindViewById<TextView>(Resource.Id.Longitude).Text = marker.Position.Longitude.ToString().Substring(0, 7); ;
            return view;
        }
                
    }
}
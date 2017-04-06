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
using Android.Gms.Location;
using Android.Gms.Common.Apis;
using Android.Gms.Common;
using Java.IO;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using Android.Provider;
using Android.Graphics;
using Android.Content.PM;
using CurrentLocation;

namespace CurrentLocation
{
    [Activity(Label = "Add Asset", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, GoogleApiClient.IConnectionCallbacks,
        GoogleApiClient.IOnConnectionFailedListener, Android.Gms.Location.ILocationListener
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

        private ImageView _imageView;

        GoogleApiClient apiClient;
        LocationRequest locRequest;
        bool _isGooglePlayServicesInstalled;

        public string TAG { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Spinner spinner = FindViewById<Spinner>(Resource.Id.assettype);

            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.assets_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            txtlatitu = FindViewById<TextView>(Resource.Id.gpslatitude);
            txtlong = FindViewById<TextView>(Resource.Id.gpslongitude);
            assetNameTxt = FindViewById<TextView>(Resource.Id.assetname);
            descriptionTxt = FindViewById<TextView>(Resource.Id.description);
            identifierText = FindViewById<TextView>(Resource.Id.identifier);
            // Check Weather there is app to take image.
            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();
                Button Camera = FindViewById<Button>(Resource.Id.btnCamera);
                _imageView = FindViewById<ImageView>(Resource.Id.imageView1);
                Camera.Click += Camera_Click;
                _imageView.Click += _imageView_Click;
            }
            else
            {
                Log.Error("Camera", "No Camera found!!! ");
            }


            Button btnWatchMap = FindViewById<Button>(Resource.Id.watchOnMap);
            btnWatchMap.Click += BtnWatchMap_Click;

            Switch togglebutton = FindViewById<Switch>(Resource.Id.togglebutton);
            togglebutton.Click += async delegate {
                if (((Switch)togglebutton).Checked)
                {
                    txtlatitu.Enabled = false;
                    txtlatitu.Enabled = false;

                    if (apiClient.IsConnected)
                    {
                        // Setting location priority to PRIORITY_HIGH_ACCURACY (100)
                        locRequest.SetPriority(100);

                        // Setting interval between updates, in milliseconds
                        // NOTE: the default FastestInterval is 1 minute. If you want to receive location updates more than 
                        // once a minute, you _must_ also change the FastestInterval to be less than or equal to your Interval
                        locRequest.SetFastestInterval(500);
                        locRequest.SetInterval(1000);

                        Log.Debug("LocationRequest", "Request priority set to status code {0}, interval set to {1} ms",
                            locRequest.Priority.ToString(), locRequest.Interval.ToString());

                        // pass in a location request and LocationListener
                        await LocationServices.FusedLocationApi.RequestLocationUpdates(apiClient, locRequest, this);
                        // In OnLocationChanged (below), we will make calls to update the UI
                        // with the new location data
                    }
                    else
                    {
                        Toast.MakeText(this, "Please wait for the GoogleAPIClient to connect", ToastLength.Long).Show();
                        ((Switch)togglebutton).Checked = false;
                    }
                }
                else
                {
                    txtlatitu.Enabled = true;
                    txtlatitu.Enabled = true;
                }
            };

            _isGooglePlayServicesInstalled = IsGooglePlayServicesInstalled();

            if (_isGooglePlayServicesInstalled)
            {
                // pass in the Context, ConnectionListener and ConnectionFailedListener
                apiClient = new GoogleApiClient.Builder(this, this, this)
                    .AddApi(LocationServices.API).Build();

                // generate a location request that we will pass into a call for location updates
                locRequest = new LocationRequest();

            }
            else
            {
                Log.Error("OnCreate", "Google Play Services is not installed");
                Toast.MakeText(this, "Google Play Services is not installed", ToastLength.Long).Show();
                Finish();
            }
        }
        // Method to open Gallary on image click 
        private void _imageView_Click(object sender, EventArgs e) 
        {
            Uri contentUri = Uri.FromFile(App._file);
            Intent intent = new Intent();
            intent.SetAction(Intent.ActionView);
            intent.SetDataAndType(contentUri, "image/*");
            StartActivity(intent);
        }

        private void Camera_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            App._file = new File(App._dir, String.Format("Hydro_{0}.jpg", Guid.NewGuid()));

            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));

            StartActivityForResult(intent, 0);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(App._file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display
            // Loading the full sized image will consume to much memory 
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = _imageView.Height;
            App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height);
            if (App.bitmap != null)
            {
                _imageView.SetImageBitmap(App.bitmap);
                App.bitmap = null;
            }

            // Dispose of the Java side bitmap.
            GC.Collect();
        }
        bool IsGooglePlayServicesInstalled()
        {
            int queryResult = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (queryResult == ConnectionResult.Success)
            {
                Log.Info("MainActivity", "Google Play Services is installed on this device.");
                return true;
            }

            if (GoogleApiAvailability.Instance.IsUserResolvableError(queryResult))
            {
                string errorString = GoogleApiAvailability.Instance.GetErrorString(queryResult);
                Log.Error("ManActivity", "There is a problem with Google Play Services on this device: {0} - {1}", queryResult, errorString);

                // Show error dialog to let user debug google play services
            }
            return false;
        }

        private void BtnWatchMap_Click(object sender, EventArgs e)
        {
            latitude = Convert.ToDouble(txtlatitu.Text);
            longitude = Convert.ToDouble(txtlong.Text);
            assetName = assetNameTxt.Text;
            description = descriptionTxt.Text;
            StartActivity(typeof(AssetMapActivity));
        }

        public void OnLocationChanged(Location location)
        {
            if (location != null)
            {
                txtlatitu.Text = location.Latitude.ToString();
                txtlong.Text = location.Longitude.ToString();
            }
        }

        
		protected override void OnResume()
		{
			base.OnResume ();
			Log.Debug ("OnResume", "OnResume called, connecting to client...");

			apiClient.Connect();

			//// Clicking the first button will make a one-time call to get the user's last location
			//button.Click += delegate {
			//	if (apiClient.IsConnected)
			//	{
			//		button.Text = "Getting Last Location";

			//		Location location = LocationServices.FusedLocationApi.GetLastLocation (apiClient);
			//		if (location != null)
			//		{
			//			latitude.Text = "Latitude: " + location.Latitude.ToString();
			//			longitude.Text = "Longitude: " + location.Longitude.ToString();
			//			provider.Text = "Provider: " + location.Provider.ToString();
			//			Log.Debug ("LocationClient", "Last location printed");
			//		}
			//	}
			//	else
			//	{
			//		Log.Info ("LocationClient", "Please wait for client to connect");
			//	}
			//};

			//// Clicking the second button will send a request for continuous updates
			//button2.Click += async delegate {
			//	if (apiClient.IsConnected)
			//	{
			//		button2.Text = "Requesting Location Updates";

			//		// Setting location priority to PRIORITY_HIGH_ACCURACY (100)
			//		locRequest.SetPriority(100);

			//		// Setting interval between updates, in milliseconds
			//		// NOTE: the default FastestInterval is 1 minute. If you want to receive location updates more than 
			//		// once a minute, you _must_ also change the FastestInterval to be less than or equal to your Interval
			//		locRequest.SetFastestInterval(500);
			//		locRequest.SetInterval(1000);

			//		Log.Debug("LocationRequest", "Request priority set to status code {0}, interval set to {1} ms", 
			//			locRequest.Priority.ToString(), locRequest.Interval.ToString());

			//		// pass in a location request and LocationListener
			//		await LocationServices.FusedLocationApi.RequestLocationUpdates (apiClient, locRequest, this);
			//		// In OnLocationChanged (below), we will make calls to update the UI
			//		// with the new location data
			//	}
			//	else
			//	{
			//		Log.Info("LocationClient", "Please wait for Client to connect");
			//	}
			//};
		}

		protected override async void OnPause ()
		{
			base.OnPause ();
			Log.Debug ("OnPause", "OnPause called, stopping location updates");

			if (apiClient.IsConnected) {
				// stop location updates, passing in the LocationListener
				await LocationServices.FusedLocationApi.RemoveLocationUpdates (apiClient, this);

				apiClient.Disconnect ();
			}
		}
        ////Interface methods

        public void OnConnected(Bundle bundle)
        {
            // This method is called when we connect to the LocationClient. We can start location updated directly form
            // here if desired, or we can do it in a lifecycle method, as shown above 

            // You must implement this to implement the IGooglePlayServicesClientConnectionCallbacks Interface
            Log.Info("LocationClient", "Now connected to client");
        }

        public void OnDisconnected()
        {
            // This method is called when we disconnect from the LocationClient.

            // You must implement this to implement the IGooglePlayServicesClientConnectionCallbacks Interface
            Log.Info("LocationClient", "Now disconnected from client");
        }

        public void OnConnectionFailed(ConnectionResult bundle)
        {
            // This method is used to handle connection issues with the Google Play Services Client (LocationClient). 
            // You can check if the connection has a resolution (bundle.HasResolution) and attempt to resolve it

            // You must implement this to implement the IGooglePlayServicesClientOnConnectionFailedListener Interface
            Log.Info("LocationClient", "Connection failed, attempting to reach google play services");
        }

        public void OnConnectionSuspended(int i)
        {

        }
        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }
        private void CreateDirectoryForPictures()
        {
            App._dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "HydroPoint");
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }
    }
    public static class App
    {
        public static File _file;
        public static File _dir;
        public static Bitmap bitmap;
    }
}


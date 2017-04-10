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

namespace CurrentLocation.Models
{
    public class SubAssetPositions
    {
        public string SubTitle { get; set; }
        public string SubDescription { get; set; }        
        public double SubAssetLatitude { get; set; }
        public double SubAssetLongitude { get; set; }
        public string SubMarkerIcon { get; set; }
    }
}
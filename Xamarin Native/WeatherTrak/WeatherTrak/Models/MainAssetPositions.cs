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
    public class MainAssetPositions
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double AssetLatitude { get; set; }
        public double AssetLongitude { get; set; }
        public string MarkerIcon { get; set; }
        public List<SubAssetPositions> SubAssetList { get; set; }
    }
}
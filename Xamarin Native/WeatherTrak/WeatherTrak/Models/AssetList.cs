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
    public class AssetList
    {
        public int AssetCategoryID { get; set; }
        public string AssetCategoryName { get; set; }
        public List<Assets> ListAssets { get; set; }
    }
}
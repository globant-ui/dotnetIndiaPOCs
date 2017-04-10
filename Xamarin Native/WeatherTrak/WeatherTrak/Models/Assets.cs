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
    public class Assets
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string AssetAcronym { get; set; }
        public string AssetImage { get; set; }
    }
}
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
using CurrentLocation.Models;

namespace CurrentLocation.MockData
{
    public class AssetMockData
    {
        public List<AssetList> GetAssetData()
        {
            List<AssetList> listAssets = new List<AssetList>
            {
                new AssetList { AssetCategoryID=1, AssetCategoryName="Water Meters",
                    ListAssets =  new List<Assets> { new Assets { AssetId = 1, AssetName = "Commercial Bldg WM", AssetAcronym = "WM1", AssetImage="icon1" } } },
                new AssetList { AssetCategoryID=2, AssetCategoryName="Controllers",
                    ListAssets =  new List<Assets> { new Assets { AssetId = 1, AssetName = "09006268-Pro3-Austin, TX", AssetAcronym = "C1", AssetImage = "icon2" }, new Assets { AssetId = 2, AssetName = "09006269-Pro2-Austin, TX", AssetAcronym = "C2", AssetImage = "icon3" } } },
                new AssetList { AssetCategoryID=3, AssetCategoryName="Irrigation Control",
                    ListAssets =  new List<Assets> { new Assets { AssetId = 1, AssetName = "Irrigation Station 1", AssetAcronym = "V1", AssetImage = "icon4" }, new Assets { AssetId = 2, AssetName = "Irrigation Station 2", AssetAcronym = "V2", AssetImage = "icon5" } } },
                new AssetList { AssetCategoryID=4, AssetCategoryName="Wiring",
                    ListAssets =  new List<Assets> { new Assets { AssetId = 1, AssetName = "Spice Box", AssetAcronym = "SB1", AssetImage = "icon6" }, new Assets { AssetId = 2, AssetName = "Spice Box 2", AssetAcronym = "SB2", AssetImage = "icon7" } } }
            };

            return listAssets;
        }
    }
}
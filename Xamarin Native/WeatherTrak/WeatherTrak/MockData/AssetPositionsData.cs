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
    public class AssetPositionsData
    {
        public List<MainAssetPositions> GetAssetPositonsData()
        {
            List<MainAssetPositions> listAssetPositions = new List<MainAssetPositions>
            {
                
                  new MainAssetPositions { Title= "Swimming Pool", Description="Swimming Pool Description", AssetLatitude = 33.5803697433984, AssetLongitude=-117.850236184895, MarkerIcon = "AssetMarker",
                    SubAssetList =  new List<SubAssetPositions> { new SubAssetPositions { SubTitle="SP1", SubDescription = "SP1 Description", SubAssetLatitude = 33.587023, SubAssetLongitude = -117.844525, SubMarkerIcon = "SubAsset1" }, new SubAssetPositions { SubTitle = "SP2", SubDescription = "SP2 Description", SubAssetLatitude = 33.586975, SubAssetLongitude = -117.84412, SubMarkerIcon = "SubAsset1" }, new SubAssetPositions { SubTitle = "SP3", SubDescription = "SP3 Description", SubAssetLatitude = 33.586395, SubAssetLongitude = -117.843899, SubMarkerIcon = "SubAsset2" }, new SubAssetPositions { SubTitle = "SP4", SubDescription = "SP4 Description", SubAssetLatitude = 33.586842, SubAssetLongitude = -117.843646, SubMarkerIcon = "SubAsset2" }, new SubAssetPositions { SubTitle = "SP5", SubDescription = "SP5 Description", SubAssetLatitude = 33.586828, SubAssetLongitude = -117.843496, SubMarkerIcon = "SubAsset3" }, new SubAssetPositions { SubTitle = "SP6", SubDescription = "SP6 Description", SubAssetLatitude = 33.586577, SubAssetLongitude = -117.843478, SubMarkerIcon = "SubAsset3" } } },
                 new MainAssetPositions { Title= "Backflow Preventer", Description="Backflow Preventer Description", AssetLatitude = 33.5923976345246, AssetLongitude=-117.85055167973, MarkerIcon = "AssetMarker",
                    SubAssetList =  new List<SubAssetPositions> { new SubAssetPositions { SubTitle="BP1", SubDescription = "BP1 Description", SubAssetLatitude = 33.587570, SubAssetLongitude = -117.843463, SubMarkerIcon = "SubAsset1" }, new SubAssetPositions { SubTitle = "BP2", SubDescription = "BP2 Description", SubAssetLatitude = 33.587656, SubAssetLongitude = -117.843305, SubMarkerIcon = "SubAsset1" }, new SubAssetPositions { SubTitle = "BP3", SubDescription = "BP3 Description", SubAssetLatitude = 33.586411, SubAssetLongitude = -117.842934, SubMarkerIcon = "SubAsset2" }, new SubAssetPositions { SubTitle = "BP4", SubDescription = "BP4 Description", SubAssetLatitude = 33.587142, SubAssetLongitude = -117.842985, SubMarkerIcon = "SubAsset2" }, new SubAssetPositions { SubTitle = "BP5", SubDescription = "BP5 Description", SubAssetLatitude = 33.585947, SubAssetLongitude = -117.843516, SubMarkerIcon = "SubAsset3" } } },
                new MainAssetPositions { Title= "Hose Bib", Description="Hose Bib Description", AssetLatitude = 33.5909283129719, AssetLongitude=-117.841673567891, MarkerIcon = "AssetMarker",
                    SubAssetList =  new List<SubAssetPositions> { new SubAssetPositions { SubTitle="HB1", SubDescription = "HB1 Description", SubAssetLatitude = 33.587557, SubAssetLongitude = -117.841321, SubMarkerIcon = "SubAsset1" }, new SubAssetPositions { SubTitle = "HB2", SubDescription = "HB2 Description", SubAssetLatitude = 33.587330, SubAssetLongitude = -117.843728, SubMarkerIcon = "SubAsset1" }, new SubAssetPositions { SubTitle = "HB3", SubDescription = "HB3 Description", SubAssetLatitude = 33.587006, SubAssetLongitude = -117.841852, SubMarkerIcon = "SubAsset2" }, new SubAssetPositions { SubTitle = "HB4", SubDescription = "HB4 Description", SubAssetLatitude = 33.586395, SubAssetLongitude = -117.843899, SubMarkerIcon = "SubAsset2" }, new SubAssetPositions { SubTitle = "HB5", SubDescription = "HB5 Description", SubAssetLatitude = 33.587023, SubAssetLongitude = -117.844525, SubMarkerIcon = "SubAsset3" }, new SubAssetPositions { SubTitle = "HB6", SubDescription = "HB6 Description", SubAssetLatitude = 33.586979, SubAssetLongitude = -117.843310, SubMarkerIcon = "SubAsset3" } } },
                new MainAssetPositions { Title= "Point of Connection", Description="Point of Connection Description", AssetLatitude = 33.5797239481502, AssetLongitude=-117.841530069709, MarkerIcon = "AssetMarker",
                    SubAssetList =  new List<SubAssetPositions> { new SubAssetPositions { SubTitle="POC1", SubDescription = "POC1 Description", SubAssetLatitude = 33.586688, SubAssetLongitude = -117.842564, SubMarkerIcon = "SubAsset1" }, new SubAssetPositions { SubTitle = "POC2", SubDescription = "POC2 Description", SubAssetLatitude = 33.586882, SubAssetLongitude = -117.842862, SubMarkerIcon = "SubAsset1" }, new SubAssetPositions { SubTitle = "POC3", SubDescription = "POC3 Description", SubAssetLatitude = 33.586951, SubAssetLongitude = -117.842940, SubMarkerIcon = "SubAsset2" }, new SubAssetPositions { SubTitle = "POC4", SubDescription = "POC4 Description", SubAssetLatitude = 33.586889, SubAssetLongitude = -117.843693, SubMarkerIcon = "SubAsset2" }, new SubAssetPositions { SubTitle = "POC5", SubDescription = "POC5 Description", SubAssetLatitude = 33.587090, SubAssetLongitude = -117.843750, SubMarkerIcon = "SubAsset3" }, new SubAssetPositions { SubTitle = "POC6", SubDescription = "POC6 Description", SubAssetLatitude = 33.586088, SubAssetLongitude = -117.841798, SubMarkerIcon = "SubAsset3" } } },
                 new MainAssetPositions { Title= "Quick Coupler", Description="Quick Coupler Description", AssetLatitude = 33.5872251541595, AssetLongitude=-117.835262082517, MarkerIcon = "AssetMarker",
                    SubAssetList =  new List<SubAssetPositions> { new SubAssetPositions { SubTitle="QC1", SubDescription = "QC1 Description", SubAssetLatitude = 33.587670, SubAssetLongitude = -117.841699, SubMarkerIcon = "SubAsset1" }, new SubAssetPositions { SubTitle = "QC2", SubDescription = "QC2 Description", SubAssetLatitude = 33.587632, SubAssetLongitude = -117.842103, SubMarkerIcon = "SubAsset1" }, new SubAssetPositions { SubTitle = "QC3", SubDescription = "QC3 Description", SubAssetLatitude = 33.586791, SubAssetLongitude = -117.841443, SubMarkerIcon = "SubAsset2" }, new SubAssetPositions { SubTitle = "QC4", SubDescription = "QC4 Description", SubAssetLatitude = 33.586460, SubAssetLongitude = -117.842017, SubMarkerIcon = "SubAsset2" }, new SubAssetPositions { SubTitle = "QC5", SubDescription = "QC5 Description", SubAssetLatitude = 33.586897, SubAssetLongitude = -117.842160, SubMarkerIcon = "SubAsset3" } } },


            };
            return listAssetPositions;
        }
    }
}
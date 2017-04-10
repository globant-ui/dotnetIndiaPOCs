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
using CurrentLocation.MockData;
using CurrentLocation.Models;

namespace CurrentLocation
{
    [Activity(Label = "Asset List")]
    public class AssetListActivity : Activity
    {
        ExpandableListAdapter listAdapter;
        ExpandableListView expListView;
        List<string> listDataHeader;
        Dictionary<string, List<string>> listDataChild;

        Dictionary<string, List<string>> listDataChildImage;

        int previousGroup = -1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AssetList);

            //Simple List
            //LinearLayout layout1 = (LinearLayout) FindViewById(Resource.Id.layOutAssetList);
            //LinearLayout.LayoutParams parameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);

            //AssetMockData obj = new MockData.AssetMockData();
            //List<AssetList> listAssetsData = obj.GetAssetData();
            //for(int i = 0; i < listAssetsData.Count; i++)
            //{
            //    TextView lblAssetCategoryName = new TextView(this);
            //    lblAssetCategoryName.Text = listAssetsData[i].AssetCategoryName;
            //    layout1.AddView(lblAssetCategoryName);

            //    ListView listViewAssets = new ListView(this);

            //    List<string> AssetNames = new List<string>();
            //    for(int j=0;j<listAssetsData[i].ListAssets.Count;j++)
            //    {
            //        AssetNames.Add(listAssetsData[i].ListAssets[j].AssetName);
            //    }
            //    ArrayAdapter arrAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, AssetNames);
            //    listViewAssets.Adapter = arrAdapter;
            //    layout1.AddView(listViewAssets);
            //}
            //End - Simple List


            expListView = FindViewById<ExpandableListView>(Resource.Id.lvExp);

            // Prepare list data
            FnGetListData();

            


            //

            //Bind list
            //listAdapter = new ExpandableListAdapter(this, listDataHeader, listDataChild);
            listAdapter = new ExpandableListAdapter(this, listDataHeader, listDataChild, listDataChildImage);
            expListView.SetAdapter(listAdapter);

            //Make all groups expanded by default
            for (int i = 0; i < listDataHeader.Count; i++)
                expListView.ExpandGroup(i);

            FnClickEvents();


            
        }

        

        void FnClickEvents()
        {
            //Listening to child item selection
            ////expListView.ChildClick += delegate (object sender, ExpandableListView.ChildClickEventArgs e) {
            ////    Toast.MakeText(this, "child clicked", ToastLength.Short).Show();
            ////};

            //Listening to group expand
            //modified so that on selection of one group other opened group has been closed
            ////expListView.GroupExpand += delegate (object sender, ExpandableListView.GroupExpandEventArgs e) {

            ////    if (e.GroupPosition != previousGroup)
            ////        expListView.CollapseGroup(previousGroup);
            ////    previousGroup = e.GroupPosition;
            ////};

            //Listening to group collapse
            ////expListView.GroupCollapse += delegate (object sender, ExpandableListView.GroupCollapseEventArgs e) {
            ////    Toast.MakeText(this, "group collapsed", ToastLength.Short).Show();
            ////};

        }
        void FnGetListData()
        {

            AssetMockData obj = new MockData.AssetMockData();
            List<AssetList> listAssetsData = obj.GetAssetData();


            listDataHeader = new List<string>();
            listDataChild = new Dictionary<string, List<string>>();
            listDataChildImage = new Dictionary<string, List<string>>();

            // Adding child data
            for (int i = 0; i < listAssetsData.Count; i++)
            {
                List<string> lstAssetItems = new List<string>();
                List<string> lstAssetItemsImage = new List<string>();
                for (int j = 0; j < listAssetsData[i].ListAssets.Count; j++)
                {
                    lstAssetItems.Add(listAssetsData[i].ListAssets[j].AssetName);
                    lstAssetItemsImage.Add(listAssetsData[i].ListAssets[j].AssetImage);
                }
                listDataHeader.Add(listAssetsData[i].AssetCategoryName);
                listDataChild.Add(listAssetsData[i].AssetCategoryName, lstAssetItems);
                listDataChildImage.Add(listAssetsData[i].AssetCategoryName, lstAssetItemsImage);
            }
            
        }

    }



}
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

namespace CurrentLocation
{
    public class ExpandableListAdapter : BaseExpandableListAdapter
    {
        private Activity _context;
        private List<string> _listDataHeader; // header titles
                                              // child data in format of header title, child title
        private Dictionary<string, List<string>> _listDataChild;
        private Dictionary<String, List<string>> _listDataChildImage;

        public ExpandableListAdapter(Activity context, List<string> listDataHeader, Dictionary<String, List<string>> listChildData, Dictionary<String, List<string>> listChildImage)
        {
            _context = context;
            _listDataHeader = listDataHeader;
            _listDataChild = listChildData;
            _listDataChildImage = listChildImage;
        }
        //for cchild item view
        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return _listDataChild[_listDataHeader[groupPosition]][childPosition];
        }
               
        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            string childText = (string)GetChild(groupPosition, childPosition);
            if (convertView == null)
            {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.AssetListItems, null);
            }
            TextView txtListChild = (TextView)convertView.FindViewById(Resource.Id.lblListItem);
            txtListChild.Text = childText;

            ImageView imgViewChild = (ImageView)convertView.FindViewById(Resource.Id.imgItem);
            string imgName = _listDataChildImage[_listDataHeader[groupPosition]][childPosition];
            var imgId = (int)typeof(Resource.Drawable).GetField(imgName).GetValue(null);
            imgViewChild.SetImageResource(imgId);

            return convertView;
        }
        public override int GetChildrenCount(int groupPosition)
        {
            return _listDataChild[_listDataHeader[groupPosition]].Count;
        }
        //For header view
        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return _listDataHeader[groupPosition];
        }
        public override int GroupCount
        {
            get
            {
                return _listDataHeader.Count;
            }
        }
        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }
        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            string headerTitle = (string)GetGroup(groupPosition);

            convertView = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.AssetListHeader, null);
            var lblListHeader = (TextView)convertView.FindViewById(Resource.Id.lblListHeader);
            lblListHeader.Text = headerTitle;

            return convertView;
        }
        public override bool HasStableIds
        {
            get
            {
                return false;
            }
        }
        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        class ViewHolderItem : Java.Lang.Object
        {
        }
    }
}
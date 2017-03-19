using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using LearnNewLanguageDroid.Models;
using Object = Java.Lang.Object;

namespace LearnNewLanguageDroid.Views
{
    public class SelectCharactersAdapter : BaseExpandableListAdapter
    {
        public LayoutInflater Inflater { get; set; }
        private readonly List<SelectedCharactersGroup> _groups;


        public SelectCharactersAdapter(List<SelectedCharactersGroup> groups)
        {
            _groups = groups;
        }

        public override Object GetChild(int groupPosition, int childPosition)
        {
            return _groups[groupPosition].Characters[childPosition];
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return _groups[groupPosition].Characters.Count;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            var headerTitle = (SelectedCharacter)GetChild(groupPosition, childPosition);
            if (convertView == null)
            {
                convertView = Inflater.Inflate(Resource.Layout.item_select_character, null);
            }

            var lblListHeader = convertView
                    .FindViewById<CheckBox>(Resource.Id.characterChk);
            lblListHeader.SetTypeface(null, TypefaceStyle.Bold);
            lblListHeader.Text = headerTitle.Symbol.ToString();
            lblListHeader.SetOnCheckedChangeListener(new CheckedChangedEventHandler(headerTitle));
            lblListHeader.Checked = headerTitle.Selected;

            return convertView;
        }

        public override Object GetGroup(int groupPosition)
        {
            return _groups[groupPosition];
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            var headerTitle = (SelectedCharactersGroup)GetGroup(groupPosition);
            if (convertView == null)
            {
                convertView = Inflater.Inflate(Resource.Layout.group_select_character, null);
            }

            var lblListHeader = convertView
                    .FindViewById<TextView>(Resource.Id.lblListHeader);
            lblListHeader.SetTypeface(null, TypefaceStyle.Bold);
            lblListHeader.Text = headerTitle.GroupName;

            return convertView;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        public override int GroupCount
        {
            get { return _groups.Count; }
        }

        public override bool HasStableIds
        {
            get { return true; }
        }

        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            
        }
    }
    public class CheckedChangedEventHandler : Java.Lang.Object, CompoundButton.IOnCheckedChangeListener
    {
        private readonly SelectedCharacter _character;

        public CheckedChangedEventHandler(SelectedCharacter character)
        {
            _character = character;
        }

        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            _character.Selected = isChecked;
        }
    }
}
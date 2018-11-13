﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using ProAuth.Fragments;
using ProAuth.Utilities;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ProAuth.Activities
{
    [Activity(Label = "SettingsActivity")]
    public class ActivitySettings : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ThemeHelper.Update(this);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activitySettings);
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.activitySettings_toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetTitle(Resource.String.settings);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Icons.GetIcon("arrow_back"));

            SupportFragmentManager.BeginTransaction()
                                  .Replace(Resource.Id.activitySettings_content, new FragmentSettings())
                                  .Commit();
        }

        public override bool OnSupportNavigateUp()
        {
            Finish();
            return base.OnSupportNavigateUp();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if(item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            Finish();
            base.OnBackPressed();
        }
    }
}
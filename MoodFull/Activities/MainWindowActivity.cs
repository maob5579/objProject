using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using MoodFull.Fragments;

namespace MoodFull.Activities
{
    [Activity(Label = "MoodFull")]
    public class MainWindowActivity : AppCompatActivity
    {
        private DrawerLayout _drawer;
        private ListView _drawerList;

        private static readonly string[] Sections = new[]
        {
            "Rate restaurant", "Rated restaurants"
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.content_main);

            _drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _drawerList = FindViewById<ListView>(Resource.Id.left_drawer);

            _drawerList.Adapter = new ArrayAdapter<string>(this, Resource.Layout.item_menu, Sections);
            _drawerList.ItemClick += DrawerListOnItemClick;

            Permission.TryToGetCameraPermissions(this);
        }

        //When item on navigation menu is clicked
        private void DrawerListOnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.Support.V4.App.Fragment fragment = null;

            switch (e.Position)
            {
                case 0:
                    fragment = new RateFragment();
                    break;
                case 1:
                    fragment = new RatedRestaurantsFragment();
                    break;
            }

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();

            _drawerList.SetItemChecked(e.Position, true);
            _drawer.CloseDrawer(_drawerList);
        }
    }
}
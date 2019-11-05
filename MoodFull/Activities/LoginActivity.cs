using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MoodFull.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class LoginActivity : AppCompatActivity
    {
        private Button _button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _button = FindViewById<Button>(Resource.Id.loginButton);

            _button.Click += delegate
            {
                HandleLogin();
            };
        }

        private void HandleLogin()
        {
            Toast.MakeText(this, "Hello", ToastLength.Long).Show();
            StartActivity(typeof(Activities.MainWindowActivity));
        }
    }
}
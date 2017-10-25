﻿namespace Catel.Examples.Xamarin.Forms.MasterDetail.Droid
{
    using System;
    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using global::Xamarin.Forms;
    using global::Xamarin.Forms.Platform.Android;

    [Activity(Label = "Catel.Examples.Xamarin.Forms.MasterDetail.Droid", Theme = "@style/MyTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}
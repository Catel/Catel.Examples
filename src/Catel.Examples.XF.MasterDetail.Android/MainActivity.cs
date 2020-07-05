// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainActivity.cs" company="Catel development team">
//   Copyright (c) 2008 - 2018 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Xamarin.Forms.MasterDetail.Droid
{
    using global::Android.App;
    using global::Android.Content.PM;
    using global::Android.OS;
    using global::Xamarin.Forms;
    using global::Xamarin.Forms.Platform.Android;

    [Activity(Label = "Catel.Examples.Xamarin.Forms.MasterDetail.Droid", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        #region Methods
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            LoadApplication(new App());
        }
        #endregion
    }
}

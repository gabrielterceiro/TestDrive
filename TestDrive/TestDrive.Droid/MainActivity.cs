using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TestDrive.Media;
using TestDrive.Droid;
using Xamarin.Forms;
using Android.Content;
using Android.Provider;

[assembly: Xamarin.Forms.Dependency(typeof (MainActivity))]
namespace TestDrive.Droid
{
    [Activity(Label = "TestDrive", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : 
        global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
        , ICamera
    {
        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            var activity = Forms.Context as Activity;
            activity.StartActivityForResult(intent, 0);
        }
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new TestDrive.App());
        }
    }
}


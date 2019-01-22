using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using ClaimIt.UI;
using MvvmCross.Forms.Platforms.Android.Views;

namespace ClaimIt.Droid
{
    [Activity(
        Label = "ClaimIt"
        , MainLauncher = true
        , Icon = "@mipmap/icon"
        , Theme = "@style/MainTheme"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : MvxFormsSplashScreenAppCompatActivity<Setup, CoreApp, App>
    {
        public SplashActivity() : base(Resource.Layout.SplashScreen)
        {

        }

        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));
            return Task.CompletedTask;
        }
    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ClaimIt.UI
{
    public partial class App : Application
    {

        public App()
        {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjM1MDFAMzEzNjJlMzQyZTMwaGEwNjZYZEg2dUZ2UGRRK1N0OVliczdFUTNYcHFhaGF3akxaTUZBZFhZOD0=");
            InitializeComponent();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

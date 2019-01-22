using System;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using ClaimIt.Droid.Presenter;
using MvvmCross;
using MvvmCross.Forms.Presenters;
using ClaimIt.UI;

namespace ClaimIt.Droid
{
    public class Setup : MvxFormsAndroidSetup<CoreApp, App>
    {
        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new AndroidCustomPresenter(this.GetViewAssemblies(), this.FormsApplication);
            Mvx.IoCProvider.RegisterSingleton<IMvxFormsViewPresenter>(presenter);
            return presenter;
        }
    }
}

using System;
using ClaimIt.UI;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using ClaimIt.iOS.Presenter;
using MvvmCross;
using MvvmCross.Forms.Presenters;

namespace ClaimIt.iOS
{
    public class Setup : MvxFormsIosSetup<CoreApp, App>
    {
        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            var presenter = new IosCustomPresenter(this.ApplicationDelegate, this.Window, this.FormsApplication);
            Mvx.IoCProvider.RegisterSingleton<IMvxFormsViewPresenter>(presenter);
            return presenter;
        }

    }
}

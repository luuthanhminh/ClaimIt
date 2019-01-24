using System;
using MvvmCross.Forms.Views;
using ClaimIt.Core.ViewModels;
using Xamarin.Forms;
using MvvmCross.ViewModels;

namespace ClaimIt.UI.Pages
{
    public class BasePage<TViewModel> : MvxContentPage<TViewModel> where TViewModel : MvxViewModel
    {
        public BasePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}

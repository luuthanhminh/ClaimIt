using System;
using MvvmCross.Forms.Views;
using ClaimIt.Core.ViewModels;
using Xamarin.Forms;

namespace ClaimIt.UI.Pages
{
    public class BasePage<TViewModel> : MvxContentPage<TViewModel> where TViewModel : BaseViewModel
    {
        public BasePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}

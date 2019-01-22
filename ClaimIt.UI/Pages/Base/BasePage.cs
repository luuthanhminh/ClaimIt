using System;
using MvvmCross.Forms.Views;
using ClaimIt.Core.ViewModels;

namespace ClaimIt.UI.Pages
{
    public class BasePage<TViewModel> : MvxContentPage<TViewModel> where TViewModel : BaseViewModel
    {

    }
}

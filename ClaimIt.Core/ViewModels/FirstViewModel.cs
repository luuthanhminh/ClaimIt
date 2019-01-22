using System;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
namespace ClaimIt.Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public FirstViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
        }
    }
}

using System;
using ClaimIt.Core.Services;
using MvvmCross.Navigation;

namespace ClaimIt.Core.ViewModels
{
    public class SignatureViewModel : BaseViewModel
    {
        public SignatureViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }
    }
}

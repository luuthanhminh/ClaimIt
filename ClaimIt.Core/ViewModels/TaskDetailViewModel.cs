using System;
using ClaimIt.Core.Services;
using MvvmCross.Navigation;

namespace ClaimIt.Core.ViewModels
{
    public class TaskDetailViewModel : BaseViewModel
    {
        public TaskDetailViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }
    }
}

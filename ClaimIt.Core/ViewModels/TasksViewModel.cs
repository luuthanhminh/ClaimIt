using System;
using ClaimIt.Core.Services;
using MvvmCross.Navigation;

namespace ClaimIt.Core.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        public TasksViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

    }
}

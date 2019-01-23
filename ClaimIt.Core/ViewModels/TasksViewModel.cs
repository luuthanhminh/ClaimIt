using System;
using MvvmCross.Navigation;

namespace ClaimIt.Core.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        public TasksViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
        }
    }
}

using System;
using ClaimIt.Core.Services;
using MvvmCross.Navigation;

namespace ClaimIt.Core.ViewModels
{
    public class TasksViewModel : BaseWithObjectViewModel<string>
    {

        private string _participantId;

        public TasksViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        #region Overrides

        public override void Prepare(string id)
        {
            this._participantId = id;
        }


        #endregion
    }
}

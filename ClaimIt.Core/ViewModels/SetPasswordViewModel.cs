using System;
using ClaimIt.Core.Services;
using MvvmCross.Navigation;

namespace ClaimIt.Core.ViewModels
{
    public class SetPasswordViewModel : BaseWithObjectViewModel<string>
    {
        public SetPasswordViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        #region Overrides

        public override void Prepare(string id)
        {
            this.ParticipantId = id;
        }


        #endregion


        #region Binding Properties

        #region ParticipantId

        private string _participantId = String.Empty;

        public string ParticipantId
        {
            get
            {
                return _participantId;
            }
            set
            {
                SetProperty(ref _participantId, value);
            }
        }
        #endregion

        #endregion
    }
}

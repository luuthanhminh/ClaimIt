using System;
using MvvmCross.Navigation;
using System.Diagnostics;
using ClaimIt.Core.Services;
using ClaimIt.Core.Helpers;
using System.Linq;
using MvvmCross.Commands;
using System.Threading.Tasks;

namespace ClaimIt.Core.ViewModels
{
    public class VerifyParticipantViewModel : BaseViewModel
    {

        public VerifyParticipantViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

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
                if (value.Length == 10)
                {
                    VerifyParticipant(value);
                }

            }
        }
        #endregion

        #region PasswordActionText

        private string _passwordActionText = String.Empty;

        public string PasswordActionText
        {
            get
            {
                return _passwordActionText;
            }
            set
            {
                SetProperty(ref _passwordActionText, value);
            }
        }
        #endregion

        #region ShowVerification

        private bool _showVerification = true;

        public bool ShowVerification
        {
            get
            {
                return _showVerification;
            }
            set
            {
                SetProperty(ref _showVerification, value);
            }
        }
        #endregion


        #region ShowFailed

        private bool _showFailed;

        public bool ShowFailed
        {
            get
            {
                return _showFailed;
            }
            set
            {
                SetProperty(ref _showFailed, value);
            }
        }
        #endregion


        #region ShowSuccess

        private bool _showSuccess;

        public bool ShowSuccess
        {
            get
            {
                return _showSuccess;
            }
            set
            {
                SetProperty(ref _showSuccess, value);
            }
        }
        #endregion


        #endregion

        #region Methods

        void VerifyParticipant(string id)
        {
            var participant = Data.Instance.Participants.FirstOrDefault(p => p.Id.Replace("-", String.Empty).Equals(id));
            ShowVerification = false;
            if (participant == null)
            {
                ShowFailed = true;
                ShowSuccess = false;
            }
            else
            {

                PasswordActionText = AppSettings.HasPassword(participant.Id) ? "ENTER PASSWORD" : "SET PASSWORD";
                ShowFailed = false;
                ShowSuccess = true;

            }
        }

        #endregion

        #region Commands

        #region TryAgainCommand

        public IMvxCommand TryAgainCommand => new MvxCommand(TryAgain);

        protected void TryAgain()
        {
            this.ParticipantId = String.Empty;
            this.ShowVerification = true;
            this.ShowFailed = false;
            this.ShowSuccess = false;
        }

        #endregion

        #region EnterPasswordCommand

        public IMvxAsyncCommand EnterPasswordCommand => new MvxAsyncCommand(EnterPassword);

        protected async Task EnterPassword()
        {
            var participant = Data.Instance.Participants.FirstOrDefault(p => p.Id.Replace("-", String.Empty).Equals(this.ParticipantId));

            if (AppSettings.HasPassword(participant.Id))
            {
                await this.NavigationService.Navigate<LoginWithPasswordViewModel, string>(participant.Id);
            }
            else
            {
                await this.NavigationService.Navigate<SetPasswordViewModel, string>(participant.Id);
            }

        }

        #endregion

        #endregion
    }
}

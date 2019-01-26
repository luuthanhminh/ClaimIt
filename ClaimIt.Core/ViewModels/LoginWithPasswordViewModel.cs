using System;
using System.Threading.Tasks;
using ClaimIt.Core.Helpers;
using ClaimIt.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace ClaimIt.Core.ViewModels
{
    public class LoginWithPasswordViewModel : BaseWithObjectViewModel<string>
    {
        public LoginWithPasswordViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
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

        #region Password

        private string _password = String.Empty;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetProperty(ref _password, value);
            }
        }
        #endregion

        #endregion

        #region Commands

        #region LoginCommand

        public IMvxAsyncCommand LoginCommand => new MvxAsyncCommand(Login);

        protected async Task Login()
        {
            if (String.IsNullOrEmpty(Password))
            {
                await DialogService.ShowMessage("Please enter password");
                return;
            }


            var result = AppSettings.VerifiedPassword(this.ParticipantId, Password);

            if (!result)
            {
                await DialogService.ShowMessage("Your passowrd is not correct");
                this.Password = String.Empty;
                return;
            }

            await this.NavigationService.Navigate<TasksViewModel, string>(this.ParticipantId);

        }

        #endregion

        #endregion
    }
}

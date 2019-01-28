using System;
using System.Threading.Tasks;
using ClaimIt.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System.IO;

namespace ClaimIt.Core.ViewModels
{
    public interface ISignatureView
    {
        void ClearPad();
        Task<Stream> GetSignature();
    }

    public class SignatureViewModel : BaseViewModel
    {
        public ISignatureView View { get; set; }

        public SignatureViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        #region Commands

        #region DoneCommand

        public IMvxAsyncCommand DoneCommand => new MvxAsyncCommand(Done);

        protected async Task Done()
        {
            Stream result = null;
            try
            {
                result = await View?.GetSignature();
            }
            catch
            {
                await DialogService.ShowMessage("Could not get signature. Please try again");
                return;
            }

            if (result == null)
            {
                await DialogService.ShowMessage("Please sign your name");
                return;
            }
            this.PopToPage<TasksViewModel>();
        }

        #endregion

        #region ClearCommand

        public IMvxCommand ClearCommand => new MvxCommand(Clear);

        protected void Clear()
        {
            View?.ClearPad();
        }

        #endregion

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;

namespace ClaimIt.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        #region Constructors

        public BaseViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion


        #region Methods

        protected void PopToPage<TViewModel>() where TViewModel : MvxViewModel
        {
            var hint = new MvxPopPresentationHint(typeof(TViewModel));
            _navigationService.ChangePresentation(hint);
        }

        protected async Task ClearStackAndNavigateToPage<TViewModel>() where TViewModel : MvxViewModel
        {
            var presentation = new MvxBundle(new Dictionary<string, string> { { PresentationConstant.CLEAR_STACK_AND_SHOW_PAGE, "" } });

            await _navigationService.Navigate<TViewModel>(presentationBundle: presentation);
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand CloseCommand => new MvxAsyncCommand(ClosePage);

        protected async Task ClosePage()
        {
            await _navigationService.Close(this);
        }

        #endregion


    }
}

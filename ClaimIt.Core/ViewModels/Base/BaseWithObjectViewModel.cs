using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClaimIt.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;
namespace ClaimIt.Core.ViewModels
{
    public abstract class BaseWithObjectViewModel<TParam> : MvxViewModel<TParam>
    {
        protected readonly IMvxNavigationService NavigationService;

        protected readonly IDialogService DialogService;

        #region Constructors

        public BaseWithObjectViewModel(IMvxNavigationService navigationService, IDialogService dialogService)
        {
            NavigationService = navigationService;
            DialogService = dialogService;
        }

        #endregion

        #region Binding Properties

        #region IsLoading

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                SetProperty(ref _isLoading, value);
            }
        }

        #endregion

        #endregion

        #region Methods

        protected void PopToPage<TViewModel>() where TViewModel : MvxViewModel
        {
            var hint = new MvxPopPresentationHint(typeof(TViewModel));
            NavigationService.ChangePresentation(hint);
        }

        protected async Task ClearStackAndNavigateToPage<TViewModel>() where TViewModel : MvxViewModel
        {
            var presentation = new MvxBundle(new Dictionary<string, string> { { PresentationConstant.CLEAR_STACK_AND_SHOW_PAGE, "" } });

            await NavigationService.Navigate<TViewModel>(presentationBundle: presentation);
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand CloseCommand => new MvxAsyncCommand(ClosePage);

        protected async Task ClosePage()
        {
            await NavigationService.Close(this);
        }

        #endregion


        #region Methods

        protected void ShowLoading()
        {
            IsLoading = true;
        }

        protected void HideLoading()
        {
            IsLoading = false;
        }

        #endregion
    }
}

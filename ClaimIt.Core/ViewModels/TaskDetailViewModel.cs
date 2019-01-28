using System;
using System.Threading.Tasks;
using ClaimIt.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace ClaimIt.Core.ViewModels
{
    public interface ITaskDetailView
    {
        void LoadDescription(string description);
    }

    public class TaskDetailViewModel : BaseWithObjectViewModel<TaskItemViewModel>
    {
        TaskItemViewModel _taskItem;

        public ITaskDetailView View { get; set; }

        #region Constructors

        public TaskDetailViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
        }



        #endregion

        #region Overrides

        public override void Prepare(TaskItemViewModel taskItem)
        {
            _taskItem = taskItem;
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            LoadDescription();
        }

        #endregion

        #region Methods

        void LoadDescription()
        {
            View?.LoadDescription(this._taskItem.Description);
        }

        #endregion

        #region Commands

        #region AgreeCommand

        public IMvxAsyncCommand AgreeCommand => new MvxAsyncCommand(Agree);

        protected async Task Agree()
        {
            await this.NavigationService.Navigate<SignatureViewModel>();
        }

        #endregion

        #endregion

    }
}

using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
namespace ClaimIt.Core.ViewModels
{
    public class TaskItemViewModel : MvxViewModel
    {
        public MvxViewModel ParentViewModel { get; set; }

        public bool IsPendingGroup { get; set; }

        #region Title

        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }
        #endregion

        #region Description

        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                SetProperty(ref _description, value);
            }
        }
        #endregion

        #region IsPending

        private bool _isPending;

        public bool IsPending
        {
            get
            {
                return _isPending;
            }
            set
            {
                SetProperty(ref _isPending, value);
            }
        }
        #endregion

        #region GroupItemCounts

        private int _groupItemCounts;

        public int GroupItemCounts
        {
            get
            {
                return _groupItemCounts;
            }
            set
            {
                SetProperty(ref _groupItemCounts, value);
            }
        }
        #endregion

        #region Command

        public IMvxAsyncCommand SelectItemCommand => new MvxAsyncCommand(SelectItem);
        private async Task SelectItem()
        {
            if (ParentViewModel is TasksViewModel tasksViewModel)
            {
                await tasksViewModel.SelectTask(this);
            }
        }

        #endregion
    }
}

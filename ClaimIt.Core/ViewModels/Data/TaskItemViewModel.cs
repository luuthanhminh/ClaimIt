using System;
using MvvmCross.ViewModels;
namespace ClaimIt.Core.ViewModels
{
    public class TaskItemViewModel : MvxViewModel
    {
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
    }
}

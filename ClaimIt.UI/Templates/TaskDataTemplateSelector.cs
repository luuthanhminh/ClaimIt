using System;
using Xamarin.Forms;
using ClaimIt.UI.Views.CustomCells;
using ClaimIt.Core.ViewModels;

namespace ClaimIt.UI.Templates
{
    public class TaskDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public DataTemplate GroupDataTemplate { get; set; }
        public DataTemplate ItemDataTemplate { get; set; }

        public TaskDataTemplateSelector()
        {
            this._groupDataTemplate = new DataTemplate(typeof(TaskGroupCell));
            this._itemDataTemplate = new DataTemplate(typeof(TaskItemCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var taskItemViewModel = item as TaskItemViewModel;
            if (taskItemViewModel == null)
                return null;

            return taskItemViewModel.IsPendingGroup ? this._groupDataTemplate : this._itemDataTemplate;
        }


        private readonly DataTemplate _groupDataTemplate;
        private readonly DataTemplate _itemDataTemplate;
    }
}

using System;
using System.Collections.Generic;
using ClaimIt.Core.ViewModels;
using Xamarin.Forms;

namespace ClaimIt.UI.Pages
{
    public partial class TaskDetailPage : BasePage<TaskDetailViewModel>, ITaskDetailView
    {
        public TaskDetailPage()
        {
            InitializeComponent();
        }

        public void LoadDescription(string description)
        {
            var html = new HtmlWebViewSource();
            html.Html = description;

            wvDes.Source = html;

        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            this.ViewModel.View = this;
        }
    }
}

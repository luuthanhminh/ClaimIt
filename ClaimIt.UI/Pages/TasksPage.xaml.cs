using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ClaimIt.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;

namespace ClaimIt.UI.Pages
{
    [MvxContentPagePresentationAttribute(NoHistory = true)]
    public partial class TasksPage : BasePage<TasksViewModel>
    {


        public TasksPage()
        {
            InitializeComponent();

        }




        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var t = Application.Current.MainPage.Width;
            carousel.ItemWidth = (int)width;
            carousel.Offset = (float)(width / 3);
            carousel.SelectedItemOffset = (int)(width / 3);
            carousel.ItemSpacing = 0;
            carousel.RotationAngle = 90;
            carousel.ScaleOffset = 1;

        }



    }
}

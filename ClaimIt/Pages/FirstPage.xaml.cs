using System;
using System.Collections.Generic;
using ClaimIt.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;

namespace ClaimIt.UI.Pages
{
    [MvxContentPagePresentation()]
    public partial class FirstPage : BasePage<FirstViewModel>
    {
        public FirstPage()
        {
            InitializeComponent();
        }
    }
}

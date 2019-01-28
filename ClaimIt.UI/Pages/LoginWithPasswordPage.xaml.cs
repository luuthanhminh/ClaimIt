﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ClaimIt.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;

namespace ClaimIt.UI.Pages
{

    public partial class LoginWithPasswordPage : BasePage<LoginWithPasswordViewModel>
    {
        public LoginWithPasswordPage()
        {
            InitializeComponent();
        }
    }
}

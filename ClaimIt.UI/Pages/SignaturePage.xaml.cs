using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ClaimIt.Core.ViewModels;
using Xamarin.Forms;
using MvvmCross.Forms.Presenters.Attributes;

namespace ClaimIt.UI.Pages
{

    public partial class SignaturePage : BasePage<SignatureViewModel>, ISignatureView
    {
        public SignaturePage()
        {
            InitializeComponent();
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            this.ViewModel.View = this;
        }

        public void ClearPad()
        {
            snPad.Clear();
        }

        public Task<Stream> GetSignature()
        {
            return snPad.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg);
        }
    }
}

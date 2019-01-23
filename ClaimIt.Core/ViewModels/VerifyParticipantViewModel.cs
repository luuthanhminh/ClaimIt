using System;
using MvvmCross.Navigation;
using System.Diagnostics;

namespace ClaimIt.Core.ViewModels
{
    public class VerifyParticipantViewModel : BaseViewModel
    {
        public VerifyParticipantViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
        }

        #region Binding Properties

        #region ParticipantId

        private string _participantId = String.Empty;
        public string ParticipantId
        {
            get
            {
                return _participantId;
            }
            set
            {
                SetProperty(ref _participantId, value);
                if (value.Length == 10)
                {
                    VerifyParticipant(value);
                }

            }
        }
        #endregion

        #endregion

        #region Methods

        void VerifyParticipant(string id)
        {

        }

        #endregion
    }
}

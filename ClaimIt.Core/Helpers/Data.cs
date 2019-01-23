using System;
using System.Collections.Generic;
using ClaimIt.Core.Models;
namespace ClaimIt.Core.Helpers
{
    public class Data
    {
        private static Data _data = null;
        public static Data Instance
        {
            get
            {
                if (_data == null)
                {
                    _data = new Data();
                }
                return _data;
            }
        }

        #region Fields

        public List<Participant> Participants { get; set; }

        #endregion

        private Data()
        {
            Participants = new List<Participant>()
            {
                new Participant()
                {
                    Id = "980-326-4127"
                },
                new Participant()
                {
                    Id = "728-705-7649"
                },
                new Participant()
                {
                    Id = "423-275-9744"
                },
                new Participant()
                {
                    Id = "768-518-5170"
                },
                new Participant()
                {
                    Id = "196-996-8322"
                },
                new Participant()
                {
                    Id = "111-111-1111"
                }
            };
        }
    }
}

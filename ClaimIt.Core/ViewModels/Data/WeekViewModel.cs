using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
namespace ClaimIt.Core.ViewModels
{
    public class WeekViewModel : MvxViewModel
    {
        public MvxViewModel ParentViewModel { get; set; }

        public bool IsCurrentWeek
        {
            get
            {
                if (IsMonToDay || IsTueToDay || IsWedToDay
                   || IsThusToDay || IsFriToDay || IsSatToDay || IsSunToDay)
                {
                    return true;
                }
                return false;
            }
        }

        #region Monday

        public DateTime? MonId { get; set; }

        #region IsMonHighLight

        private bool _isMonHighLight;

        public bool IsMonHighLight
        {
            get
            {
                return _isMonHighLight;
            }
            set
            {
                SetProperty(ref _isMonHighLight, value);
            }
        }

        #endregion

        #region IsMonToDay

        private bool _isMonToDay;
        public bool IsMonToDay
        {
            get
            {
                return _isMonToDay;
            }
            set
            {
                SetProperty(ref _isMonToDay, value);

            }
        }

        #endregion



        #endregion

        #region Tuesday

        public DateTime? TueId { get; set; }

        #region IsTueHighLight

        private bool _isTueHighLight;

        public bool IsTueHighLight
        {
            get
            {
                return _isTueHighLight;
            }
            set
            {
                SetProperty(ref _isTueHighLight, value);
            }
        }

        #endregion

        #region IsTueToDay

        private bool _isTueToDay;
        public bool IsTueToDay
        {
            get
            {
                return _isTueToDay;
            }
            set
            {
                SetProperty(ref _isTueToDay, value);

            }
        }

        #endregion



        #endregion

        #region Wedday

        public DateTime? WedId { get; set; }

        #region IsWedHighLight

        private bool _isWedHighLight;

        public bool IsWedHighLight
        {
            get
            {
                return _isWedHighLight;
            }
            set
            {
                SetProperty(ref _isWedHighLight, value);
            }
        }

        #endregion

        #region IsWedToDay

        private bool _isWedToDay;
        public bool IsWedToDay
        {
            get
            {
                return _isWedToDay;
            }
            set
            {
                SetProperty(ref _isWedToDay, value);

            }
        }

        #endregion



        #endregion

        #region Thusday

        public DateTime? ThusId { get; set; }

        #region IsThusHighLight

        private bool _isThusHighLight;

        public bool IsThusHighLight
        {
            get
            {
                return _isThusHighLight;
            }
            set
            {
                SetProperty(ref _isThusHighLight, value);
            }
        }

        #endregion

        #region IsThusToDay

        private bool _isThusToDay;
        public bool IsThusToDay
        {
            get
            {
                return _isThusToDay;
            }
            set
            {
                SetProperty(ref _isThusToDay, value);

            }
        }

        #endregion


        #endregion

        #region Friday

        public DateTime? FriId { get; set; }

        #region IsFriHighLight

        private bool _isFriHighLight;

        public bool IsFriHighLight
        {
            get
            {
                return _isFriHighLight;
            }
            set
            {
                SetProperty(ref _isFriHighLight, value);
            }
        }

        #endregion

        #region IsFriToDay

        private bool _isFriToDay;
        public bool IsFriToDay
        {
            get
            {
                return _isFriToDay;
            }
            set
            {
                SetProperty(ref _isFriToDay, value);

            }
        }

        #endregion



        #endregion

        #region Satday

        public DateTime? SatId { get; set; }

        #region IsSatHighLight

        private bool _isSatHighLight;

        public bool IsSatHighLight
        {
            get
            {
                return _isSatHighLight;
            }
            set
            {
                SetProperty(ref _isSatHighLight, value);
            }
        }

        #endregion

        #region IsSatToDay

        private bool _isSatToDay;
        public bool IsSatToDay
        {
            get
            {
                return _isSatToDay;
            }
            set
            {
                SetProperty(ref _isSatToDay, value);

            }
        }

        #endregion



        #endregion

        #region Sunday

        public DateTime? SunId { get; set; }

        #region IsSunHighLight

        private bool _isSunHighLight;

        public bool IsSunHighLight
        {
            get
            {
                return _isSunHighLight;
            }
            set
            {
                SetProperty(ref _isSunHighLight, value);
            }
        }

        #endregion

        #region IsSunToDay

        private bool _isSunToDay;
        public bool IsSunToDay
        {
            get
            {
                return _isSunToDay;
            }
            set
            {
                SetProperty(ref _isSunToDay, value);

            }
        }

        #endregion



        #endregion

        #region GroupText

        private string mGroupText;
        public string GroupText
        {
            get
            {
                return mGroupText;
            }
            set
            {
                SetProperty(ref mGroupText, value);
            }
        }

        #endregion

        #region SunDayText

        private string mSundayText;
        public string SundayText
        {
            get
            {
                return mSundayText;
            }
            set
            {
                SetProperty(ref mSundayText, value);
            }
        }

        #endregion

        #region MondayText

        private string mMondayText;
        public string MondayText
        {
            get
            {
                return mMondayText;
            }
            set
            {
                SetProperty(ref mMondayText, value);
            }
        }

        #endregion

        #region TuedayText

        private string mTuedayText;
        public string TuedayText
        {
            get
            {
                return mTuedayText;
            }
            set
            {
                SetProperty(ref mTuedayText, value);
            }
        }

        #endregion

        #region WeddayText

        private string mWeddayText;
        public string WeddayText
        {
            get
            {
                return mWeddayText;
            }
            set
            {
                SetProperty(ref mWeddayText, value);
            }
        }

        #endregion

        #region ThusdayText

        private string mThusdayText;
        public string ThusdayText
        {
            get
            {
                return mThusdayText;
            }
            set
            {
                SetProperty(ref mThusdayText, value);
            }
        }

        #endregion

        #region FridayText

        private string mFridayText;
        public string FridayText
        {
            get
            {
                return mFridayText;
            }
            set
            {
                SetProperty(ref mFridayText, value);
            }
        }

        #endregion

        #region SatdayText

        private string mSatdayText;
        public string SatdayText
        {
            get
            {
                return mSatdayText;
            }
            set
            {
                SetProperty(ref mSatdayText, value);
            }
        }

        #endregion


        #region Opacity

        private double _opacity = 0;
        public double Opacity
        {
            get
            {
                return _opacity;
            }
            set
            {
                SetProperty(ref _opacity, value);
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ClaimIt.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Binding.Extensions;

namespace ClaimIt.Core.ViewModels
{
    public class TasksViewModel : BaseWithObjectViewModel<string>
    {

        private string _participantId;

        public TasksViewModel(IMvxNavigationService navigationService, IDialogService dialogService) : base(navigationService, dialogService)
        {
            this.Title = $"{DateTime.Today.ToString("dd MMM yyyy")} - PRE SCREEN";
        }

        #region Overrides

        public override void Prepare(string id)
        {
            this._participantId = id;

        }

        public override Task Initialize()
        {
            LoadData();

            return base.Initialize();


        }


        #endregion

        #region Binding Properties

        #region SelectedWeek

        private int _selectedWeekIndex;
        public int SelectedWeekIndex

        {
            get
            {
                return _selectedWeekIndex;
            }
            set
            {
                SetProperty(ref _selectedWeekIndex, value);

            }
        }

        #endregion

        #region WeekViewModels

        private ObservableCollection<WeekViewModel> _weeks = new ObservableCollection<WeekViewModel>();
        public ObservableCollection<WeekViewModel> Weeks
        {
            get
            {
                return _weeks;
            }
            set
            {
                SetProperty(ref _weeks, value);
            }
        }

        #endregion

        #region Tasks

        private ObservableCollection<TaskItemViewModel> _tasks = new ObservableCollection<TaskItemViewModel>();
        public ObservableCollection<TaskItemViewModel> Tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                SetProperty(ref _tasks, value);
            }
        }


        #endregion

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

        #endregion

        #region Commands



        #endregion

        #region Methods


        async void LoadData()
        {
            try
            {
                ShowLoading();
                var results = await BuildCalendar();
                Weeks = new ObservableCollection<WeekViewModel>(results);
                var currentWeek = Weeks.FirstOrDefault(w => w.IsCurrentWeek);
                if (currentWeek != null)
                {
                    this.SelectedWeekIndex = Weeks.IndexOf(currentWeek);

                }

                LoadTasks();

            }
            catch
            {
                await DialogService.ShowMessage("Unable to load data");
            }
            finally
            {
                HideLoading();
            }
        }

        void LoadTasks()
        {
            Tasks = new ObservableCollection<TaskItemViewModel>();
            Tasks.Add(new TaskItemViewModel() { IsPendingGroup = true, GroupItemCounts = 1 });
            Tasks.Add(new TaskItemViewModel()
            {
                Title = "eIC - Stool Study Outline",
                Description = "<h1 style=\"color: #5e9ca0;\">Observation Period</h1><h2 style=\"color: #2e6c80;\">How to use the editor:</h2><p>Paste your documents in the visual editor on the left or your HTML code in the source editor in the right. <br />Edit any of the two areas and see the other changing in real time.&nbsp;</p><p>Click the <span style=\"background-color: #2b2301; color: #fff; display: inline-block; padding: 3px 10px; font-weight: bold; border-radius: 5px;\">Clean</span> button to clean your source code.</p><p>&nbsp;</p><p><strong>&nbsp;</strong></p>",
                ParentViewModel = this
            });
        }

        public async Task SelectTask(TaskItemViewModel taskItemViewModel)
        {
            await this.NavigationService.Navigate<TaskDetailViewModel, TaskItemViewModel>(taskItemViewModel);
        }

        Task<IEnumerable<WeekViewModel>> BuildCalendar()
        {

            return Task.Run<IEnumerable<WeekViewModel>>(() =>
            {
                var yr = DateTime.Today.Year;
                var mth = DateTime.Today.Month;

                var preMonth = new DateTime(yr, mth, 1).AddMonths(-1);
                var nextMonth = new DateTime(yr, mth, 1).AddMonths(1);

                return GetWeeks(preMonth.Year, preMonth.Month).Union(GetWeeks(yr, mth)).Union(GetWeeks(nextMonth.Year, nextMonth.Month));

            });

        }

        public IEnumerable<WeekViewModel> GetWeeks(int year, int month)
        {

            var weeks = GetDates(year, month);
            foreach (var week in weeks)
            {
                WeekViewModel weekViewModel = new WeekViewModel();
                weekViewModel.ParentViewModel = this;
                weekViewModel.GroupText = week.FirstOrDefault().ToString("MMM yyyy");
                weekViewModel.FirstDate = new DateTime(year, month, 1);

                foreach (var date in week)
                {

                    switch (date.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            weekViewModel.MonId = date.Date;
                            weekViewModel.MondayText = date.Day.ToString();
                            weekViewModel.IsMonToDay = date.Date == DateTime.Today.Date;

                            break;
                        case DayOfWeek.Tuesday:
                            weekViewModel.TueId = date.Date;
                            weekViewModel.TuedayText = date.Day.ToString();
                            weekViewModel.IsTueToDay = date.Date == DateTime.Today.Date;

                            break;
                        case DayOfWeek.Wednesday:
                            weekViewModel.WedId = date.Date;
                            weekViewModel.WeddayText = date.Day.ToString();
                            weekViewModel.IsWedToDay = date.Date == DateTime.Today.Date;

                            break;
                        case DayOfWeek.Thursday:
                            weekViewModel.ThusId = date.Date;
                            weekViewModel.ThusdayText = date.Day.ToString();
                            weekViewModel.IsThusToDay = date.Date == DateTime.Today.Date;

                            break;
                        case DayOfWeek.Friday:
                            weekViewModel.FriId = date.Date;
                            weekViewModel.FridayText = date.Day.ToString();
                            weekViewModel.IsFriToDay = date.Date == DateTime.Today.Date;

                            break;
                        case DayOfWeek.Saturday:
                            weekViewModel.SatId = date.Date;
                            weekViewModel.SatdayText = date.Day.ToString();
                            weekViewModel.IsSatToDay = date.Date == DateTime.Today.Date;

                            break;
                        default:
                            weekViewModel.SunId = date.Date;
                            weekViewModel.SundayText = date.Day.ToString();
                            weekViewModel.IsSunToDay = date.Date == DateTime.Today.Date;

                            break;
                    }
                }
                yield return weekViewModel;

            }

        }


        public static List<IGrouping<int, DateTime>> GetDates(int year, int month)
        {
            Calendar calendar = CultureInfo.CurrentCulture.Calendar;
            var results = Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                             .Select(day => new DateTime(year, month, day))
                                    .GroupBy(d => calendar.GetWeekOfYear(d, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                             .ToList();


            return results;

        }


        protected void LoadPreviousWeeks()
        {
            var yr = this.Weeks.First().FirstDate.AddMonths(-1).Year;
            var mth = this.Weeks.First().FirstDate.AddMonths(-1).Month;
            var weeks = GetWeeks(yr, mth).ToList();

            for (int i = weeks.Count - 1; i >= 0; i--)
            {
                this.Weeks.Insert(0, weeks[i]);
            }

        }

        protected void LoadMoreWeeks()
        {
            var yr = this.Weeks.Last().FirstDate.AddMonths(1).Year;
            var mth = this.Weeks.Last().FirstDate.AddMonths(1).Month;

            foreach (var item in GetWeeks(yr, mth))
            {
                this.Weeks.Add(item);
            }
        }

        #endregion

    }
}

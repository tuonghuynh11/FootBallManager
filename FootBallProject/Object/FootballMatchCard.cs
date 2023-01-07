using DevExpress.Xpf.Editors.Helpers;
using FootBallProject.Model;
using FootBallProject.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FootBallProject.Object
{
    public class FootballMatchCard : BaseViewModel, IBaseCard, INotifyDataErrorInfo
    {

        #region error
        public bool HasErrors => _errorBaseViewModel.HasErrors;
        private readonly ErrorBaseViewModel _errorBaseViewModel;
        private void ErrorBaseViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorBaseViewModel.GetErrors(propertyName);
        }
        private bool IsValid(string propertyName)
        {
            return !string.IsNullOrEmpty(propertyName) && !string.IsNullOrWhiteSpace(propertyName);
        }
        #endregion
        private DateTime? _displayDay;
        private TimeSpan _displayTime;
        private DIADIEM _displayPlace;
        private string _scoreTeamA;
        private string _scoreTeamB;
        private string _nameTeamA;
        private string _nameTeamB;
        private bool _isDeleted;
        private int _id;
        private DOIBONG _teamA = new DOIBONG();
        private DOIBONG _teamB = new DOIBONG();
        private THONGTINTRANDAU _infoTeamA = new THONGTINTRANDAU();
        private THONGTINTRANDAU _infoTeamB = new THONGTINTRANDAU();
        private FOOTBALLMATCH _footballMatch = new FOOTBALLMATCH();
        private string _displayName;
        private ObservableCollection<DOIBONG> _teamList;
        private bool _enable;

        public ObservableCollection<DOIBONG> TeamList
        {
            get => _teamList;
            set { _teamList = value; }
        }

        private ObservableCollection<DOIBONG> _teamListDisPlayA;
        public ObservableCollection<DOIBONG> TeamListDisPlayA
        {
            get => _teamListDisPlayA;
            set
            {
                _teamListDisPlayA = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<DOIBONG> _teamListDisPlayB;
        public ObservableCollection<DOIBONG> TeamListDisPlayB
        {
            get => _teamListDisPlayB;
            set { _teamListDisPlayB = value; OnPropertyChanged(); }
        }
        private ObservableCollection<LEAGUE> _leagues;
        public ObservableCollection<LEAGUE> Leagues
        {
            get => _leagues;
            set { _leagues = value; OnPropertyChanged(); }
        }
        private ObservableCollection<ROUND> _rounds;
        public ObservableCollection<ROUND> Rounds
        {
            get => _rounds;
            set { _rounds = value; OnPropertyChanged(); }
        }
        private ROUND _selectedRound;
        public ROUND SelectedRound
        {
            get => _selectedRound;
            set { _selectedRound = value; OnPropertyChanged(); }
        }
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                _errorBaseViewModel.ClearErrors();
                if (!IsValid(DisplayName))
                {
                    _errorBaseViewModel.AddError(nameof(DisplayName), "Vui lòng nhập tên trận đấu!");
                }
                OnPropertyChanged();
            }
        }
        public string ScoreTeamA
        {
            get => _scoreTeamA; set
            {
                _scoreTeamA = value;


                _errorBaseViewModel.ClearErrors();

                if (!IsValid(_scoreTeamA.ToString()))
                {
                    _errorBaseViewModel.AddError(nameof(_scoreTeamA), "Vui lòng chọn tỉ số!");
                }
            }
        }
        public string ScoreTeamB
        {
            get => _scoreTeamB; set
            {
                _scoreTeamB = value;

                // Validation
                _errorBaseViewModel.ClearErrors();

                if (!IsValid(_scoreTeamB.ToString()))
                {
                    _errorBaseViewModel.AddError(nameof(_scoreTeamB), "Vui lòng chọn tỉ số!");
                }
            }
        }
        public bool Enable
        {
            get => _enable;
            set { _enable = value; OnPropertyChanged(); }
        }
        public TimeSpan DisPlayTime
        {
            get { return _displayTime; }
            set { _displayTime = value; OnPropertyChanged(); }
        }
        public string NameTeamA
        {
            get => _nameTeamA; set
            {
                _nameTeamA = value;

                // Validation
                //_errorBaseViewModel.ClearErrors();

                //if (!IsValid(_nameTeamA))
                //{
                //    _errorBaseViewModel.AddError(nameof(_nameTeamA), "Vui lòng chọn đội 1!");
                //}
            }
        }

        public string NameTeamB
        {
            get => _nameTeamB; set
            {
                _nameTeamB = value;

                // Validation
                //_errorBaseViewModel.ClearErrors();

                //if (!IsValid(_nameTeamB))
                //{
                //    _errorBaseViewModel.AddError(nameof(_nameTeamB), "Vui lòng chọn đội 2!");
                //}
            }
        }
        public DIADIEM DisplayPlace
        {
            get => _displayPlace; set
            {
                _displayPlace = value;
                _errorBaseViewModel.ClearErrors();

                if (DisplayPlace == null)
                {
                    _errorBaseViewModel.AddError(nameof(_displayPlace), "Vui lòng chọn địa điểm!");
                }
                OnPropertyChanged();
            }
        }
        private ObservableCollection<DIADIEM> _displayplaces;
        public ObservableCollection<DIADIEM> DisplayPlaces
        {
            get => _displayplaces;
            set { _displayplaces = value; }
        }
        public DateTime? DisplayDay
        {

            get => _displayDay;
            set
            {
                _displayDay = value;
                _errorBaseViewModel.ClearErrors();

                if (DisplayDay == null)
                {
                    _errorBaseViewModel.AddError(nameof(DisplayDay), "Vui lòng chọn thời gian");
                }
                else if (CheckTime() == false)
                {
                    _errorBaseViewModel.AddError(nameof(DisplayDay), "Ngày diễn ra không hợp lệ");
                }
                OnPropertyChanged();
            }
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        public DOIBONG TeamA
        {
            get { return _teamA; }
            set
            {
                _teamA = value;
                OnPropertyChanged(); UpdateListTeamA();
            }
        }
        public DOIBONG TeamB
        {
            get { return _teamB; }
            set { _teamB = value; OnPropertyChanged(); UpdateListTeamB(); }
        }
        public FOOTBALLMATCH CurrentMatch
        {
            get { return _footballMatch; }
            set { _footballMatch = value; OnPropertyChanged(); }
        }
        public THONGTINTRANDAU InfoTeamA
        {
            get { return _infoTeamA; }
            set { _infoTeamA = value; }
        }
        public THONGTINTRANDAU InfoTeamB
        {
            get { return _infoTeamB; }
            set { _infoTeamB = value; }
        }
        public FootballMatchCard(int id, string displayName, DIADIEM displayPlace, DateTime? displayTime, FOOTBALLMATCH currentMatch)
        {
            _errorBaseViewModel = new ErrorBaseViewModel();
            _errorBaseViewModel.ErrorsChanged += ErrorBaseViewModel_ErrorsChanged;
            InitListTeam();
            ID = id;
            CurrentMatch = currentMatch;
            DisplayName = displayName;
            if (displayName != null ) DisplayDay = displayTime;
            if (currentMatch.DIADIEM != null)
            {
                int vari =(int)currentMatch.DIADIEM;
                DisplayPlace = DataProvider.Instance.Database.DIADIEMs.Where(x => x.ID== vari).FirstOrDefault();
            }
            if (CurrentMatch.ROUND != null)
            {
                LEAGUE CurrentLeague = CurrentMatch.ROUND.LEAGUE;
                Rounds = new ObservableCollection<ROUND>(DataProvider.ins.DB.ROUNDs.Where(x => x.IDGIAIDAU == CurrentLeague.ID));
                DisplayPlaces = new ObservableCollection<DIADIEM>(DataProvider.ins.DB.DIADIEMs.Where(x => x.IDQUOCGIA == CurrentLeague.IDQUOCGIA).ToList());
            }
            InitTeamPlayerOfMatch();
            Enable = false;
            //IsEnable();
        }

        public void InitListTeam()
        {
            List<DOIBONG> list1 = new List<DOIBONG>();
            if (CurrentMatch.ROUND != null)
            {
                var list2 = DataProvider.Instance.Database.TEAMOFLEAGUEs.Where(x => x.IDGIAIDAU == CurrentMatch.ROUND.LEAGUE.ID).ToList();
                foreach (var item in list2)
                {
                    list1.Add(item.DOIBONG);
                }
            }
            else { list1 = DataProvider.Instance.Database.DOIBONGs.ToList(); }
            TeamList = new ObservableCollection<DOIBONG>(list1);
            TeamListDisPlayB = new ObservableCollection<DOIBONG>(list1.Where(x => x != TeamA));
            TeamListDisPlayA = new ObservableCollection<DOIBONG>(list1.Where(x => x != TeamB));
        }
        private void UpdateListTeamA()
        {
            var temp = TeamList.Where(x => x != TeamA);
            TeamListDisPlayB = new ObservableCollection<DOIBONG>(temp);
        }
        private void UpdateListTeamB()
        {
            var temp1 = TeamList.Where(x => x != TeamB);
            TeamListDisPlayA = new ObservableCollection<DOIBONG>(temp1);
        }
        public void InitTeamPlayerOfMatch()
        {
            try
            {
                List<THONGTINTRANDAU> list = DataProvider.Instance.Database.THONGTINTRANDAUs.Where(x => x.IDTRANDAU == ID).ToList();
                InfoTeamA = list[0];
                InfoTeamB = list[1];
                ScoreTeamA = InfoTeamA.DIEM.ToString();
                ScoreTeamB = InfoTeamB.DIEM.ToString();
                TeamA = InfoTeamA.DOIBONG;
                TeamB = InfoTeamB.DOIBONG;
            }
            catch { }
        }
        public bool CheckTime()
        {
            try
            {
                if (DisplayDay == null) return false;
                {
                    if (CurrentMatch.ROUND == Rounds.Last())
                    {
                        if (DateTime.Compare(CurrentMatch.ROUND.NGAYBATDAU.TryConvertToDateTime(), DisplayDay.TryConvertToDateTime()) <= 0)
                            return true;
                        else return false;
                    }
                    else if (DateTime.Compare(CurrentMatch.ROUND.NGAYBATDAU.TryConvertToDateTime(), DisplayDay.TryConvertToDateTime()) > 0 ||
                        DateTime.Compare(DisplayDay.TryConvertToDateTime(), Rounds[Convert.ToInt16(CurrentMatch.ROUND.IDDISPLAY)].NGAYBATDAU.TryConvertToDateTime()) > 0
                        )
                    {
                        return false;
                    }
                }
                return true;
            }
            catch { return false; }
            }
        
        public void UpdateFootballMatch()
        {
            if (CheckTime() == true && DisplayName != "" && DisplayPlace != null)
            {
                //List<HUANLUYENVIEN> noticehlvA = new List<HUANLUYENVIEN>();
                //List<HUANLUYENVIEN> noticehlvB = new List<HUANLUYENVIEN>();
                //noticehlvA = DataProvider.Instance.Database.HUANLUYENVIENs.Where(x => x.IDDOIBONG == TeamA.ID).ToList();
                //noticehlvB = DataProvider.Instance.Database.HUANLUYENVIENs.Where(x => x.IDDOIBONG == TeamB.ID).ToList();
                //foreach (var notice in noticehlvA)
                //{
                //    DataProvider.Instance.Database.Notifications.Add(new Notification() { IDHLV = notice.ID, NOTIFY = $"Bạn có lịch đấu với {TeamB.TEN} vào {DisplayDay}" });
                //}
                //foreach (var notice in noticehlvB)
                //{
                //    DataProvider.Instance.Database.Notifications.Add(new Notification() { IDHLV = notice.ID, NOTIFY = $"Bạn có lịch đấu với {TeamA.TEN} vào {  DisplayDay}" });
                //}
                CurrentMatch.THOIGIAN = DisplayDay;
                //CurrentMatch.DIADIEM1.TENDIADIEM = DisplayPlace;
                CurrentMatch.TENTRANDAU = DisplayName;
                CurrentMatch.DIADIEM = DisplayPlace.ID;
                DataProvider.Instance.Database.FOOTBALLMATCHes.AddOrUpdate(CurrentMatch);
                DataProvider.Instance.Database.SaveChanges();
                InfoTeamA.DIEM = Convert.ToInt16(ScoreTeamA);
                InfoTeamB.DIEM = Convert.ToInt16(ScoreTeamB);
                InfoTeamA.IDDOIBONG = TeamA.ID;
                InfoTeamB.IDDOIBONG = TeamB.ID;
                InfoTeamA.IDTRANDAU = CurrentMatch.ID;
                InfoTeamB.IDTRANDAU = CurrentMatch.ID;
                DataProvider.Instance.Database.THONGTINTRANDAUs.AddOrUpdate(InfoTeamA, InfoTeamB);
                DataProvider.Instance.Database.SaveChanges();
                LEAGUE thisLeague = CurrentMatch.ROUND.LEAGUE;
                ROUND thisRound = CurrentMatch.ROUND;
                MainViewModel2.Instance.ContentViewModel = new ListMatchViewModel(thisLeague, thisRound);
            }
        }
    }
    public interface IBaseCard
    {
    }
    public static class BaseCardExtensions
    {
        public static void CopyCardInfo(this IBaseCard card, IBaseCard anotherCard)
        {
            foreach (PropertyInfo propertyInfo in card.GetType().GetProperties())
            {
                propertyInfo.SetValue(card, propertyInfo.GetValue(anotherCard));

            }
        }
    }
}

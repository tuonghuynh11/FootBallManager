﻿using FootBallProject.Model;
using FootBallProject.Object;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Data.Entity.Migrations;

namespace FootBallProject.ViewModel
{
    public class MatchResultViewModel : BaseViewModel
    {
        private FootballMatchCard _footballMatchCard;
        public FootballMatchCard FootballMatchCard
        {
            get => _footballMatchCard;
            set { _footballMatchCard = value; OnPropertyChanged(); }
        }

        private string _scoreTeamA;
        private string _scoreTeamB;
        private ObservableCollection<CAUTHU> _playerTeamAs;
        private ObservableCollection<CAUTHU> _playerTeamBs;
        private ObservableCollection<CardItem> _cardTeamAs;
        private THONGTINTRANDAU _matchTeamInfoTeamA;
        private THONGTINTRANDAU _matchTeamInfoTeamB;
        public THONGTINTRANDAU MatchTeamInfoTeamA
        {
            get => _matchTeamInfoTeamA;
            set { _matchTeamInfoTeamA = value; OnPropertyChanged(); }
        }
        public THONGTINTRANDAU MatchTeamInfoTeamB
        {
            get => _matchTeamInfoTeamB;
            set { _matchTeamInfoTeamB = value; OnPropertyChanged(); }
        }
        public ObservableCollection<CardItem> CardTeamAs
        {
            get => _cardTeamAs;
            set { _cardTeamAs = value; OnPropertyChanged(); }
        }
        private ObservableCollection<CardItem> _cardTeamBs;
        public ObservableCollection<CardItem> CardTeamBs
        {
            get => _cardTeamBs;
            set { _cardTeamBs = value; OnPropertyChanged(); }
        }
        private ObservableCollection<CardItem> _cardTeamADisplays;
        private ObservableCollection<CardItem> _cardTeamBDisplays;
        public ObservableCollection<CardItem> CardTeamADisplays
        {
            get => _cardTeamADisplays;
            set { _cardTeamADisplays = value; OnPropertyChanged(); }
        }
        public ObservableCollection<CardItem> CardTeamBDisplays
        {
            get => _cardTeamBDisplays;
            set { _cardTeamBDisplays = value; OnPropertyChanged(); }
        }
        public ObservableCollection<CAUTHU> PlayerTeamAs
        {
            get => _playerTeamAs;
            set
            {
                _playerTeamAs = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<CAUTHU> PlayerTeamBs
        {
            get => _playerTeamBs;
            set
            {
                _playerTeamBs = value;
                OnPropertyChanged();
            }
        }
        public string ScoreTeamA
        {
            get => _scoreTeamA;
            set
            {
                _scoreTeamA = value;
                _errorBaseViewModel.ClearAllErrors();
                if (!IsValid(ScoreTeamA))
                {
                    _errorBaseViewModel.AddError(nameof(ScoreTeamA), "Vui lòng nhập lại mật khẩu mới!");
                }
                if (IsValid(ScoreTeamA))
                {
                    int result = 0;
                    if (!int.TryParse(ScoreTeamA, out result))
                    {
                        _errorBaseViewModel.AddError(nameof(ScoreTeamA), "Tỉ số phải là số nguyên không âm");
                    }
                    else
                    {
                        if (result < 0) { _errorBaseViewModel.AddError(nameof(ScoreTeamA), "Tỉ số phải là số nguyên dương"); }
                    }
                }
                OnPropertyChanged();
            }
        }
        public string ScoreTeamB
        {
            get => _scoreTeamB; set
            {
                _scoreTeamB = value;
                _errorBaseViewModel.ClearAllErrors();
                if (!IsValid(ScoreTeamA))
                {
                    _errorBaseViewModel.AddError(nameof(ScoreTeamA), "Vui lòng nhập lại mật khẩu mới!");
                }
                if (IsValid(ScoreTeamA))
                {
                    int result = 0;
                    if (!int.TryParse(ScoreTeamA, out result))
                    {
                        _errorBaseViewModel.AddError(nameof(ScoreTeamA), "Tỉ số phải là số nguyên không âm");
                    }
                    else
                    {
                        if (result < 0) { _errorBaseViewModel.AddError(nameof(ScoreTeamA), "Tỉ số phải là số nguyên dương"); }
                    }
                }
                OnPropertyChanged();
            }
        }
        public ICommand SettingDetail { get; set; }
        public ICommand CreateNewCard1 { get; set; }
        public ICommand CreateNewCard2 { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCard { get; set; }
        public ICommand CancelCommand { get; set; }
        private bool IsValid(string propertyName)
        {
            return !string.IsNullOrEmpty(propertyName) && !string.IsNullOrWhiteSpace(propertyName);
        }
        public MatchResultViewModel()
        {
            FootballMatchCard = null;
        }
        public MatchResultViewModel(UserControl p)
        {
            _errorBaseViewModel = new ErrorBaseViewModel();
            _errorBaseViewModel.ErrorsChanged += ErrorBaseViewModel_ErrorsChanged;
            FootballMatchCard card = p.DataContext as FootballMatchCard;
            FootballMatchCard = card;
            PlayerTeamAs = new ObservableCollection<CAUTHU>(DataProvider.Instance.Database.CAUTHUs.Where(x => x.IDDOIBONG == FootballMatchCard.TeamA.ID));
            PlayerTeamBs = new ObservableCollection<CAUTHU>(DataProvider.Instance.Database.CAUTHUs.Where(x => x.IDDOIBONG == FootballMatchCard.TeamB.ID));
            MatchTeamInfoTeamA = FootballMatchCard.InfoTeamA;
            MatchTeamInfoTeamB = FootballMatchCard.InfoTeamB;
            CardTeamAs = new ObservableCollection<CardItem>();
            var itemAs = DataProvider.Instance.Database.ITEMs.Where(x => x.IDTHONGTINTRANDAU == MatchTeamInfoTeamA.ID).ToList();
            foreach (var item in itemAs)
            {
                CardTeamAs.Add(new CardItem(item, PlayerTeamAs));
            }
            CardTeamBs = new ObservableCollection<CardItem>();
            var itemBs = DataProvider.Instance.Database.ITEMs.Where(x => x.IDTHONGTINTRANDAU == MatchTeamInfoTeamB.ID).ToList();
            foreach (var item in itemBs)
            {
                CardTeamBs.Add(new CardItem(item, PlayerTeamBs));
            }
            CardTeamADisplays = new ObservableCollection<CardItem>(CardTeamAs);
            CardTeamBDisplays = new ObservableCollection<CardItem>(CardTeamBs);
            ScoreTeamA = MatchTeamInfoTeamA.DIEM.ToString();
            ScoreTeamB = MatchTeamInfoTeamB.DIEM.ToString();
            CreateNewCard1 = new RelayCommand<object>((x) => { return true; }, (x) => { CreateNewItemCard1(); });
            CreateNewCard2 = new RelayCommand<object>((x) => { return true; }, (x) => { CreateNewItemCard2(); });
            DeleteCard = new RelayCommand<UserControl>((x) => { return true; }, (x) => { DeleteItemCard(x); });
            SaveCommand = new RelayCommand<object>((x) => { return true; }, (x) => { SaveFuntion(); });
            CancelCommand = new RelayCommand<object>((x) => { return true; }, (x) => { CancelFuntion(); });
        }
        private void CancelFuntion()
        {
            CardTeamADisplays = new ObservableCollection<CardItem>(CardTeamAs);
            CardTeamBDisplays = new ObservableCollection<CardItem>(CardTeamBs);
            ScoreTeamA = MatchTeamInfoTeamA.DIEM.ToString();
            ScoreTeamB = MatchTeamInfoTeamB.DIEM.ToString();
        }
        private void SaveFuntion()
        {
            CardTeamAs = new ObservableCollection<CardItem>();
            var itemAs = DataProvider.Instance.Database.ITEMs.Where(x => x.IDTHONGTINTRANDAU == MatchTeamInfoTeamA.ID).ToList();
            foreach (var item in itemAs)
            {
                CardTeamAs.Add(new CardItem(item, PlayerTeamAs));
            }
            CardTeamBs = new ObservableCollection<CardItem>();
            var itemBs = DataProvider.Instance.Database.ITEMs.Where(x => x.IDTHONGTINTRANDAU == MatchTeamInfoTeamB.ID).ToList();
            foreach (var item in itemBs)
            {
                CardTeamBs.Add(new CardItem(item, PlayerTeamBs));
            }

            var oldlist = DataProvider.Instance.Database.ITEMs.Where(x => x.IDTHONGTINTRANDAU == MatchTeamInfoTeamA.ID).ToList();
            foreach (var item in oldlist)
            {
                DataProvider.Instance.Database.ITEMs.Remove(item);
            }
            var oldlist2 = DataProvider.Instance.Database.ITEMs.Where(x => x.IDTHONGTINTRANDAU == MatchTeamInfoTeamB.ID).ToList();
            foreach (var item in oldlist2)
            {
                DataProvider.Instance.Database.ITEMs.Remove(item);
            }
            foreach (var card in CardTeamADisplays)
            {
                ITEM temp = new ITEM
                {
                    IDITEMTYPE = 1,
                    THOIGIAN = card.Time,
                    CAUTHU = card.Player,
                    THONGTINTRANDAU = MatchTeamInfoTeamA
                };
                DataProvider.Instance.Database.ITEMs.AddOrUpdate(temp);
            }
            foreach (var card in CardTeamBDisplays)
            {
                ITEM temp = new ITEM
                {
                    IDITEMTYPE = 1,
                    THOIGIAN = card.Time,
                    CAUTHU = card.Player,
                    THONGTINTRANDAU = MatchTeamInfoTeamB
                };
                DataProvider.Instance.Database.ITEMs.AddOrUpdate(temp);
            }
            MatchTeamInfoTeamA.DIEM = Convert.ToInt16(ScoreTeamA);
            MatchTeamInfoTeamB.DIEM = Convert.ToInt16(ScoreTeamB);
            DataProvider.Instance.Database.SaveChanges();
            LEAGUE thisLeague = FootballMatchCard.CurrentMatch.ROUND.LEAGUE;
            ROUND thisRound = FootballMatchCard.CurrentMatch.ROUND;
            MainViewModel2.Instance.ContentViewModel = new ListMatchViewModel(thisLeague, thisRound);

        }
        private void CreateNewItemCard1()
        {
            ITEM item1 = new ITEM()
            {
                IDITEMTYPE = 1
            };
            CardItem item = new CardItem(item1, PlayerTeamAs);
            CardTeamADisplays.Add(item);
            ScoreTeamA = CardTeamADisplays.Count().ToString();
        }
        private void CreateNewItemCard2()
        {
            ITEM item1 = new ITEM()
            {
                IDITEMTYPE = 1
            };
            CardItem item = new CardItem(item1, PlayerTeamBs);
            CardTeamBDisplays.Add(item);
            ScoreTeamB = CardTeamADisplays.Count().ToString();
        }
        private void DeleteItemCard(UserControl x)
        {
            x = null;
        }
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

        #endregion

    }

}
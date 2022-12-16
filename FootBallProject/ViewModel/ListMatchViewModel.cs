﻿using FootBallProject.Model;
using FootBallProject.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallProject.ViewModel
{
    class ListMatchViewModel : BaseViewModel

    {
        private static ListMatchViewModel s_instance;
        public static ListMatchViewModel Instance
        {
            get => s_instance ?? (s_instance = new ListMatchViewModel());
            private set => s_instance = value;

        }
        static private ObservableCollection<FOOTBALLMATCH> _storedFootballMatchCards = new ObservableCollection<FOOTBALLMATCH>();
        public static ObservableCollection<FOOTBALLMATCH> StoredFootballMatchCards { get => _storedFootballMatchCards; set => _storedFootballMatchCards = value; }

        private static ObservableCollection<FOOTBALLMATCH> _footballMatchCards = new ObservableCollection<FOOTBALLMATCH>();

        public static ObservableCollection<FOOTBALLMATCH> FootballMatchCards { get => _footballMatchCards; set { _footballMatchCards = value; } }
        private static ObservableCollection<FootballMatchCard> _footballMatchCard1s = new ObservableCollection<FootballMatchCard>();
        public static ObservableCollection<FootballMatchCard> FootballMatchCard1
        {
            get { return _footballMatchCard1s; }
            set { _footballMatchCard1s = value; }
        }
        private ROUND _selectedRound;
        public ROUND SelectedRound
        {
            get { return _selectedRound; }
            set
            {
                _selectedRound = value;
                OnPropertyChanged();
                LoadMatchlistbyRound();
            }
        }
        private ObservableCollection<ROUND> rounds;
        public ObservableCollection<ROUND> Rounds
        {
            get { return rounds; }
            set
            {
                rounds = value;
                OnPropertyChanged();
            }
        }
        private LEAGUE _selectedLeague;
        public LEAGUE SelectedLeague
        {
            get { return _selectedLeague; }
            set
            {
                _selectedLeague = value;
                OnPropertyChanged();
                LoadRound();

            }
        }
        private ObservableCollection<LEAGUE> leagues;
        public ObservableCollection<LEAGUE> Leagues
        {
            get { return leagues; }
            set { leagues = value; }
        }
        public ICommand CreateNewMatch { get; set; }

        private void LoadFootballMatchListByRound() { }
        private void LoadRoundListByLeague() { }
        public ListMatchViewModel(int i)
        {
            SelectedLeague = DataProvider.Instance.Database.LEAGUEs.Where(x => x.ID == 1).FirstOrDefault();
            LoadMatchlistbyRound();
        }
        public ListMatchViewModel()
        {
            SelectedLeague = DataProvider.Instance.Database.LEAGUEs.Where(x => x.ID == 1).FirstOrDefault();
            SelectedRound = null;
            LoadMatchlistbyRound();
            LoadRound();
            LoadLeague();
        }
        public ListMatchViewModel(LEAGUE selectedleague, ROUND selectedround)
        {
            SelectedLeague = selectedleague;
            SelectedRound = selectedround;
            LoadMatchlistbyRound();
            LoadRound();
            LoadLeague();
        }
        public void LoadLeague()
        {
            Leagues = new ObservableCollection<LEAGUE>(DataProvider.Instance.Database.LEAGUEs);
        }
        public void LoadRound()
        {
            Rounds = new ObservableCollection<ROUND>(DataProvider.Instance.Database.ROUNDs.Where(x => x.IDGIAIDAU == SelectedLeague.ID));
        }
        public void LoadMatchlistbyRound()
        {
            FootballMatchCards.Clear();
            StoredFootballMatchCards.Clear();
            FootballMatchCard1.Clear();
            StoredFootballMatchCards = new ObservableCollection<FOOTBALLMATCH>(DataProvider.Instance.Database.FOOTBALLMATCHes.Where(x => x.ROUND.LEAGUE.ID == SelectedLeague.ID));
            foreach (var item in StoredFootballMatchCards)
            {
                if (item.ROUND == SelectedRound || SelectedRound == null)
                {
                    string temp = "";
                    if (item.DIADIEM1 != null)
                    {
                        temp = item.DIADIEM1.TENDIADIEM;
                    }
                    FootballMatchCard1.Add(new FootballMatchCard(item.ID, item.TENTRANDAU, temp, item.THOIGIAN));
                    FootballMatchCards.Add(item);
                }
            }
        }
        public void CreateNewMatchCard()
        {
            FOOTBALLMATCH match = new FOOTBALLMATCH()
            {
                IDVONG = SelectedRound.ID,


            };
        }
    }

}
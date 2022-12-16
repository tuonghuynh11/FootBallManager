using FootBallProject.Model;
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
    class ListofLeagueViewModel : BaseViewModel
    {
        private static ListofLeagueViewModel _instance;
        public static ListofLeagueViewModel Instance
        {
            get { if (_instance == null) _instance = new ListofLeagueViewModel(); return _instance; }
            set { _instance = value; }
        }
        private LeagueCardOb _currentleague;
        public LeagueCardOb Currentleague
        {
            get { return _currentleague; }
            set
            {
                _currentleague = value; OnPropertyChanged();
                LoadTeambyLeagueid();
            }
        }
        private ObservableCollection<LeagueCardOb> leagues;

        public ObservableCollection<LeagueCardOb> Leagues
        {
            get { return leagues; }
            set { leagues = value; OnPropertyChanged(); }
        }
        private ObservableCollection<TEAMOFLEAGUE> teams;
        public ObservableCollection<TEAMOFLEAGUE> Teams
        {
            get { return teams; }
            set { teams = value; OnPropertyChanged(); }
        }
        private void LoadTeambyLeagueid()
        {
            Teams = null;
            ObservableCollection<TEAMOFLEAGUE> teams = new ObservableCollection<TEAMOFLEAGUE>();
            List<TEAMOFLEAGUE> list = DataProvider.Instance.Database.TEAMOFLEAGUEs.ToList();
            foreach (var item in list)
            {
                teams.Add(item);
            }
            Teams = teams;
        }
        private void AddTeamofLeague(int idleague, DOIBONG teamplayer)
        {
            TEAMOFLEAGUE teamofleague = new TEAMOFLEAGUE()
            {
                IDGIAIDAU = idleague,
                DOIBONG = teamplayer
            };
        }
        public ICommand AddtemofLeague { get; set; }
        public ListofLeagueViewModel()
        {
            var currentleague = DataProvider.Instance.Database.LEAGUEs.FirstOrDefault();
            Currentleague = new LeagueCardOb(currentleague);
            ObservableCollection<LeagueCardOb> list3 = new ObservableCollection<LeagueCardOb>();
            List<LEAGUE> list1 = DataProvider.Instance.Database.LEAGUEs.ToList();
            foreach (var item in list1)
            {
                list3.Add(new LeagueCardOb(item));
            }
            Leagues = list3;
            //AddTeamofLeague = new RelayCommand<object>((p) => true, (p) => AddTeamofLeague(1, teams[0]));
        }
    }

}

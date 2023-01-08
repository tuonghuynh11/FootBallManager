using DevExpress.Xpf.Charts;
using FootBallProject.Component.League;
using FootBallProject.Model;
using FootBallProject.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallProject.ViewModel
{
    public class ConfigAutoViewModel : BaseViewModel
    {
        private LeagueCardOb _currentleague;
        public LeagueCardOb Currentleague
        {
            get { return _currentleague; }
            set
            {
                _currentleague = value; OnPropertyChanged();
            }
        }
        private ObservableCollection<RoundObject> _roundlist;
        public ObservableCollection<RoundObject> RoundList
        {
            get { return _roundlist; }
            set
            {
                _roundlist = value;
                OnPropertyChanged();
            }
        }

        public ListofLeagueViewModel Ins;
        private ObservableCollection<TEAMOFLEAGUE> teams = new ObservableCollection<TEAMOFLEAGUE>();
        public ObservableCollection<TEAMOFLEAGUE> Teams
        {
            get { return teams; }
            set { teams = value; OnPropertyChanged(); }
        }

        public ConfigAutoViewModel(ListofLeagueViewModel ins)
        {
            Ins = ListofLeagueViewModel.Instance;
            Currentleague = ins.Currentleague;
            Teams = Ins.Teams;
            RoundList = Ins.RoundList;
        }
    }
}

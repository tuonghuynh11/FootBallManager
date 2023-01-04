using DevExpress.Xpf.Charts;
using FootBallProject.Model;
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

            Teams = Ins.Teams;
        }
    }
}

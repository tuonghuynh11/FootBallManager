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
    public class LeagueEditViewModel : BaseViewModel
    {
        private LeagueCardOb _selectedLeague;
        public LeagueCardOb SelectedLeague
        {
            get => _selectedLeague;
            set { _selectedLeague = value; }
        }
        private ObservableCollection<QUOCTICH> quoctichs;
        public ObservableCollection<QUOCTICH> QuocTichs
        {
            get => quoctichs;
            set { quoctichs = value; }
        }
        public LeagueEditViewModel(LeagueCardOb card)
        {
            SelectedLeague = card;
            var temp = DataProvider.Instance.Database.QUOCTICHes.ToList();
            QuocTichs = new ObservableCollection<QUOCTICH>(temp);
        }
    }

}

using DevExpress.Xpf.Charts;
using FootBallProject.Class;
using FootBallProject.Model;
using FootBallProject.Object;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        private bool enable;
        public bool Enable
        {
            get { return enable; }
            set { enable = value; OnPropertyChanged(); }
        }
        public ICommand SaveInfo { get; set; }
        public ICommand CancelInfo { get; set; }
        public LeagueEditViewModel(LeagueCardOb card)
        {
            SelectedLeague = card;
            var temp = DataProvider.Instance.Database.QUOCTICHes.ToList();
            QuocTichs = new ObservableCollection<QUOCTICH>(temp);
            SaveInfo = new RelayCommand<object>(p => { return true; }, p => { SaveInfoFuntion(); });
            CancelInfo = new RelayCommand<object>(p => { return true; }, p => { CancelFuntion(); });
            if (AccessUser.userLogin.USERROLE.ID == 2)
            {
                Enable = true;
            }
            else Enable = false;
        }
        public void SaveInfoFuntion() {
            SelectedLeague.SaveLeague();
        }
        public void CancelFuntion() {
            LeagueRightBarViewModel.Instance.ShowInfoFuntion2(SelectedLeague);
        } 
    }

}

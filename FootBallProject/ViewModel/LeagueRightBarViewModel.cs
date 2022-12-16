using FootBallProject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;

namespace FootBallProject.ViewModel
{
    public class LeagueRightBarViewModel : BaseViewModel
    {
        private LeagueCardOb _selectedLeagueCard;
        private object _rightSideBarItemViewModel;
        private object _emptyStateRightBarViewModel;
        public LeagueCardOb SelectedLeagueCard
        {
            get { return _selectedLeagueCard; }
            set { _selectedLeagueCard = value; }
        }
        public object _leagueInfomationViewModel;
        public object RightSideBarItemViewModel
        {
            get => _rightSideBarItemViewModel;
            set
            {
                _rightSideBarItemViewModel = value;
                OnPropertyChanged();

            }
        }
        public ICommand ShowInfo { get; set; }
        public ICommand EditLeague { get; set; }
        public LeagueRightBarViewModel()
        {
            _leagueInfomationViewModel = new LeagueInfomationViewModel(null);
            _emptyStateRightBarViewModel = new EmptyRightSideBarViewModel();
            RightSideBarItemViewModel = _emptyStateRightBarViewModel;
            ShowInfo = new RelayCommand<UserControl>((p) => { return true; }, (p) => { ShowInfoFuntion(p); });
            EditLeague = new RelayCommand<UserControl>(p => { return true; }, p => { EditLeagueFunction(p); });
        }
        private void EditLeagueFunction(UserControl p)
        {
            LeagueCardOb card = p.DataContext as LeagueCardOb;
            RightSideBarItemViewModel = new LeagueEditViewModel(card);
        }
        private void ShowInfoFuntion(UserControl p)
        {
            LeagueCardOb card = p.DataContext as LeagueCardOb;
            ListofLeagueViewModel.Instance.Currentleague = card;
            RightSideBarItemViewModel = new LeagueInfomationViewModel(card);
        }
    }

}

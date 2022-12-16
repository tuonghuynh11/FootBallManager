using FootBallProject.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallProject.ViewModel
{
    class MainViewModel2 : BaseViewModel
    {
        #region property
        private static MainViewModel2 s_instance;
        public static MainViewModel2 Instance
        {
            get => s_instance ?? (s_instance = new MainViewModel2());
            private set => s_instance = value;
        }
        private ObservableCollection<Navigation> _navigations;

        public ObservableCollection<Navigation> Navigations { get => _navigations; set => _navigations = value; }
        private object _contentViewModel;
        private object _rightSideBar;
        public object ContentViewModel
        {
            get => _contentViewModel;
            set
            {
                _contentViewModel = value;
                OnPropertyChanged();
            }
        }
        public object RightSideBar
        {
            get => _rightSideBar;
            set
            {
                _rightSideBar = value;
                OnPropertyChanged();
            }
        }
        #endregion property
        //ViewModel _display in contentview
        private object _listOfLeagueViewModel;
        private object _listMatchViewModel;
        private object _listMatchRightSideBarViewModel;
        private object _leagueRightBarViewModel;
        public MainViewModel2()
        {
            Instance = this;
            InitContentView();
            InitRightbarView();
            InitNavigation();
        }
        private void InitContentView()
        {
            _listOfLeagueViewModel = new ListofLeagueViewModel();
            _listMatchViewModel = new ListMatchViewModel();
            _listMatchRightSideBarViewModel = new ListMatchRightBarViewModel();
            _leagueRightBarViewModel = new LeagueRightBarViewModel();
        }
        private void InitRightbarView() { }
        private void InitNavigation()
        {
            Navigations = new ObservableCollection<Navigation>()
            {
                new Navigation("Giải đấu","SchoolOutline", _listOfLeagueViewModel, _leagueRightBarViewModel, this),
                new Navigation("Trận đấu","Home", _listMatchViewModel, _listMatchRightSideBarViewModel, this)
            };

        }
    }

}

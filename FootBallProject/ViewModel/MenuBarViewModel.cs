using FootBallProject.UserControlBar.ScreenNavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace FootBallProject.ViewModel
{
    public class MenuBarViewModel:BaseViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        //Tạo command cho các nút
        public ICommand AdminCommand { get; set; }
        public ICommand TacticCommand { get; set; }
        public ICommand FootballTeamListCommand { get; set; }
        public ICommand OrdersCommand { get; set; }
        public ICommand TransactionsCommand { get; set; }
        public ICommand ShipmentsCommand { get; set; }
        public ICommand SettingsCommand { get; set; }

        private void Home() => CurrentView = new AdminScreenViewModel();
        private void Tactic() => CurrentView = new TeamBuilderViewModel();
        private void FootBallTeam() => CurrentView = new FootballTeamListViewModel();


        public MenuBarViewModel()
        {
            //Tạo các màn hình cho các nút
          
            AdminCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => { Home(); });
            TacticCommand = new RelayCommand<object>((p) => {return true; }, (p) => { Tactic(); });
            FootballTeamListCommand = new RelayCommand<object>((p) => {return true; }, (p) => { FootBallTeam(); });
           

            // Startup Page
            CurrentView = new AdminScreenViewModel();
        }
      
    }
}

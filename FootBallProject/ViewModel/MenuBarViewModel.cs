using FootBallProject.Model;
using FootBallProject.UserControlBar.ScreenNavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace FootBallProject.ViewModel
{
    public class MenuBarViewModel:BaseViewModel
    {

        static public USER User;

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
        public ICommand TrainingCalendarCommand { get; set; }
        public ICommand LeaderListCommand { get; set; }

        public ICommand TransferCommand { get; set; }
        private void Home() => CurrentView = new AdminScreenViewModel();
        private void Tactic() => CurrentView = new TeamBuilderViewModel();
        private void FootBallTeam() => CurrentView = new FootballTeamListViewModel();
        private void TrainingCalendar() => CurrentView = new TrainCalendarViewModel();
        private void LeaderList() => CurrentView = new LeaderListViewModel();
        private void TransferList() => CurrentView = new TeamPlayersViewModel();

        //Tạo Visibility cho các nút
        public Visibility ALLTEAMVisibility { get; set; }
        public MenuBarViewModel()
        {
            //Tạo các màn hình cho các nút
          
            AdminCommand = new RelayCommand<object>((p) => {
                return true;
            }, (p) => { Home(); });
            TacticCommand = new RelayCommand<object>((p) => {return true; }, (p) => { Tactic(); });
            FootballTeamListCommand = new RelayCommand<object>((p) => {return true; }, (p) => { FootBallTeam(); });
            TrainingCalendarCommand = new RelayCommand<object>((p) => {return true; }, (p) => { TrainingCalendar(); });
            LeaderListCommand = new RelayCommand<object>((p) => {return true; }, (p) => { LeaderList(); });
            TransferCommand = new RelayCommand<object>((p) => {return true; }, (p) => { TransferList(); });


            // Startup Page
            CurrentView = new AdminScreenViewModel();

            //Check user role for button visibility

            if (USER.ROLE !="Admin")
            {
                ALLTEAMVisibility = Visibility.Collapsed;
            }
        }
      
    }
}

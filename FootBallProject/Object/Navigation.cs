using FootBallProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallProject.Object
{
    class Navigation : BaseViewModel
    {
        public string NavigationHeader { get; set; }
        public string Icon { get; set; }
        public object NavigationItemViewModel { get; set; }
        public object RightSideBarNavigationItemViewModel { get; set; }
        public ICommand CreateView { get; set; }
        public MainViewModel2 MainViewModel { get; set; }
        public bool IsPressed { get => _isPressed; set { _isPressed = value; OnPropertyChanged(); } }
        private bool _isPressed;
        public Navigation(string navigationheader, string icon, object navigationItemViewModel, object rightSideBarViewModel, MainViewModel2 mainviewmodel)
        {
            NavigationHeader = navigationheader;
            Icon = icon;
            NavigationItemViewModel = navigationItemViewModel;
            RightSideBarNavigationItemViewModel = rightSideBarViewModel;
            MainViewModel = mainviewmodel;
            CreateView = new RelayCommand<object>((p) => { return true; }, (p) => { CreateViewFuntion(); });
        }
        private void CreateViewFuntion()
        {
            ObservableCollection<Navigation> navigationItems = MainViewModel.Navigations;
            foreach (var item in navigationItems)
            {
                item.IsPressed = false;
            }
            IsPressed = true;
            MainViewModel.ContentViewModel = NavigationItemViewModel;
            MainViewModel.RightSideBar = RightSideBarNavigationItemViewModel;
        }
    }

}

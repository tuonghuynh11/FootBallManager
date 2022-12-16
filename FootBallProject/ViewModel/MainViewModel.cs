using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FootBallProject.ViewModel
{
    ///Mọi xử lý nằm trong này
    public class MainViewModel :BaseViewModel
    {
        public bool IsLoad= false;
        public ICommand LoadWindowCommand { get; set; }
        public MainViewModel()
        {
            LoadWindowCommand = new RelayCommand<UserControl>((p) => { return true; },
                (p) => {
                   IsLoad = true;
                    AdminScreen adminScreen = new AdminScreen();
                    adminScreen.Show();
                    
                });
        }
        
        
     
    }
}

using FootBallProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallProject.ViewModel
{
    public class DS_GiaiDauViewModel:BaseViewModel
    {
        private ObservableCollection<GIAIDAU> _Leagues;
        public ObservableCollection<GIAIDAU> Leagues { get => _Leagues; set { _Leagues = value; OnPropertyChanged(); } }

        public DS_GiaiDauViewModel()
        {
            Leagues = new ObservableCollection<GIAIDAU>(DataProvider.ins.DB.GIAIDAUs);
        }
    }
}

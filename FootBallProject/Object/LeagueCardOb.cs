using FootBallProject.Model;
using FootBallProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallProject.Object
{
    public class LeagueCardOb : BaseViewModel
    {
        private string _displayName;
        private string _startTime;
        private string _endTime;
        private int _soDoi;
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; OnPropertyChanged(); }
        }
        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; OnPropertyChanged(); }
        }
        public string EndTime
        {
            get { return _endTime; }
            set { _endTime = value; OnPropertyChanged(); }
        }
        public int SoDoi
        {
            get { return _soDoi; }
            set { _soDoi = value; OnPropertyChanged(); }
        }
        private QUOCTICH quocTich;
        public QUOCTICH QuocTich
        {
            get { return quocTich; }
            set { quocTich = value; OnPropertyChanged(); }
        }
        public LeagueCardOb(LEAGUE p)
        {
            DisplayName = p.TENGIAIDAU;
            QuocTich = p.QUOCTICH;
            StartTime = p.NGAYBATDAU.ToString().Split(' ')[0];
            EndTime = p.NGAYKETTHUC.ToString().Split(' ')[0];
            SoDoi = DataProvider.Instance.Database.TEAMOFLEAGUEs.Where(x => x.IDGIAIDAU == p.ID).Count();
        }
    }

}

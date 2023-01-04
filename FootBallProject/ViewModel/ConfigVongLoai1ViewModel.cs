using DevExpress.Data.Utils;
using FootBallProject.Model;
using FootBallProject.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallProject.ViewModel
{
    public class ConfigVongLoai1ViewModel: BaseViewModel
    {
        public int numofTeam;
        private static ConfigVongLoai1ViewModel _instance;
        public static ConfigVongLoai1ViewModel Instance
        {
            get { if (_instance == null) _instance = new ConfigVongLoai1ViewModel(ListofLeagueViewModel.Instance); return _instance; }
            set { _instance = value; }
        }
        public ListofLeagueViewModel Ins;
        private ObservableCollection<TeamItem> teams = new ObservableCollection<TeamItem>();
        public ObservableCollection<TeamItem> Teams
        {
            get { return teams; }
            set { teams = value; OnPropertyChanged(); }
        }
        private string totalTeam;
        private bool enable;
        public bool Enable
        {
            get { return enable; }
            set { enable = value; OnPropertyChanged(); }
        }
        public string TotalTeam
        {
            get { return totalTeam; }
            set { totalTeam = value; OnPropertyChanged();}
        }
        public void CountTotalTeam()
        {
            int count = 0;
            foreach(var item in Teams)
            {
                if ((item as TeamItem).Selected == true)
                {
                    count++;
                }
            }
            TotalTeam = count.ToString();
            if (count == numofTeam) Enable = true; 
        }
        public ICommand CountinueCommand { get; set; }

        public ConfigVongLoai1ViewModel(ListofLeagueViewModel ins)
        {
            numofTeam = Convert.ToInt32(CreateNewLeague.Instance.SelectedSoluong);
            Instance = this;
            var list = DataProvider.ins.DB.DOIBONGs.ToList();
            foreach (var item in list)
            {
                teams.Add(new TeamItem(item));
            }
            Teams = teams;
            TotalTeam = "0";
            Enable = false;
            CountinueCommand = new RelayCommand<object>((p) => { return true; }, (p) => {ListofLeagueViewModel.Instance.ContinueFuntion(); });
        }
        public void ContinueFuntion()
        {
            foreach(var item in Teams)
            {
                if (item.Selected == true)
                {
                    TEAMOFLEAGUE temp = new TEAMOFLEAGUE()
                    {
                        IDDOIBONG = item.Team.ID,
                        IDGIAIDAU = CreateNewLeague.Instance.League.ID
                    };
                    DataProvider.ins.DB.TEAMOFLEAGUEs.Add(temp);
                }
            }
            DataProvider.ins.DB.SaveChanges();
        }
    }
}

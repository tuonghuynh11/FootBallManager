using FootBallProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;

namespace FootBallProject.ViewModel
{
    public class ConfigVongLoai2ViewModel: BaseViewModel
    {
        public ListofLeagueViewModel Ins;
        private ObservableCollection<ROUND> listRound = new ObservableCollection<ROUND>();
        public ObservableCollection<ROUND> ListRound
        {
            get => listRound;
            set { listRound = value; OnPropertyChanged(); }
        }
        public ICommand Complete { get; set; }
        public ConfigVongLoai2ViewModel(ListofLeagueViewModel ins)
        {
            string name = "Vòng số ";
            Ins = ins;
            int k = 1;
            for (int i = 1; i <= Math.Log(ConfigVongLoai1ViewModel.Instance.numofTeam,2); i++)
            {
                ROUND temp = new ROUND()
                {
                    TENVONGDAU = name + i.ToString(),
                    IDDISPLAY = i.ToString(),
                    SOLUONGDOI = ConfigVongLoai1ViewModel.Instance.numofTeam / k
                };
                listRound.Add(temp);
                k *= 2;
            }
            ListRound = listRound;
            Complete = new RelayCommand<object>((p) => { return true; }, (p) => { CompleteFuntion(); });
        }
        public void CompleteFuntion()
        {
            foreach(var item in listRound)
            {
                item.IDGIAIDAU = CreateNewLeague.Instance.League.ID;
                DataProvider.Instance.Database.ROUNDs.AddOrUpdate(item);
            }
            DataProvider.ins.DB.SaveChanges();
            MessageBox.Show("Thêm giải đấu thành công");
        }
    }
}

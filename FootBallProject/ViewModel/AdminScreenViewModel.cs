using FootBallProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallProject.ViewModel
{
    public class AdminScreenViewModel : BaseViewModel
    {
        private ObservableCollection<DOIBONG> _Teams;
        public ObservableCollection<DOIBONG> Teams { get => _Teams; set { _Teams = value; OnPropertyChanged(); } }


        private ObservableCollection<DOIBONG> _BestTeams;
        public ObservableCollection<DOIBONG> BestTeams { get => _BestTeams; set { _BestTeams = value; OnPropertyChanged(); } }

        private ObservableCollection<CAUTHU> _BestPlayers;
        public ObservableCollection<CAUTHU> BestPlayers { get => _BestPlayers; set { _BestPlayers = value; OnPropertyChanged(); } }

        private ObservableCollection<THONGTINGIAIDAU> _TournamentInformation;
        public ObservableCollection<THONGTINGIAIDAU> TournamentInformation { get => _TournamentInformation; set { _TournamentInformation = value; OnPropertyChanged(); } }


        private ObservableCollection<FOOTBALLMATCH> _MatchInformation;
        public ObservableCollection<FOOTBALLMATCH> MatchInformation { get => _MatchInformation; set { _MatchInformation = value; OnPropertyChanged(); } }

        public AdminScreenViewModel()
        {

            Teams = new ObservableCollection<DOIBONG>(DataProvider.ins.DB.Database.SqlQuery<DOIBONG>("SELECT TOP(4) * FROM DOIBONG"));
            BestPlayers = new ObservableCollection<CAUTHU>(DataProvider.ins.DB.Database.SqlQuery<CAUTHU>("SELECT TOP(5) * FROM CAUTHU ORDER BY SOBANTHANG DESC"));

            LEAGUE id_giaidau = DataProvider.ins.DB.Database.SqlQuery<LEAGUE>("SELECT TOP(1) * FROM LEAGUE ORDER BY ID ASC").FirstOrDefault<LEAGUE>();

            TournamentInformation= new ObservableCollection<THONGTINGIAIDAU>(DataProvider.ins.DB.Database.SqlQuery<THONGTINGIAIDAU>("SELECT * FROM THONGTINGIAIDAU WHERE IDGIAIDAU =@ID ", new SqlParameter("@ID", id_giaidau.ID)));

            MatchInformation = new ObservableCollection<FOOTBALLMATCH>(DataProvider.ins.DB.Database.SqlQuery<FOOTBALLMATCH>("SELECT TOP(4) * FROM FOOTBALLMATCH ORDER BY THOIGIAN DESC"));
        }

    }
}

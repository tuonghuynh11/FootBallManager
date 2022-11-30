using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;

namespace FootBallProject.ViewModel
{
    public class TeamPlayersViewModel : BaseViewModel
    {

        public ICommand RowDoubleClickCommand { get; set; }
        public ICommand AddPlayerCommand2 { get; set; }
        private DataTable dataTable;

        public ICommand AddPlayerCommand { get; set; }
        private List<Player> playerList = new List<Player>();
        public List<Player> PlayerList { get { return playerList; }
            set {
                playerList = value;
                OnPropertyChanged();
            }
        }
        private List<string> clubsNames = new List<string>();
        public List<string> ClubsNames
        {
            get => clubsNames;
            set
            {
                clubsNames = value;
                OnPropertyChanged();
            }
        }
        private List<string> nationalities = new List<string>();
        public List<string> Nationalities
        {
            get
            {
                return nationalities;
            }
            set
            {
                nationalities = value;
                OnPropertyChanged();
            }
        }
        Player selectedPlayer = new Player();
        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                selectedPlayer = value;
                OnPropertyChanged();
            }
        }
        public TeamPlayersViewModel()
        {
            //dataTable = new DataTable();

            PullData();
            foreach(DataRow dr in dataTable.Rows)
            {
                Player player = new Player();
                player.Id = dr["ID"].ToString();
                player.ClubID = dr["IDDOIBONG"].ToString();
                player.Nationality = dr["TENQUOCGIA"].ToString();
                player.Name = dr["HOTEN"].ToString();
                player.Age = Convert.ToInt32(dr["TUOI"]);
                player.LeaguesNum = Convert.ToInt32(dr["SOGIAI"]);
                player.Goals = Convert.ToInt32(dr["SOBANTHANG"]);
                player.Foot = dr["CHANTHUAN"].ToString();
                player.Physique = dr["THETRANG"].ToString();
                player.Height = dr["CHIEUCAO"].ToString();
                player.Weight = dr["CANNANG"].ToString();
                playerList.Add(player);

            }
            PullClub();
            foreach(DataRow dr in dataTable.Rows)
            {
                string club = dr["TEN"].ToString();
                clubsNames.Add(club);
            }
            PullNationalities();
            foreach(DataRow dr in dataTable.Rows){
                string nationality = dr["TENQUOCGIA"].ToString();
                nationalities.Add(nationality);
            }

            RowDoubleClickCommand = new RelayCommand<object>((p) => { if (p as TeamsPlayers == null) return false;   return true; }, (p) =>
            {
                TeamsPlayers tp = p as TeamsPlayers;
                PlayerProfile pp = new PlayerProfile();
                int x = tp.Players_List.SelectedIndex;
                pp.DataContext = tp.players[x];
                pp.Show();
                
            }
            
            );
            AddPlayerCommand = new RelayCommand<object>(
                (p) => { if (p as TeamsPlayers == null) return false; return true; }, 
                (p) =>
                {
                    Window1 wd1 = new Window1();
                    wd1.Show();
                } 
                

                );
            AddPlayerCommand2 = new RelayCommand<object>(
                (p) => { if (p as Window1 == null) return false; return true; },
                (p) =>
                {
                    Window1 wd1 = p as Window1;
                    string connString = @"Server=DESKTOP-GUE0JS7\SQLEXPRESS;Database=FOOTBALLMANAGER2;Trusted_Connection=True;";
                    string query = "INSERT CAUTHU values(@teamid, @idquoctich, @hoten, @tuoi, 0, 0, NULL, @chanthuan, @Thetrang, @height, @weight, 0)";
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connString))
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@teamid", wd1.txbclub.SelectedValue.ToString());
                                cmd.Parameters.AddWithValue("@idquoctich", wd1.txbNationality.SelectedValue.ToString());
                                cmd.Parameters.AddWithValue("@hoten", wd1.txbName.Text);
                                cmd.Parameters.AddWithValue("@tuoi", Convert.ToInt32(wd1.txbAge.Text));
                                cmd.Parameters.AddWithValue("@chanthuan", wd1.txbFoot.SelectedValue.ToString());
                                cmd.Parameters.AddWithValue("@Thetrang", wd1.txbPhysyque.Text);
                                cmd.Parameters.AddWithValue("@height", wd1.txbHeight.Text);
                                cmd.Parameters.AddWithValue("@weight", wd1.txbWeight.Text);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            PullData();
                            foreach (DataRow dr in dataTable.Rows)
                            {
                                Player player = new Player();
                                player.Id = dr["ID"].ToString();
                                player.ClubID = dr["IDDOIBONG"].ToString();
                                player.Nationality = dr["TENQUOCGIA"].ToString();
                                player.Name = dr["HOTEN"].ToString();
                                player.Age = Convert.ToInt32(dr["TUOI"]);
                                player.LeaguesNum = Convert.ToInt32(dr["SOGIAI"]);
                                player.Goals = Convert.ToInt32(dr["SOBANTHANG"]);
                                player.Foot = dr["CHANTHUAN"].ToString();
                                player.Physique = dr["THETRANG"].ToString();
                                player.Height = dr["CHIEUCAO"].ToString();
                                player.Weight = dr["CANNANG"].ToString();
                                playerList.Add(player);

                            }
                        }
                    }catch(Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                    }
                    
                }

                );
        }
        void PullData()
        {
            string connString = @"Server=DESKTOP-GUE0JS7\SQLEXPRESS;Database=FOOTBALLMANAGER2;Trusted_Connection=True;";
            string query = "SELECT * FROM dbo.CAUTHU ct JOIN QUOCTICH qt on ct.IDQUOCTICH = qt.ID";
            dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
        }
        void PullClub()
        {
            string connString = @"Server=DESKTOP-GUE0JS7\SQLEXPRESS;Database=FOOTBALLMANAGER2;Trusted_Connection=True;";
            string query = "SELECT * FROM dbo.DOIBONG";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            dataTable = new DataTable();
            
            conn.Open();
            

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();


        }
        void PullNationalities()
        {
            string connString = @"Server=DESKTOP-GUE0JS7\SQLEXPRESS;Database=FOOTBALLMANAGER2;Trusted_Connection=True;";
            string query = "SELECT TENQUOCGIA FROM dbo.QUOCTICH";
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            dataTable = new DataTable();
            conn.Open();


            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
        }
    }
    public class Player : BaseViewModel
    {
       
        string id;
        public string Id { get { return id; } set { id = value; OnPropertyChanged(); } }
        string clubID;
        public string ClubID { get { return clubID; } set { clubID = value; OnPropertyChanged(); } }
        //int number;
        //public int Number { get { return number; } set { number = value; OnPropertyChanged(); } }
        string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }
        int age;
        public int Age { get { return age; } set { age = value; OnPropertyChanged(); } }
        string height;
        public string Height { get { return height; } set { height = value; OnPropertyChanged(); } }
        string weight;
        public string Weight { get { return weight; } set { weight = value; OnPropertyChanged(); } }
        int leaguesNum;
        public int LeaguesNum { get { return leaguesNum; } set { leaguesNum = value; OnPropertyChanged(); } }
        int goals;
        public int Goals { get { return goals; } set { goals = value; OnPropertyChanged(); } }
        string foot;
        public string Foot { get { return foot; } set { foot = value; OnPropertyChanged(); } }

        string physique;
        public string Physique { get { return physique; } set { physique = value; OnPropertyChanged(); } }
        string nationality;
        public string Nationality { get { return nationality; } set { nationality = value; OnPropertyChanged(); } }
        string position;
        public string Position { get { return position; } set { position = value; OnPropertyChanged(); } }
        string price;
        public string Price { get { return price; } set { price = value; OnPropertyChanged(); } }
    }
}

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
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Collections;
using System.IO;

namespace FootBallProject.ViewModel
{
    public class TeamPlayersViewModel : BaseViewModel
    {

        public ICommand RowDoubleClickCommand { get; set; }
        public ICommand AddPlayerCommand2 { get; set; }
        private DataTable dataTable;

        public ICommand AddPlayerCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }
        public ICommand UpdatePlayerCommand { get; set; }
        public ICommand OpenUpdateCommand { get; set; }
        public ICommand TransferCommand { get; set; }
        public ICommand BuyCommand { get; set; }
        public ICommand LoadImageCommand { get; set; }
        private List<Player> playerList = new List<Player>();
        private List<Player> transferPlayers = new List<Player>();
        public List<Player> TransferPlayers
        {
            get { return transferPlayers; }
            set
            {
                transferPlayers = value;
                OnPropertyChanged();
            }
        }
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
        private List<string> nationID = new List<string>();
        private List<string> clubID = new List<string>();
        
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
        string connString = @"Server=DESKTOP-GUE0JS7\SQLEXPRESS;Database=FOOTBALLMANAGER2;Trusted_Connection=True;";

        public TeamPlayersViewModel()
        {
            //dataTable = new DataTable();

            PullData();
            PutDataTolist();
            PullTransferData();
            PutTransfertoList();
            PullClub();
            foreach(DataRow dr in dataTable.Rows)
            {
                string club = dr["TEN"].ToString();
                string ID = dr["ID"].ToString();
                clubsNames.Add(club);
                clubID.Add(ID);
            }
            PullNationalities();
            foreach(DataRow dr in dataTable.Rows){
                string nationality = dr["TENQUOCGIA"].ToString();
                string ID = dr["ID"].ToString();
                nationalities.Add(nationality);
                nationID.Add(ID);
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
            //Command nut add
            AddPlayerCommand = new RelayCommand<object>(
                (p) => { if (p as TeamsPlayers == null) return false; return true; }, 
                (p) =>
                {
                    TeamsPlayers x = p as TeamsPlayers;
                    Window1 wd1 = new Window1();
                    wd1.ShowDialog();
                    x.Players_List.ItemsSource = null;
                    x.Players_List.ItemsSource = playerList;

                } 
                

                );
            //Command add
            AddPlayerCommand2 = new RelayCommand<object>(
                (p) => { if (p as Window1 == null) return false; return true; },
                (p) =>
                {
                    
                    Window1 wd1 = p as Window1;
                    System.Windows.MessageBox.Show(wd1.txbclub.Text);
                    string query = "INSERT CAUTHU values(@teamid, @idquoctich, @hoten, @tuoi, 0, 0, @hinhanh, @chanthuan, @Thetrang, @height, @weight, 0)";
                    PullClub();
                    string IDDoiBong = "";
                    foreach(DataRow dr in dataTable.Rows)
                    {
                        if (dr["TEN"].ToString() == wd1.txbclub.Text)
                        {
                            IDDoiBong = dr["ID"].ToString();
                            break;
                        }
                    }
                    PullNationalities();
                    string IdQG = "";
                    foreach(DataRow dr in dataTable.Rows)
                    {
                        if (dr["TENQUOCGIA"].ToString() == wd1.txbNationality.Text)
                        {
                            IdQG = dr["ID"].ToString();
                            break;
                        }
                    }

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connString))
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@teamid", IDDoiBong); //THIS IS WRONG
                                cmd.Parameters.AddWithValue("@idquoctich", IdQG);
                                cmd.Parameters.AddWithValue("@hoten", wd1.txbName.Text);
                                cmd.Parameters.AddWithValue("@tuoi", Convert.ToInt32(wd1.txbAge.Text));
                                cmd.Parameters.AddWithValue("@hinhanh", wd1.txbImage.Text);
                                cmd.Parameters.AddWithValue("@chanthuan", wd1.txbFoot.SelectedValue.ToString());
                                cmd.Parameters.AddWithValue("@Thetrang", wd1.txbPhysyque.Text);
                                cmd.Parameters.AddWithValue("@height", wd1.txbHeight.Text);
                                cmd.Parameters.AddWithValue("@weight", wd1.txbWeight.Text);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            PullData();
                            PutDataTolist();
                        }
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                    }

                }

                );
            DeletePlayerCommand = new RelayCommand<object>(
                (p) => { if (p as TeamsPlayers == null) return false; return true; },
                (p) =>
                {
                    TeamsPlayers x = p as TeamsPlayers;
                    string query = "DELETE FROM CAUTHU WHERE ID = @id";
                    string id = SelectedPlayer.Id;
                    using(SqlConnection sqlConnection = new SqlConnection(connString))
                    {
                        sqlConnection.Open();

                        try
                        {
                            using (SqlCommand sqlquery = new SqlCommand(query, sqlConnection))
                            {
                                sqlquery.Parameters.AddWithValue("@id", id);
                                sqlquery.ExecuteNonQuery();
                            }
                        }
                        catch(Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show(e.Message);
                        }
                        sqlConnection.Close();
                    }
                    PlayerList.Remove(SelectedPlayer);
                    //PullData();
                    //PutDataTolist();
                    x.Players_List.ItemsSource = null;
                    x.Players_List.ItemsSource = playerList;

                    
                }
                );
            UpdatePlayerCommand = new RelayCommand<object>(
                (p) => { if (p as EditPlayerForm == null) return false; return true; },
                (p) =>
                {
                    EditPlayerForm edit = p as EditPlayerForm;
                    string query = "UPDATE CAUTHU SET HOTEN = @hoten, IDQUOCTICH=@idquoctich, TUOI =@tuoi, HINHANH = @hinhanh, CHANTHUAN = @chanthuan, THETRANG = @Thetrang, CHIEUCAO =@height, CANNANG = @weight WHERE ID = @id";
                    PullClub();
                    string IDDoiBong = "";
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        if (dr["TEN"].ToString() == edit.txbclub.Text)
                        {
                            IDDoiBong = dr["ID"].ToString();
                            break;
                        }
                    }
                    PullNationalities();
                    string IdQG = "";
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        if (dr["TENQUOCGIA"].ToString() == edit.txbNationality.Text)
                        {
                            IdQG = dr["ID"].ToString();
                            break;
                        }
                    }

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connString))
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@idquoctich", IdQG);
                                cmd.Parameters.AddWithValue("@hoten", edit.txbName.Text);
                                cmd.Parameters.AddWithValue("@tuoi", Convert.ToInt32(edit.txbAge.Text));
                                cmd.Parameters.AddWithValue("@chanthuan", edit.txbFoot.SelectedValue.ToString());
                                cmd.Parameters.AddWithValue("@Thetrang", edit.txbPhysyque.Text);
                                cmd.Parameters.AddWithValue("@height", edit.txbHeight.Text);
                                cmd.Parameters.AddWithValue("@weight", edit.txbWeight.Text);
                                cmd.Parameters.AddWithValue("@hinhanh", edit.txbImage.Text);

                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            PullData();
                            PutDataTolist();
                        }
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                    }
                }

                );
            // Command nut Sell
            TransferCommand = new RelayCommand<TransferWindow>(
                (p) => { if (p  == null) return false; return true; },
                (p) =>
                {
                    TransferWindow tw = p ;
                    string query = "INSERT CHUYENNHUONG VALUES (@idcauthu)";
                    string id = SelectedPlayer.Id;

                    //System.Windows.Forms.MessageBox.Show(id);
                    using (SqlConnection sqlConnection = new SqlConnection(connString))
                    {
                        sqlConnection.Open();

                        try
                        {
                            using (SqlCommand sqlquery = new SqlCommand(query, sqlConnection))
                            {
                                sqlquery.Parameters.AddWithValue("@idcauthu", id);
                                sqlquery.ExecuteNonQuery();
                            }
                        }
                        catch (Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show(e.Message);
                        }
                        sqlConnection.Close();
                    }
                    TransferPlayers.Add(SelectedPlayer);
                    tw.dgrid1.ItemsSource = null;
                    tw.dgrid2.ItemsSource = null;
                    tw.dgrid1.ItemsSource = PlayerList;
                    tw.dgrid2.ItemsSource = TransferPlayers;
                }
                );
            BuyCommand = new RelayCommand<object>(
                (p) => { if (p as TransferWindow == null) return false; return true; }, 
                (p) =>
                {
                    TransferWindow tp = p as TransferWindow;
                    string query1 = "UPDATE CAUTHU SET IDDOIBONG = @iddoibong where ID = @id";
                    string query2 = "DELETE FROM CHUYENNHUONG WHERE IDCAUTHU = @id";
                    string id = SelectedPlayer.Id;
                    System.Windows.Forms.MessageBox.Show(id);

                    Random rand = new Random();
                    int x = rand.Next(0, clubID.Count);
                    string selectedclubid = clubID[x];
                    using(SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        try
                        {
                            using (SqlCommand sqlquery = new SqlCommand(query1, conn))
                            {
                                sqlquery.Parameters.AddWithValue("@iddoibong", selectedclubid);
                                sqlquery.Parameters.AddWithValue("@id", id);
                                sqlquery.ExecuteNonQuery();
                            }
                            using(SqlCommand sqlquery2 = new SqlCommand(query2, conn))
                            {
                                sqlquery2.Parameters.AddWithValue("@id", id);
                                sqlquery2.ExecuteNonQuery();

                            }
                        }
                        catch (Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show(e.Message);
                        }
                    }
                    TransferPlayers.Remove(SelectedPlayer);
                    tp.dgrid1.ItemsSource = null;
                    tp.dgrid2.ItemsSource = null;
                    tp.dgrid1.ItemsSource = PlayerList;
                    tp.dgrid2.ItemsSource = TransferPlayers;
                   
                }
                );
            LoadImageCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (p as Window1 == null && p as EditPlayerForm == null) return false; return true;
                },
                (p)=>
                {
                    
                   
                    OpenFileDialog openfile = new OpenFileDialog();
                    openfile.Filter = "Image file |*.img; *.bmp; *.png; *.jpg; *.jpeg ";
                    string path = @"...\FootballProject\Images";
                    try
                    {
                        openfile.InitialDirectory = path;
                    }
                    catch(Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                    }
                    openfile.FileOk += Openfile_FileOk;
                    if(openfile.ShowDialog() == DialogResult.OK)
                    {
                         if(p as Window1 != null)
                        {
                            Window1 x = p as Window1;
                            x.txbImage.Text = openfile.FileName;
                        }
                         else
                        {
                            EditPlayerForm x = p as EditPlayerForm;
                            x.txbImage.Text = openfile.FileName;

                        }
                    }

                }
                );



        }

        private void Openfile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var x = sender as OpenFileDialog;
            string filename = x.FileName;
         
            if (Path.GetDirectoryName(filename) != x.InitialDirectory)
            {
                System.Windows.MessageBox.Show(Path.GetDirectoryName(filename));
            }
        }

        void PullData()
        {
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
            PlayerList.Clear();

            
        }
        void PullTransferData()
        {
            string query = "SELECT * FROM CHUYENNHUONG cn join CAUTHU ct on cn.IDCAUTHU = ct.ID join  QUOCTICH qt on ct.IDQUOCTICH = qt.ID";
            dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
            transferPlayers.Clear();
        }
        void PutDataTolist()
        {
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
                player.Price = dr["GIATIEN"].ToString();
                player.Image = dr["HINHANH"].ToString();
                playerList.Add(player);

            }
        }
        void PutTransfertoList()
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                Player player = new Player();
                player.Id = dr["IDCAUTHU"].ToString();
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
                player.Price = dr["GIATIEN"].ToString();
                player.Image = dr["HINHANH"].ToString();
                transferPlayers.Add(player);

            }
        }
        void PullClub()
        {
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
            string query = "SELECT * FROM dbo.QUOCTICH";
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
        private string image;
        public string Image { get { return image; } set { image = value; OnPropertyChanged(); } }
    }
}

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
using System.Drawing;
using System.Windows.Media.Imaging;

using System.Net;
using System.Net.Mail;
using System.Configuration;
using FootBallProject.UserControlBar;

namespace FootBallProject.ViewModel
{
    public class TeamPlayersViewModel : BaseViewModel
    {
        public ICommand RowDoubleClickCommand { get; set; }
        public ICommand AddPlayerCommand2 { get; set; }
        private DataTable dataTable;
        BitmapImage bitmap = new BitmapImage();

        public ICommand AddPlayerCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }
        public ICommand UpdatePlayerCommand { get; set; }
        public ICommand OpenUpdateCommand { get; set; }
        public ICommand TransferCommand { get; set; }
        public ICommand BuyCommand { get; set; }
        public ICommand LoadImageCommand { get; set; }
        public ICommand GoToEdit { get; set; }

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
        public List<Player> PlayerList
        {
            get { return playerList; }
            set
            {
                playerList = value;
                OnPropertyChanged();
            }
        }

        private List<Player> clubPlayerList = new List<Player>();
        public List<Player> ClubPlayerList
        {
            get { return clubPlayerList; }
            set
            {
                clubPlayerList = value;
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

        string connString = ConfigurationManager.ConnectionStrings["connectstr"].ConnectionString;


        public TeamPlayersViewModel()
        {
            //dataTable = new DataTable();

            PullData();
            PutDataTolist();
            PullTransferData();
            PutTransfertoList();

            PullClubData();
            PutClubDataToList();

            PullClub();
            foreach (DataRow dr in dataTable.Rows)
            {
                string club = dr["TEN"].ToString();
                string ID = dr["ID"].ToString();
                clubsNames.Add(club);
                clubID.Add(ID);
            }
            PullNationalities();
            foreach (DataRow dr in dataTable.Rows)
            {
                string nationality = dr["TENQUOCGIA"].ToString();
                string ID = dr["ID"].ToString();
                nationalities.Add(nationality);
                nationID.Add(ID);
            }


            GoToEdit = new RelayCommand<object>(
                (p) => {
                    if (p as TeamPlayersUC == null)
                        return false;
                    return true;
                },
                (p) =>
                {
                    TeamPlayersUC x = p as TeamPlayersUC;
                    if (x.Players_List.SelectedItems.Count == 0)
                    {
                        return;
                    }
                    EditPlayerForm edit = new EditPlayerForm();

                    edit.ShowDialog();
                }
                );

            RowDoubleClickCommand = new RelayCommand<object>((p) => { if (p as TeamPlayersUC == null) return false; return true; }, (p) =>
            {
                TeamPlayersUC tp = p as TeamPlayersUC;
                PlayerProfile pp = new PlayerProfile();
                int x = tp.Players_List.SelectedIndex;

                pp.Show();

            }

            );
            //Command nut add
            AddPlayerCommand = new RelayCommand<object>(
                (p) => { if (p as TeamPlayersUC == null) return false; return true; },
                (p) =>
                {
                    TeamPlayersUC x = p as TeamPlayersUC;
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

                    if ((wd1.txbName.Text == "") || wd1.txbImage.Text == ""
                    || wd1.txbHeight.Text == "" || wd1.txbclub.Text == ""
                    || wd1.txbWeight.Text == "" || wd1.txbPos.Text == ""
                    || wd1.txbNumber.Text == "" || wd1.txbNationality.Text == ""
                    || wd1.txbAge.Text == "" || wd1.txbPhysyque.Text == "" || wd1.txbFoot.Text == "")
                    {
                        System.Windows.Forms.MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int parsevalue;
                        string position = wd1.txbPos.Text.Trim();
                        if (!int.TryParse(wd1.txbAge.Text, out parsevalue))
                        {
                            System.Windows.Forms.MessageBox.Show("Tuổi phải nhập số", "Nhập lại tuổi đi!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if (!int.TryParse(wd1.txbHeight.Text, out parsevalue))
                        {
                            System.Windows.Forms.MessageBox.Show("Chiều cao phải nhập số", "Nhập lại chiều cao đi!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if (!int.TryParse(wd1.txbWeight.Text, out parsevalue))
                        {
                            System.Windows.Forms.MessageBox.Show("Cân nặng phải nhập số", "Nhập lại cân nặng đi!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        string[] arrString = { "GK", "CB", "LB", "RB", "CDM", "CM", "LM", "RM", "LW", "RW", "ST" };

                        if (!arrString.Contains(position, StringComparer.OrdinalIgnoreCase))
                        {

                            System.Windows.Forms.MessageBox.Show("Bạn nhập vị trí không dúng\nCác vị trí là: GK, CB, LB, RB," +
                                " CDM, CM, LM, RM, LW, RW, ST", "Vị trí", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        string query = "INSERT CAUTHU values(@teamid, @idquoctich, @hoten, @tuoi, 0, 0, @hinhanh, @chanthuan, @Thetrang, @vitri, @soao, '" + wd1.txbHeight.Text + "cm', '" + wd1.txbWeight.Text + "', 0)";
                        PullClub();
                        string IDDoiBong = "";
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            if (dr["TEN"].ToString() == wd1.txbclub.Text)
                            {
                                IDDoiBong = dr["ID"].ToString();
                                break;
                            }
                        }
                        PullNationalities();
                        string IdQG = "";
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            if (dr["TENQUOCGIA"].ToString() == wd1.txbNationality.Text)
                            {
                                IdQG = dr["ID"].ToString();
                                break;
                            }
                        }
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(wd1.txbImage.Text, UriKind.RelativeOrAbsolute);

                        bitmap.EndInit();
                        byte[] bites = ConvertBitmaptoByteArray(bitmap);

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
                                    cmd.Parameters.AddWithValue("@hinhanh", bites);
                                    cmd.Parameters.AddWithValue("@chanthuan", wd1.txbFoot.SelectedValue.ToString());
                                    cmd.Parameters.AddWithValue("@Thetrang", wd1.txbPhysyque.Text);
                                    cmd.Parameters.AddWithValue("@vitri", wd1.txbPos.Text);
                                    cmd.Parameters.AddWithValue("@soao", wd1.txbNumber.Text);
                                    cmd.Parameters.AddWithValue("@height", wd1.txbHeight.Text);
                                    cmd.Parameters.AddWithValue("@weight", wd1.txbWeight.Text);
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                                PullData();
                                PutDataTolist();
                            }
                            wd1.Close();
                        }
                        catch (Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show(e.Message);
                            return;
                        }
                        try
                        {
                            RandomSquad(IDDoiBong);
                        }
                        catch (Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }

                );
            DeletePlayerCommand = new RelayCommand<object>(
                (p) => { if (p as TeamPlayersUC == null) return false; return true; },
                (p) =>
                {
                    TeamPlayersUC x = p as TeamPlayersUC;
                    string query = "DELETE FROM CAUTHU WHERE ID = @id";
                    string id = SelectedPlayer.Id;
                    using (SqlConnection sqlConnection = new SqlConnection(connString))
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
                        catch (Exception e)
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
                    edit.txbNationality.SelectedItem = (ComboBoxItem)edit.txbNationality.FindName(SelectedPlayer.Nationality);
                    if ((edit.txbName.Text == "") || edit.txbImage.Text == ""
                    || edit.txbHeight.Text == "" || edit.txbclub.Text == ""
                    || edit.txbWeight.Text == "" || edit.txbPos.Text == ""
                    || edit.txbNumber.Text == "" || edit.txbNationality.Text == ""
                    || edit.txbAge.Text == "" || edit.txbPhysyque.Text == "" || edit.txbFoot.Text == "")
                    {
                        System.Windows.Forms.MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        int parsevalue;
                        string position = edit.txbPos.Text.Trim();
                        if (!int.TryParse(edit.txbAge.Text, out parsevalue))
                        {
                            System.Windows.Forms.MessageBox.Show("Tuổi phải nhập số", "Nhập lại tuổi đi!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if (!int.TryParse(edit.txbHeight.Text, out parsevalue))
                        {
                            System.Windows.Forms.MessageBox.Show("Chiều cao phải nhập số", "Nhập lại chiều cao đi!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if (!int.TryParse(edit.txbWeight.Text, out parsevalue))
                        {
                            System.Windows.Forms.MessageBox.Show("Cân nặng phải nhập số", "Nhập lại cân nặng đi!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        string[] arrString = { "GK", "CB", "LB", "RB", "CDM", "CM", "LM", "RM", "LW", "RW", "ST" };

                        if (!arrString.Contains(position, StringComparer.OrdinalIgnoreCase))
                        {

                            System.Windows.Forms.MessageBox.Show("Bạn nhập vị trí không dúng\nCác vị trí là: GK, CB, LB, RB," +
                                " CDM, CM, LM, RM, LW, RW, ST", "Vị trí", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        string query = "UPDATE CAUTHU SET HOTEN = @hoten, IDQUOCTICH=@idquoctich, TUOI =@tuoi, HINHANH = @hinhanh, CHANTHUAN = @chanthuan, " +
                        "THETRANG = @Thetrang, VITRI = '" + edit.txbPos.Text + "', SOAO = " + edit.txbNumber.Text + ", CHIEUCAO =@height, CANNANG = @weight WHERE ID = @id";
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

                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(edit.txbImage.Text, UriKind.RelativeOrAbsolute);

                        bitmap.EndInit();
                        byte[] bites = ConvertBitmaptoByteArray(bitmap);
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
                                    cmd.Parameters.AddWithValue("@hinhanh", bites);

                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                                PullData();
                                PutDataTolist();
                            }
                            edit.Close();
                        }
                        catch (Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show(e.Message);
                        }
                    }


                }

                );
            // Command nut Sell
            TransferCommand = new RelayCommand<TransferWindowUC>(
                (p) => { if (p == null) return false; return true; },
                (p) =>
                {
                    TransferWindowUC tw = p;
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

                            System.Windows.Forms.MessageBox.Show("Cầu thủ đã được bán", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        sqlConnection.Close();
                    }

                    tw.dgrid1.ItemsSource = null;
                    tw.dgrid2.ItemsSource = null;
                    tw.dgrid1.ItemsSource = clubPlayerList;

                    tw.dgrid2.ItemsSource = TransferPlayers;
                }
                );
            BuyCommand = new RelayCommand<object>(
                (p) => { if (p as TransferWindowUC == null) return false; return true; },
                (p) =>
                {
                    TransferWindowUC tp = p as TransferWindowUC;
                    string query1 = "UPDATE CAUTHU SET IDDOIBONG = @iddoibong where ID = @id";
                    string query2 = "DELETE FROM CHUYENNHUONG WHERE IDCAUTHU = @id";
                    string id = SelectedPlayer.Id;

                    //System.Windows.Forms.MessageBox.Show(id);


                    string selectedclubid = "mu";

                    using (SqlConnection conn = new SqlConnection(connString))
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
                            using (SqlCommand sqlquery2 = new SqlCommand(query2, conn))
                            {
                                sqlquery2.Parameters.AddWithValue("@id", id);
                                sqlquery2.ExecuteNonQuery();

                            }
                        }
                        catch (Exception)
                        {

                            System.Windows.Forms.MessageBox.Show("Hiện tại chưa có cầu thủ trên thị trường chuyển nhượng");

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
                (p) =>
                {


                    OpenFileDialog openfile = new OpenFileDialog();
                    openfile.Filter = "Image file |*.img; *.bmp; *.png; *.jpg; *.jpeg ";
                    string path = @"...\FootballProject\Images";
                    try
                    {
                        openfile.InitialDirectory = path;
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message);
                    }
                    openfile.FileOk += Openfile_FileOk;
                    if (openfile.ShowDialog() == DialogResult.OK)
                    {
                        if (p as Window1 != null)
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

        void RandomSquad(string iddoibong)
        {
            string query = "BEGIN " +
                "DECLARE @idcauthu int, " +
                "@length int, @iddoibong varchar(10) " +
                "SET @length = 11 " +
                "SET @iddoibong = '" + iddoibong + "'" +
                " DELETE FROM DOIHINHCHINH where IDDOIBONG = @iddoibong " +
                "while @length > 0 " +
                "BEGIN " +
                "SELECT @idcauthu = ID FROM (SELECT ROW_NUMBER() OVER (ORDER BY ID) row, ID\r\n\t\t\tFROM CAUTHU\r\n\t\t\twhere IDDOIBONG = @iddoibong\r\n\t\t)t\r\n\t\twhere t.ROW = 1 + (SELECT CAST(RAND()*COUNT(*) AS INT) FROM CAUTHU WHERE IDDOIBONG = @iddoibong)\r\n\t\twhile @idcauthu in (SELECT IDCAUTHU FROM DOIHINHCHINH)\r\n\t\tBEGIN\r\n\t\t\tSELECT @idcauthu = ID\r\n\t\tFROM (\r\n\t\t\tSELECT ROW_NUMBER() OVER (ORDER BY ID) row, ID\r\n\t\t\tFROM CAUTHU\r\n\t\t\twhere IDDOIBONG = @iddoibong\r\n\t\t)t\r\n\t\twhere t.ROW = 1 + (SELECT CAST(RAND()*COUNT(*) AS INT) FROM CAUTHU WHERE IDDOIBONG = @iddoibong)\r\n\t\tEND\r\n\t\tSET @length = @length - 1\r\n\t\t\t\t\r\n\t\r\n\t \r\n\t\tIF @length = 11 - 1 \r\n\t\tINSERT DOIHINHCHINH (IDDOIBONG, IDCAUTHU, VITRI) values(@iddoibong, @idcauthu, 'GK')\r\n\t\tIF @length < 10 AND @length >=8 \r\n\t\tINSERT DOIHINHCHINH (IDDOIBONG, IDCAUTHU, VITRI) values(@iddoibong, @idcauthu, 'CB')\r\n\t\tIF @length = 7\r\n\t\tINSERT DOIHINHCHINH (IDDOIBONG, IDCAUTHU, VITRI) values(@iddoibong, @idcauthu, 'LB')\r\n\t\tif @length = 6\r\n\t\tINSERT DOIHINHCHINH (IDDOIBONG, IDCAUTHU, VITRI) values(@iddoibong, @idcauthu, 'RB')\r\n\t\tif @length = 5\r\n\t\tINSERT DOIHINHCHINH (IDDOIBONG, IDCAUTHU, VITRI) values(@iddoibong, @idcauthu, 'CM')\r\n\t\tif @length = 4\r\n\t\tINSERT DOIHINHCHINH (IDDOIBONG, IDCAUTHU, VITRI) values(@iddoibong, @idcauthu, 'LM')\r\n\t\tif @length = 3\r\n\t\t\tINSERT DOIHINHCHINH (IDDOIBONG, IDCAUTHU, VITRI) values(@iddoibong, @idcauthu, 'RM')\r\n\t\tif @length = 2\r\n\t\tINSERT DOIHINHCHINH (IDDOIBONG, IDCAUTHU, VITRI) values (@iddoibong, @idcauthu, 'LW')\r\n\t\tif @length = 1\r\n\t\tINSERT DOIHINHCHINH (IDDOIBONG, IDCAUTHU, VITRI) values(@iddoibong, @idcauthu, 'RW')\r\n\t\tif @length = 0\r\n\t\tINSERT DOIHINHCHINH (IDDOIBONG, IDCAUTHU, VITRI) values(@iddoibong, @idcauthu, 'ST')\r\n\tEND\r\nEND";
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {

                        if (command.ExecuteNonQuery() >= 0)
                        {
                            System.Windows.Forms.MessageBox.Show(command.ExecuteNonQuery().ToString(), iddoibong);
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void SendEmail()
        {
            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("21520613@gm.uit.edu.vn", "YeuEmCMPUNK&195"),

            };
            MailMessage mail = new MailMessage("21520613@gm.uit.edu.vn", "baonhq2603@gmail.com", "Request for buying player", "Tôi muốn mua cầu thủ này");
            client.Send(mail);


        }

        private void Openfile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var x = sender as OpenFileDialog;
            string filename = x.FileName;

            if (Path.GetDirectoryName(filename) != x.InitialDirectory)
            {
                //System.Windows.MessageBox.Show(Path.GetDirectoryName(filename));
            }
        }
        private byte[] ConvertBitmaptoByteArray(BitmapImage bitmapImage)
        {

            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        void PullData()
        {

            string query = "SELECT ct.*, qt.TENQUOCGIA, db.TEN TenDoi FROM CAUTHU ct join QUOCTICH QT on ct.IDQUOCTICH = qt.ID join DOIBONG db on ct.IDDOIBONG = db.ID";

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

            string query = "SELECT cn.*, ct.*, qt.TENQUOCGIA, db.TEN TenDoi FROM CHUYENNHUONG cn join CAUTHU ct on cn.IDCAUTHU = ct.ID join  QUOCTICH qt on ct.IDQUOCTICH = qt.ID JOIN DOIBONG db on ct.IDDOIBONG = db.ID where ct.IDDOIBONG <> 'MU'";

            dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
            transferPlayers.Clear();
        }

        void PullClubData()
        {
            string query = "SELECT ct.*, qt.TENQUOCGIA, db.TEN TenDoi FROM CAUTHU ct join QUOCTICH QT on ct.IDQUOCTICH = qt.ID join DOIBONG db on ct.IDDOIBONG = db.ID WHERE IDDOIBONG = 'mu'";
            dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
            clubPlayerList.Clear();
        }
        void PutClubDataToList()
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                Player player = new Player();
                player.Id = dr["ID"].ToString();
                player.ClubID = dr["IDDOIBONG"].ToString();
                player.Club = dr["TenDoi"].ToString();
                player.Nationality = dr["TENQUOCGIA"].ToString();
                player.Name = dr["HOTEN"].ToString();
                player.Age = Convert.ToInt32(dr["TUOI"]);
                player.LeaguesNum = Convert.ToInt32(dr["SOGIAI"]);
                player.Goals = Convert.ToInt32(dr["SOBANTHANG"]);
                player.Foot = dr["CHANTHUAN"].ToString();
                player.Physique = dr["THETRANG"].ToString();
                player.Height = dr["CHIEUCAO"].ToString();
                player.Weight = dr["CANNANG"].ToString();
                player.Price = dr["GIATRICAUTHU"].ToString();
                player.Position = dr["VITRI"].ToString();
                int n;
                if (int.TryParse(dr["SOAO"].ToString(), out n))
                    player.KitNumber = Convert.ToInt32(dr["SOAO"]);
                if (!Convert.IsDBNull(dr["HINHANH"]))
                    player.Image = (byte[])dr["HINHANH"];
                clubPlayerList.Add(player);

            }
        }

        void PutDataTolist()
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                Player player = new Player();
                player.Id = dr["ID"].ToString();
                player.ClubID = dr["IDDOIBONG"].ToString();

                player.Club = dr["TenDoi"].ToString();

                player.Nationality = dr["TENQUOCGIA"].ToString();
                player.Name = dr["HOTEN"].ToString();
                player.Age = Convert.ToInt32(dr["TUOI"]);
                player.LeaguesNum = Convert.ToInt32(dr["SOGIAI"]);
                player.Goals = Convert.ToInt32(dr["SOBANTHANG"]);
                player.Foot = dr["CHANTHUAN"].ToString();
                player.Physique = dr["THETRANG"].ToString();
                player.Height = dr["CHIEUCAO"].ToString();
                player.Weight = dr["CANNANG"].ToString();

                player.Price = dr["GIATRICAUTHU"].ToString();
                player.Position = dr["VITRI"].ToString();
                int n;
                if (int.TryParse(dr["SOAO"].ToString(), out n))
                    player.KitNumber = Convert.ToInt32(dr["SOAO"]);

                if (!Convert.IsDBNull(dr["HINHANH"]))
                    player.Image = (byte[])dr["HINHANH"];
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

                player.Club = dr["TenDoi"].ToString();

                player.Nationality = dr["TENQUOCGIA"].ToString();
                player.Name = dr["HOTEN"].ToString();
                player.Age = Convert.ToInt32(dr["TUOI"]);
                player.LeaguesNum = Convert.ToInt32(dr["SOGIAI"]);
                player.Goals = Convert.ToInt32(dr["SOBANTHANG"]);
                player.Foot = dr["CHANTHUAN"].ToString();
                player.Physique = dr["THETRANG"].ToString();
                player.Height = dr["CHIEUCAO"].ToString();
                player.Weight = dr["CANNANG"].ToString();

                player.Price = dr["GIATRICAUTHU"].ToString();
                player.Position = dr["VITRI"].ToString();
                int n;
                if (int.TryParse(dr["SOAO"].ToString(), out n))
                    player.KitNumber = Convert.ToInt32(dr["SOAO"]);

                if (!Convert.IsDBNull(dr["HINHANH"]))
                    player.Image = (byte[])dr["HINHANH"];
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

        string club;
        public string Club { get { return club; } set { club = value; OnPropertyChanged(); } }

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

        int kitNumber;
        public int KitNumber { get { return kitNumber; } set { kitNumber = value; OnPropertyChanged(); } }

        string price;
        public string Price { get { return price; } set { price = value; OnPropertyChanged(); } }
        private byte[] image;
        public byte[] Image { get { return image; } set { image = value; OnPropertyChanged(); } }
    }
}


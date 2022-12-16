using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FootBallProject
{
    /// <summary>
    /// Interaction logic for DS_BLD.xaml
    /// </summary>
    public partial class DS_BLD : Window
    {
        public string connectstr = "Data Source=LAPTOP-SCVD25EQ\\SQLEXPRESS;Database=FOOTBALLMANAGER2;Trusted_Connection=True;";
        public List<BLD> bLDs = new List<BLD>();
        public DS_BLD()
        {
            InitializeComponent();
        }

        public class BLD
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public DateTime Dateofbirth { get; set; }
            public string Position { get; set; }
            public string Mailcontact { get; set; }
            public string Nationality { get; set; }
            public string IDdoibong { get; set; }
            public BLD(string iD, string name, DateTime dateofbirth, string position, string mailcontact, string nationality)
            {
                ID = iD;
                Name = name;
                Dateofbirth = dateofbirth;
                Position = position;
                Mailcontact = mailcontact;
                Nationality = nationality;
            }
        }

        private void ReadOrderData(string connectionString)
        {
            bLDs.Clear();
            string queryString = "SELECT * FROM dbo.HUANLUYENVIEN hlv JOIN dbo.QUOCTICH qt ON hlv.IDQUOCTICH = qt.ID";
            string str = "";
            string lower = iddoibong.Text.ToLower();
            if(iddoibong.Text == "" || lower == "all")
            {
                str = "";
            }
            else
            {
                str = " WHERE hlv.IDDOIBONG = " + "'" + iddoibong.Text + "'";
            }
            string newString = queryString + str;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(newString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader);
                }
                reader.Close();
            }
        }
        private void ReadSingleRow(IDataRecord dataRecord)
        {
            BLD bLD = new BLD(dataRecord[0].ToString(), (string)dataRecord[3], (DateTime)dataRecord[6], (string)dataRecord[7], (string)dataRecord[5], dataRecord[10].ToString());
            bLD.IDdoibong = (string)dataRecord[1];
            bLDs.Add(bLD);
        }

        //private void Button_Click_ExportExcel(object sender, RoutedEventArgs e)
        //{
            
        //}

        private void AddNewPerson_Click(object sender, RoutedEventArgs e)
        {
            DS_BLD_ADD dsadd = new DS_BLD_ADD();
            dsadd.ShowDialog();
        }

        private void DTG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            BLD bLD = dg.SelectedItem as BLD;
            BLD_Appear bLD_Appear = new BLD_Appear();
            //bLD_Appear.Init(bLD.IDdoibong, bLD.Name, bLD.Dateofbirth, bLD.Position, bLD.Mailcontact, bLD.Nationality);
            bLD_Appear.ShowDialog();
        }

        private void _Load_Click(object sender, RoutedEventArgs e)
        {
            ReadOrderData(connectstr);
            DTG.ItemsSource = bLDs;
            DTG.Items.Refresh();
        }
    }
}

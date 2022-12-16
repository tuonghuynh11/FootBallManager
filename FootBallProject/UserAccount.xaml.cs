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
using System.Configuration;

namespace FootBallProject
{
    /// <summary>
    /// Interaction logic for UserAccount.xaml
    /// </summary>
    public partial class UserAccount : Window
    {
        public string connectstr2 = ConfigurationManager.ConnectionStrings["connectstr2"].ConnectionString;
        public string usr = "newuser"; // Lay du lieu tu luc dang nhap
        public UserAccount()
        {
            InitializeComponent();
            ReadOrderData(connectstr2);

        }

        public class User_Account
        {
            public string username { get; set; }
            public string password { get; set; }
            public string name { get; set; }
            public string gmail { get; set; }
            public User_Account(string username, string password, string name, string gmail)
            {
                this.username = username;
                this.password = password;
                this.name = name;
                this.gmail = gmail;
            }
        }

        private void Close_but_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ReadOrderData(string connectionString)
        {
            string queryString = "SELECT * FROM dbo._USER WHERE USERNAME=" + "'" + usr + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txbhoten.Text = reader.GetString(2);
                    txbhusername.Text = reader.GetString(0);
                    pbpass.Password = reader.GetString(1);
                    txbemail.Text = reader.GetString(3);
                }
                reader.Close();
            }
        }

        private void Change_Pass_Click_1(object sender, RoutedEventArgs e)
        {
            ChangePass change = new ChangePass();
            change.oldpass = pbpass.Password;
            change.ShowDialog();
            ReadOrderData(connectstr2);
        }
        private void HandleInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }
    }
}

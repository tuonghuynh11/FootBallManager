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
    /// Interaction logic for ChangePass.xaml
    /// </summary>
    public partial class ChangePass : Window
    {
        public string connectstr2 = ConfigurationManager.ConnectionStrings["connectstr2"].ConnectionString;
        public string usr = "newuser"; // Lay du lieu tu luc dang nhap
        public string oldpass = "";
        public ChangePass()
        {
            InitializeComponent();
        }

        private void Close_but_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Oldpass.Password != oldpass)
            {
                Error error = new Error();
                error.ShowDialog();
            }
            else if (newPass.Password == oldpass)
            {
                Error error = new Error();
                error.ShowDialog();
            }
            else if (newPass.Password != xacnhan.Password)
            {
                Error error = new Error();
                error.ShowDialog();
            }
            else
            {
                oldpass = xacnhan.Password;
                string commandText = "UPDATE dbo._USER SET USERPASSWORD = @userpassword WHERE USERNAME = " + "'" + usr + "'";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectstr2))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(commandText, connection))
                        {
                            command.Parameters.Add("@userpassword", SqlDbType.VarChar);
                            command.Parameters["@userpassword"].Value = xacnhan.Password;

                            command.ExecuteNonQuery();
                        }
                    }
                    Success success = new Success();
                    success.ShowDialog();
                    this.Close();
                }
                catch (Exception)
                {
                    Error error = new Error();
                    error.ShowDialog();
                }
            }
        }
    }
}

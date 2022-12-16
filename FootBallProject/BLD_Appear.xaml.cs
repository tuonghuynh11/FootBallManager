using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for BLD_Appear.xaml
    /// </summary>
    public partial class BLD_Appear : Window
    {
        public string id;
        public string connectstr = ConfigurationManager.ConnectionStrings["connectstr"].ConnectionString;
        public BLD_Appear()
        {
            InitializeComponent();
        }
        public void Init(string Iddoibong, string name, DateTime dateofbirth, string position,string mailcontact, string nationality, ImageSource imgs)
        {
            tbID.Text = Iddoibong;
            tbht.Text = name;
            string temp = dateofbirth.ToString();
            temp = temp.Substring(0, temp.IndexOf(" "));
            nsdp.Text = temp;
            tbcv.Text = position;
            tbdc.Text = mailcontact;
            tbqt.Text = nationality;
            if (imgs != null)
            {
                bldimg.Source = imgs;
            }
        }

        private void Close_but_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            string commandText = "DELETE FROM dbo.HUANLUYENVIEN WHERE ID = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectstr))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {

                        command.Parameters.Add("@id", SqlDbType.VarChar);
                        command.Parameters["@id"].Value = id;

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

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
using static FootBallProject.DS_BLD;

namespace FootBallProject
{
    /// <summary>
    /// Interaction logic for DS_BLD_ADD.xaml
    /// </summary>
    public partial class DS_BLD_ADD : Window
    {
        public string connectstr = "Data Source=LAPTOP-SCVD25EQ\\SQLEXPRESS;Database=FOOTBALLMANAGER2;Trusted_Connection=True;";
        public DS_BLD_ADD()
        {
            InitializeComponent();
        }

        private void AddNewPerson_2_Click(object sender, RoutedEventArgs e)
        {
            string commandText = "INSERT INTO dbo.HUANLUYENVIEN (IDDOIBONG,HOTEN, GMAIL, NGAYSINH, CHUCVU, IDQUOCTICH) VALUES (@iddoibong,@hoten, @gmail, @ngaysinh, @chucvu, @idquoctich);";
            if (tbqt.Text == "" || tbID.Text == "" || tbdc.Text == "" || nsdp.ToString() == "" || tbcv.Text == "" || tbqt.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin");
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectstr))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(commandText, connection))
                        {
                            command.Parameters.Add("@iddoibong", SqlDbType.VarChar);
                            command.Parameters["@iddoibong"].Value = tbID.Text;

                            command.Parameters.Add("@hoten", SqlDbType.NVarChar);
                            command.Parameters["@hoten"].Value = tbht.Text;

                            command.Parameters.Add("@gmail", SqlDbType.VarChar);
                            command.Parameters["@gmail"].Value = tbdc.Text;

                            command.Parameters.Add("@ngaysinh", SqlDbType.SmallDateTime);
                            command.Parameters["@ngaysinh"].Value = nsdp.ToString();

                            command.Parameters.Add("@chucvu", SqlDbType.NVarChar);
                            command.Parameters["@chucvu"].Value = tbcv.Text;

                            command.Parameters.Add("@idquoctich", SqlDbType.Int);
                            command.Parameters["@idquoctich"].Value = tbqt.Text;

                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Đã thêm thành công");
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR");
                }
            }
        }
    }
}

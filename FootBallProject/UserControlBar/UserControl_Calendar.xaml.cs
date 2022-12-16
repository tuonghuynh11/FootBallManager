﻿using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static FootBallProject.Calendar;
using System.Configuration;

namespace FootBallProject.UserControlBar
{
    /// <summary>
    /// Interaction logic for UserControl_Calendar.xaml
    /// </summary>
    public partial class UserControl_Calendar : UserControl
    {
        public string connectstr = ConfigurationManager.ConnectionStrings["connectstr"].ConnectionString;
        public List<DS_Cal> Cals = new List<DS_Cal>();
        public string chosendate;
        public string chosenyear;
        public string chosenmonth;
        public string chosenday;
        public int givenlist;
        public UserControl_Calendar()
        {
            InitializeComponent();
            ReadOrderData2(connectstr);
        }
        public class DS_Cal
        {
            public bool IsDone { get; set; }
            public string TimeStart { get; set; }
            public string TimeEnd { get; set; }
            public string Work { get; set; }
            public string Name { get; set; }
            public string Ghichu { get; set; }
            public int id { get; set; }
            public DS_Cal(bool isDone, string timeStart, string timeEnd, string work)
            {
                IsDone = isDone;
                TimeStart = timeStart;
                TimeEnd = timeEnd;
                Work = work;
            }
        }

        private void NewNote_Click(object sender, RoutedEventArgs e)
        {
            if (cbID.Text == "")
            {
                Error error = new Error();
                error.ShowDialog();
            }
            else
            {
                DS_Cal dS_Cal = new DS_Cal(false, "0:00:00 AM", "0:00:00 AM", "Công việc");
                dS_Cal.Ghichu = "Ghi chú";
                Cals.Add(dS_Cal);
                DTGTime.Items.Refresh();
                DTGGhichu.Items.Refresh();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (cbID.Text == "")
            {
                Error error = new Error();
                error.ShowDialog();
                return;
            }
            string GetIDDOIBONG = cbID.Text;
            GetIDDOIBONG = GetIDDOIBONG.Substring(0, GetIDDOIBONG.IndexOf('.'));
            int i = 0;

            foreach (DS_Cal cal in Cals)
            {
                if (i < givenlist)
                {
                    i++;
                    string iD = cal.id.ToString();
                    string commandText2 = "UPDATE dbo.TAPLUYEN SET TRANGTHAI=@trangthai, THOIGIANBATDAU=@thoigianbatdau, THOIGIANKETTHUC=@thoigianketthuc, HOATDONG=@hoatdong, " +
                        "GHICHU=@ghichu WHERE ID = " + "'" + iD + "'";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectstr))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(commandText2, connection))
                            {
                                command.Parameters.Add("@trangthai", SqlDbType.NVarChar);
                                command.Parameters["@trangthai"].Value = cal.IsDone.ToString();

                                command.Parameters.Add("@thoigianbatdau", SqlDbType.SmallDateTime);
                                command.Parameters["@thoigianbatdau"].Value = chosendate + " " + cal.TimeStart.ToString();

                                command.Parameters.Add("@thoigianketthuc", SqlDbType.SmallDateTime);
                                command.Parameters["@thoigianketthuc"].Value = chosendate + " " + cal.TimeEnd.ToString();

                                command.Parameters.Add("@hoatdong", SqlDbType.NVarChar);
                                command.Parameters["@hoatdong"].Value = cal.Work;

                                command.Parameters.Add("@ghichu", SqlDbType.NVarChar);
                                command.Parameters["@ghichu"].Value = cal.Ghichu;


                                command.ExecuteNonQuery();
                            }
                        }
                    }
                        catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Error error = new Error();
                        error.ShowDialog();
                    }
                }
                else
                {
                    string commandText1 = "INSERT INTO dbo.TAPLUYEN (TRANGTHAI, THOIGIANBATDAU, THOIGIANKETTHUC, HOATDONG, GHICHU, IDDOIBONG) VALUES (@trangthai, @thoigianbatdau, @thoigianketthuc, " +
                            "@hoatdong, @ghichu, @iddoibong);";
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectstr))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(commandText1, connection))
                            {
                                command.Parameters.Add("@trangthai", SqlDbType.NVarChar);
                                command.Parameters["@trangthai"].Value = cal.IsDone.ToString();

                                command.Parameters.Add("@thoigianbatdau", SqlDbType.SmallDateTime);
                                command.Parameters["@thoigianbatdau"].Value = chosendate + " " + cal.TimeStart.ToString();

                                command.Parameters.Add("@thoigianketthuc", SqlDbType.SmallDateTime);
                                command.Parameters["@thoigianketthuc"].Value = chosendate + " " + cal.TimeEnd.ToString();

                                command.Parameters.Add("@hoatdong", SqlDbType.NVarChar);
                                command.Parameters["@hoatdong"].Value = cal.Work;

                                command.Parameters.Add("@ghichu", SqlDbType.NVarChar);
                                command.Parameters["@ghichu"].Value = cal.Ghichu;

                                command.Parameters.Add("@iddoibong", SqlDbType.VarChar);
                                command.Parameters["@iddoibong"].Value = GetIDDOIBONG;


                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Error error = new Error();
                        error.ShowDialog();
                    }
                }
            }
            Success success = new Success();
            success.ShowDialog();
        }

        private void PresetTimePicker_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            DS_Cal dt = DTGTime.SelectedItems[0] as DS_Cal;
            TimePicker timePicker = sender as TimePicker;
            timePicker.SelectedTimeFormat = DatePickerFormat.Short;
            string a = timePicker.SelectedTime.ToString();
            string b = a.Substring(a.IndexOf(" "));
            dt.TimeStart = b;
        }

        private void Calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbID.Text == "")
            {
                Error error = new Error();
                error.ShowDialog();
            }
            else
            {
                chosendate = Calendar1.SelectedDate.Value.ToString("yyyy-MM-dd");
                int index = chosendate.IndexOf("-");
                chosenyear = chosendate.Substring(0, index);
                int index2 = chosendate.IndexOf("-", index + 1);
                chosenmonth = chosendate.Substring(index + 1, index2 - index - 1);
                chosenday = chosendate.Substring(index2 + 1);
                ReadOrderData(connectstr);
                DTGTime.ItemsSource = Cals;
                DTGGhichu.ItemsSource = Cals;
                DTGGhichu.Items.Refresh();
                DTGTime.Items.Refresh();
            }
        }

        private void ReadOrderData(string connectionString)
        {
            string GetIDDOIBONG = cbID.Text;
            GetIDDOIBONG = GetIDDOIBONG.Substring(0, GetIDDOIBONG.IndexOf('.'));
            Cals.Clear();
            givenlist = 0;
            string queryString = "SELECT * FROM dbo.TAPLUYEN tl";
            string newString = queryString + " WHERE YEAR(tl.THOIGIANBATDAU) = " + chosenyear + " AND MONTH(tl.THOIGIANBATDAU) = " + chosenmonth +
                " AND DAY(tl.THOIGIANBATDAU) = " + chosenday + " AND tl.IDDOIBONG = " + "'" + GetIDDOIBONG + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(newString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    givenlist++;
                    ReadSingleRow((IDataRecord)reader);
                }
                reader.Close();
            }
        }

        private void ReadSingleRow(IDataRecord dataRecord)
        {
            DS_Cal cal = new DS_Cal(false, dataRecord[4].ToString(), dataRecord[5].ToString(), (string)dataRecord[6]);
            string temp = (string)dataRecord[3];
            temp = temp.ToLower();
            if (temp == "false")
            {
                cal.IsDone = false;
            }
            else
            {
                cal.IsDone = true;
            }
            cal.id = (int)dataRecord[0];
            cal.Ghichu = (string)dataRecord[7];
            cal.TimeStart = cal.TimeStart.Substring(cal.TimeStart.IndexOf(" "));
            cal.TimeEnd = cal.TimeEnd.Substring(cal.TimeEnd.IndexOf(" "));
            Cals.Add(cal);
        }

        private void PresetTimePicker_SelectedTimeChanged_1(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            DS_Cal dt = DTGTime.SelectedItems[0] as DS_Cal;
            TimePicker timePicker = sender as TimePicker;
            timePicker.SelectedTimeFormat = DatePickerFormat.Short;
            string a = timePicker.SelectedTime.ToString();
            string b = a.Substring(a.IndexOf(" "));
            dt.TimeEnd = b;
        }

        private void ReadOrderData2(string connectionString)
        {
            string queryString = "SELECT * FROM dbo.DOIBONG";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string tmp = reader.GetString(0) + ". " + reader.GetString(4);
                    cbID.Items.Add(tmp);
                }
                reader.Close();
            }
        }
    }
}


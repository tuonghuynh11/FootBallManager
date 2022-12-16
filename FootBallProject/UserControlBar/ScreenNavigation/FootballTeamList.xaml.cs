using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using FootBallProject.Model;
using FootBallProject.PopUp;
using FootBallProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
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

namespace FootBallProject.UserControlBar.ScreenNavigation
{
    /// <summary>
    /// Interaction logic for FootballTeamList.xaml
    /// </summary>
    public partial class FootballTeamList : UserControl
    {
        //Lưu ảnh
        public static byte[] buffer;
        //Lưu ảnh
        public FootballTeamListViewModel footballTeamListViewModel;
        public FootballTeamList()
        {
            InitializeComponent();
            this.DataContext = footballTeamListViewModel=new FootballTeamListViewModel();

            //Tùy chọn tìm kiếm comboBox
            List<string> header = new List<String>();
            header.Add("ID đội bóng");
            header.Add("Tên đội bóng");
            header.Add("Huấn luyện viên");
            cbSearchColumn.ItemsSource = header;
            DatePicker datePicker = new DatePicker();
            
        }

        private void cbSearchColumn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            if (combobox.SelectedItem.ToString() == "ID đội bóng")
            {
                tbviewCLB.SearchColumns = "ID";
            }
            else if (combobox.SelectedItem.ToString() == "Tên đội bóng")
            {
                tbviewCLB.SearchColumns = "TEN";
            }

            else if (combobox.SelectedItem.ToString() == "Huấn luyện viên")
            
            {
                tbviewCLB.SearchColumns = "HLV";

            }
           
        }
        //thêm đội bóng
        private void addbttClick(object sender, RoutedEventArgs e)
        {
            tbviewCLB.NewItemRowPosition= NewItemRowPosition.Top;
            tbviewCLB.AddNewRow();
            
        }
        //xóa đội bóng
        private void deletebt_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            List<int> selectedRowHandles = new List<int>(tbviewCLB.Grid.GetSelectedRowHandles());
            var descendingOrder = selectedRowHandles.OrderByDescending(i => i);
            foreach (int handle in descendingOrder)
            {
                DOIBONG item = tbviewCLB.SelectedRows[count] as DOIBONG;
                OKCancelPopUp pop = new OKCancelPopUp();
                pop.ShowDialog();
                if (pop.Ok==1)
                {
                    try
                    {
                        DataProvider.ins.DB.DOIBONGs.Remove(item);
                        DataProvider.ins.DB.SaveChanges();
                        tbviewCLB.DeleteRow(handle);

                    }
                    catch (Exception)
                    {

                        PopUpCustom error = new PopUpCustom("Lỗi", "Đội bóng đang có cầu thủ không thể xóa!!");
                        error.ShowDialog();
                    }
                }
                else
                {
                    return;
                }
               

                count++;
            }
        }

        private void tbviewCLB_RowEditFinished(object sender, RowEditFinishedEventArgs e)
        {
            tbviewCLB.NewItemRowPosition = NewItemRowPosition.None;
        }


        //Update đội bóng
        private void tbviewCLB_ValidateRow(object sender, GridRowValidationEventArgs e)
        {
            var doibong = (DOIBONG)e.Row;
            DOIBONG result = DataProvider.ins.DB.DOIBONGs.SingleOrDefault(b => b.ID == doibong.ID);
            if (result != null)
            {
                result.TEN = doibong.TEN;
                result.NGAYTHANHLAP =doibong.NGAYTHANHLAP;
                result.HINHANH = buffer;
                DataProvider.ins.DB.SaveChanges();
            }
        }
        /// <summary>
        /// Convert Image to bitmap lưu vào database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ImageEditSettings_ConvertEditValue(DependencyObject sender, ConvertEditValueEventArgs args)
        {
            if (args.ImageSource!=null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)args.ImageSource));
                    encoder.Save(stream);
                    args.EditValue = stream.ToArray();
                    buffer = stream.ToArray();
                    args.Handled = true;
                }
            }
           
        }

        private void ExportExcelbt_Click(object sender, RoutedEventArgs e)
        {
         
            tbviewCLB.ExportToXlsx(@"d:\DanhSachDoiBong.xlsx");
            Process.Start(@"d:\DanhSachDoiBong.xlsx");
            
        }
        //Xử lý chon thành phố
        private void tbviewCLB_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "QUOCGIA")
            {
                string a = e.Value.ToString();
                var b = DataProvider.ins.DB.Database.SqlQuery<QUOCTICH>("SELECT * FROM QUOCTICH WHERE TENQUOCGIA = @ID ", new SqlParameter("@ID", a)).FirstOrDefault<QUOCTICH>();
                var c = DataProvider.ins.DB.Database.SqlQuery<DIADIEM>("SELECT * FROM DIADIEM WHERE IDQUOCGIA = @ID ", new SqlParameter("@ID", b.ID));
                footballTeamListViewModel.ThanhPhoList = c.Select(p => p.TENDIADIEM).ToList();

            }
        }
    }
}

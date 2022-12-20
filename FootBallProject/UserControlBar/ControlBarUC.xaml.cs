using FootBallProject.ViewModel;
using System;
using System.Collections.Generic;
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

namespace FootBallProject.UserControlBar
{
    /// <summary>
    /// Interaction logic for ControlBarUC.xaml
    /// </summary>
    public partial class ControlBarUC : UserControl
    {
        public ControlBarViewModel ViewModel { get; set; }
        public ControlBarUC()
        {
            InitializeComponent();
            this.DataContext = ViewModel = new ControlBarViewModel();
        }

        private void Accountcbb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            ComboBoxItem select = (ComboBoxItem)combo.SelectedItem;
            if (select!=null)
            {
                if (select.Content.ToString() == "Thông tin tài khoản")
                {
                    UserAccount userAccount = new UserAccount();
                    userAccount.ShowDialog();
                    combo.SelectedIndex = -1;
                }
                else if (select.Content.ToString() == "Đăng xuất")
                {
                    FrameworkElement window = GetWindowParent(this);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.Close();
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.ShowDialog();
                    }

                    ///lỗi không xuất hiện màn hình
                }

            }

        }
        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {

                parent = parent.Parent as FrameworkElement;

            }
            return parent;
        }
    }
}

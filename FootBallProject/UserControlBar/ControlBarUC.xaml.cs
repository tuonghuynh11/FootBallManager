using FootBallProject.Class;
using FootBallProject.Model;
using FootBallProject.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using System.Diagnostics;
namespace FootBallProject.UserControlBar
{
    /// <summary>
    /// Interaction logic for ControlBarUC.xaml
    /// </summary>
    public partial class ControlBarUC : UserControl
    {
        //So sánh sự thay đổi của database
        List<Notification> data1;
        List<Notification> data2;
        int flag = 0;
        int newnotifies=0;
        //So sánh sự thay đổi của database
        public ObservableCollection<Notification> Notifies { get; set; }
        public ControlBarViewModel ViewModel { get; set; }
        public ControlBarUC()
        {
            InitializeComponent();
            this.DataContext = ViewModel = new ControlBarViewModel();
            UserNamelb.Content = USER.USERN;

            int uncheck = DataProvider.ins.DB.Notifications.Where(p => p.IDHLV == AccessUser.userLogin.IDNHANSU && p.CHECKED == "Chưa xem").ToList().Count();
            numberofnotifies.Badge = uncheck;
            notifipopup.ToolTip = $"Bạn có {uncheck} thông báo mới";
            Notifies = new ObservableCollection<Notification>(DataProvider.ins.DB.Notifications.Where(p=>p.IDHLV==AccessUser.userLogin.IDNHANSU).OrderByDescending(p => p.CHECKED).OrderByDescending(p => p.ID));
            lvUsers.ItemsSource = Notifies;
            //Group thông báo
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CHECKED");
            view.GroupDescriptions.Add(groupDescription);
            //Timer 
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3.5);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Catch();
        }
        public void Catch()
        {
            
            data1 = DataProvider.ins.Database.Notifications.ToList();
            if (flag == 0)
            {
                flag = 1;
                data2 = data1;
                return;
            }
            else
            {
                if (data1.Count() != data2.Count())
                {
                   List<Notification> list = new List<Notification>();
                    for (int i = data2.Count(); i < data1.Count(); i++)
                    {
                        list.Add(data1[i]);
                    }
                    //Thông báo mới
                     newnotifies = list.Where(p => p.IDHLV == AccessUser.userLogin.IDNHANSU).Count() ;
                    //Thông báo mới
                    if (newnotifies>0)
                    {
                        int uncheck = DataProvider.ins.DB.Notifications.Where(p => p.IDHLV == AccessUser.userLogin.IDNHANSU && p.CHECKED == "Chưa xem").ToList().Count();
                        numberofnotifies.Badge = uncheck;
                        notifipopup.ToolTip = $"Bạn có {newnotifies} thông báo mới";
                        Notifies = new ObservableCollection<Notification>(DataProvider.ins.DB.Notifications.Where(p => p.IDHLV == AccessUser.userLogin.IDNHANSU).OrderByDescending(p => p.CHECKED).OrderByDescending(p => p.ID));
                        lvUsers.ItemsSource = Notifies;
                        //Group thông báo
                        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
                        PropertyGroupDescription groupDescription = new PropertyGroupDescription("CHECKED");
                        view.GroupDescriptions.Add(groupDescription);
                    }
                   
                }
            }
            data2 = data1;

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

                    Window window = Application.Current.MainWindow as Window;

                    if (window != null)
                    {
                        LoginWindow mainWindow = new LoginWindow();
                        Application.Current.MainWindow = mainWindow;
                        Application.Current.MainWindow.Show();
                        window.Close();
                    }
                   
                  

                }

            }

        }


        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            Notification notification = listView.SelectedItem as Notification;
            notification.CHECKED = "Đã xem";
            DataProvider.ins.DB.SaveChanges();
        }

        private void notifipopup_Opened(object sender, RoutedEventArgs e)
        {
            int uncheck = DataProvider.ins.DB.Notifications.Where(p => p.IDHLV == AccessUser.userLogin.IDNHANSU && p.CHECKED == "Chưa xem").ToList().Count();
            numberofnotifies.Badge = uncheck;
            Notifies = new ObservableCollection<Notification>(DataProvider.ins.DB.Notifications.Where(p => p.IDHLV == AccessUser.userLogin.IDNHANSU).OrderByDescending(p => p.CHECKED).OrderByDescending(p => p.ID));
            lvUsers.ItemsSource = Notifies;
            //Group thông báo
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CHECKED");
            view.GroupDescriptions.Add(groupDescription);
        }

        private void notifipopup_Closed(object sender, RoutedEventArgs e)
        {
            int uncheck = DataProvider.ins.DB.Notifications.Where(p => p.IDHLV == AccessUser.userLogin.IDNHANSU && p.CHECKED == "Chưa xem").ToList().Count();
            numberofnotifies.Badge = uncheck;
            notifipopup.ToolTip = $"Bạn có {uncheck} thông báo mới";

        }
    }
  
}

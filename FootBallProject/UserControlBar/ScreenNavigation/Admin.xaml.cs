using FootBallProject.Model;
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

namespace FootBallProject.UserControlBar.ScreenNavigation
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : UserControl
    {
        int t1 = 1;
        int tm = 2;
        int t2 = 3;
        public Admin()
        {
            InitializeComponent();
            this.DataContext = new AdminScreenViewModel();
            Random r = new Random();



            List<Teams> list = new List<Teams>();
            List<Teams> list1 = new List<Teams>();
            List<Teams> list2 = new List<Teams>();
            List<Players> listPlayer = new List<Players>();


            //list.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            //list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            //list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            //list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 10, Lost = 1, Ga = 10, Gd = 11 });

            list2.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 10, Lost = 1, Ga = 10, Gd = 11 });

            listPlayer.Add(new Players() { Name = "Erling Haaland", Image = @"/images/4.jpg", brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            listPlayer.Add(new Players() { Name = "Cristiano Ronaldo", Image = @"/images/1.jpg", brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            listPlayer.Add(new Players() { Name = "Kervin De Bruyne", Image = @"/images/5.jpg", brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            listPlayer.Add(new Players() { Name = "Lionel Messi", Image = @"/images/3.jpg", brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            listPlayer.Add(new Players() { Name = "Roberto Carlos", Image = @"/images/7.jpg", brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
           
          //   lsTranDau.ItemsSource = list;
            lvBestTeams.ItemsSource = list1;

        }

        private void bttFoward(object sender, RoutedEventArgs e)
        {
            if (t1 > 8)
            {
                t1 = t2 + 1;
            }
            if (tm > 8)
            {
                tm = t1;
            }
            if (t2 + 1 > 8)
            {
                t2 = 1;
            }

            Thumnail1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/" + (t2 + 1) + ".jpg"));

            ThumnailMain.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/" + (t1) + ".jpg"));


            Thumnail2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/" + (tm) + ".jpg"));

            tm = t1;
            t1 = t2 + 1;
            t2 = t2 + 1;
        }

        private void bttBack(object sender, RoutedEventArgs e)
        {
            if (t1 > 8)
            {
                t1 = tm;
            }
            if (tm > 8)
            {
                tm = t2;
            }
            if (t2 + 1 > 8)
            {
                t2 = 1;
            }



            Thumnail1.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/" + (tm) + ".jpg"));

            ThumnailMain.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/" + (t2) + ".jpg"));


            Thumnail2.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/" + (t2 + 1) + ".jpg"));



            t1 = tm;
            tm = t2;
            t2 = t2 + 1;
        }
        private void DsClb(object sender, RoutedEventArgs e)
        {
            DS_CLB dS_CLB = new DS_CLB();

            dS_CLB.Show();
        }

        private void DsGiaiDau(object sender, RoutedEventArgs e)
        {
            DS_GiaiDau dS_GiaiDau = new DS_GiaiDau();
            dS_GiaiDau.Show();
        }


        //Xem thông tin cầu thủ trong best players
        private void lvBestPlayers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        //Chi tiết trận đấu
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var tt = lsTranDau.SelectedItem as FOOTBALLMATCH;
            if (tt != null)
            {
                DOIBONG team1 = DataProvider.ins.DB.DOIBONGs.Find(tt.IDDOI1);
                DOIBONG team2 = DataProvider.ins.DB.DOIBONGs.Find(tt.IDDOI2);
                MatchInfomation matchInfomation = new MatchInfomation();
                MatchInformationViewModel matchInformationViewModel = new MatchInformationViewModel(team1, team2);
                matchInfomation.DataContext = matchInformationViewModel;
                matchInfomation.Show();
            }
           
        }
    }
}

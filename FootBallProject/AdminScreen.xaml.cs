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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FootBallProject
{
    /// <summary>
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {
        int t1 = 1;
        int tm = 2;
        int t2 = 3;
        public AdminScreen()
        {
            InitializeComponent();
            Random r = new Random();
           
            

            List<Team> list = new List<Team>();
            List<Team> list1 = new List<Team>();
            List<Players> listPlayer = new List<Players>();

            
            list.Add(new Team() { Name="Manchester City",logo= "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png",Win= 1,Draw= 10, Lost= 10, Ga= 10, Gd= 10 });
            list.Add(new Team() { Name="Real marid",logo= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list.Add(new Team() { Name="Real marid",logo= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list.Add(new Team() { Name="Real marid",logo= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s" , Win = 10, Draw = 10, Lost = 1, Ga = 10, Gd = 11 });

            list1.Add(new Team() { Name = "Manchester City", logo = @"/images/mancity.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10,brush= new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),(byte)r.Next(1, 255), (byte)r.Next(1, 233)))});
            list1.Add(new Team() { Name = "Real marid", logo = @"/images/logoReal.png", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11, brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            list1.Add(new Team() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10, brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            list1.Add(new Team() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 10, Lost = 1, Ga = 10, Gd = 11 , brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            list1.Add(new Team() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 10, Lost = 1, Ga = 10, Gd = 11, brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });


            listPlayer.Add(new Players() { Name= "Erling Haaland", Image =@"/images/4.jpg" , brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            listPlayer.Add(new Players() { Name= "Cristiano Ronaldo", Image =@"/images/1.jpg", brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            listPlayer.Add(new Players() { Name= "Kervin De Bruyne", Image =@"/images/5.jpg", brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            listPlayer.Add(new Players() { Name= "Lionel Messi", Image =@"/images/3.jpg", brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            listPlayer.Add(new Players() { Name= "Roberto Carlos", Image =@"/images/7.jpg", brush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233))) });
            lsCLB.ItemsSource = list;
            lsGiaiDau1.ItemsSource = list1;
            lsTranDau.ItemsSource = list;
            lvBestTeams.ItemsSource = list1;
            lvBestPlayers.ItemsSource = listPlayer;
        }

       

        private void GoNext(object sender, RoutedEventArgs e)
        {

            if (t1>8)
            {
                t1 = t2+1;
            }
            if (tm > 8)
            {
                tm = t1;
            }
            if (t2+1> 8)
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

        private void GoBack(object sender, RoutedEventArgs e)
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
    }
}
public class Team
{
    public string Name { get; set; }
    public string logo { get; set; }
    public int Win { get; set; }
    public int Draw { get; set; }
    public int Lost { get; set; }
    public int Ga { get; set; }
    public int Gd { get; set; }
    public Brush brush { get; set; }
   


}
public class Players
{
    public string Name { get; set; }
    public string Image { get; set; }
    public Brush brush { get; set; }
}
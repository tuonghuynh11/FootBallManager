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

namespace FootBallProject
{
    /// <summary>
    /// Interaction logic for TeamsPlayers.xaml
    /// </summary>
    public partial class TeamsPlayers : Window
    {
        List<Player> players;
        public TeamsPlayers()
        {
            InitializeComponent();
            players = new List<Player>();
            for(int i = 0; i < 10; i++)
                players.Add(new Player(9, "Erling Haaland", 22, "Norway", "Forward"));
            Players_List.ItemsSource = players;
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void TextBlock_MouseWheel(object sender, MouseWheelEventArgs e)
        {

        }

        private void Players_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RowDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
    public class Player
    {
        int number;
        string name;
        int age;
        string nationality;
        string position;
        public Player(int number = 0, string name = "", int age = 0, string nationality = "", string position = "")
        {
            this.number = number;
            this.name = name;
            this.age = age;
            this.nationality = nationality;
            this.position = position;
            
        }

        public int Number { get { return number; } set { number = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }

        public string Nationality { get { return nationality; } set { nationality = value; } }
        public string Position { get { return position; } set { position = value; } }


    }
}

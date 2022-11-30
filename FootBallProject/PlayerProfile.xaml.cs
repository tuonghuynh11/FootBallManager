using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FootBallProject
{
    /// <summary>
    /// Interaction logic for PlayerProfile.xaml
    /// </summary>
    public partial class PlayerProfile : Window
    {
        public PlayerProfile()
        {
            InitializeComponent();
            
           
        }
    }
    public class Statistics
    {
        int appearances;
        int goals;
        int assists;
        int left_foot;
        int right_foot;
        int head;
        public Statistics(int appearances = 0, int goals = 0, int assists = 0, int lfoot = 0, int rfoot = 0, int head = 0)
        {
            this.appearances = appearances;
            this.goals = goals;
            this.assists = assists;
            left_foot = lfoot;
            right_foot = rfoot;
            this.head = head;
        }
        public int Appearances { get { return appearances; } }
        public int Goals { get { return goals; } }
        public int Assists { get { return assists; } }
        public int Left_foot { get { return left_foot; } }
        public int Right_foot { get { return right_foot; } } 
        public int Head { get { return head; } }
    }
}

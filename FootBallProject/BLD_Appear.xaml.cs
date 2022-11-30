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
    /// Interaction logic for BLD_Appear.xaml
    /// </summary>
    public partial class BLD_Appear : Window
    {
        public BLD_Appear()
        {
            InitializeComponent();
        }
        public void Init(string Iddoibong, string name, DateTime dateofbirth, string position,string mailcontact, string nationality)
        {
            tbID.Text = Iddoibong;
            tbht.Text = name;
            string temp = dateofbirth.ToString();
            temp = temp.Substring(0, temp.IndexOf(" "));
            nsdp.Text = 
            tbcv.Text = position;
            tbdc.Text = mailcontact;
            tbqt.Text = nationality;
        }
    }
}

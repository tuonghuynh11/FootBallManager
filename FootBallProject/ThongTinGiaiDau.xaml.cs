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
using System.Windows.Shapes;

namespace FootBallProject
{
    /// <summary>
    /// Interaction logic for ThongTinGiaiDau.xaml
    /// </summary>
    public partial class ThongTinGiaiDau : Window
    {
        List<Teams> list1 = new List<Teams>();
        List<Teams> list2 = new List<Teams>();
        public string LeagueName { get; set; }

        public TournamentInformationViewModel tournamentInformation { get; set; }
        public ThongTinGiaiDau()
        {
            InitializeComponent();
        
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });

            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });


                  
        }
        public ThongTinGiaiDau(int id, string leagueName)
        {
            InitializeComponent();
            this.DataContext = tournamentInformation= new TournamentInformationViewModel(id);
            this.LeagueName = leagueName;
            this.titlebar.Tag = LeagueName;
            List<Teams> list = new List<Teams>();
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list1.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });

            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list2.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });


            list.Add(new Teams() { Name = "Manchester City", logo = "https://iconape.com/wp-content/png_logo_vector/manchester-city-logo.png", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 1, Lost = 10, Ga = 10, Gd = 11 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 1, Draw = 10, Lost = 10, Ga = 10, Gd = 10 });
            list.Add(new Teams() { Name = "Real marid", logo = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRfiEAOaEJTpbqplSJGTXqMZWdjUs8_Ne_y_JE0MRgy&s", Win = 10, Draw = 10, Lost = 1, Ga = 10, Gd = 11 });
            //dtgThongTinGiaDau.ItemsSource = list;
        }

       

        private void dtgThongTinGiaDau_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            THONGTINGIAIDAU teams = dataGrid.SelectedItem as THONGTINGIAIDAU;
            if (teams.TENDOIBONG == "Manchester City")
            {
                lsThongTinTranDau.ItemsSource = list1;
            }
            else if (teams.TENDOIBONG == "Real marid")
            {
                lsThongTinTranDau.ItemsSource = list2;

            }
            else
            {
                lsThongTinTranDau.ItemsSource = new List<Teams>();

            }
        }
    }
}

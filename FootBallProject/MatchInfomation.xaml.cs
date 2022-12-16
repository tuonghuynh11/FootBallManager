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
    /// Interaction logic for MatchInfomation.xaml
    /// </summary>
    public partial class MatchInfomation : Window
    {
        public MatchInformationViewModel matchInformation;
        public MatchInfomation()
        {
            InitializeComponent();
        }

        private void GTDHtbl_DOINHA_Loaded(object sender, RoutedEventArgs e)
        {
            var a = this.DataContext as MatchInformationViewModel;
            GTDHtbl_DOINHA.Text = String.Format("${0:n0}", double.Parse(a.Team1.GIATRI));
        }

        private void GTDHtbl_DOIKHACH_Loaded(object sender, RoutedEventArgs e)
        {
            var a = this.DataContext as MatchInformationViewModel;
            GTDHtbl_DOIKHACH.Text = String.Format("${0:n0}", double.Parse(a.Team2.GIATRI));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var a = this.DataContext as MatchInformationViewModel;

            //Đội nhà
            if (a.Team1.SODOCHIENTHUAT == "4-3-3")
            {
                DoiHinhChienThuatUC433_DOINHA.Visibility = Visibility.Visible;
                DoiHinhChienThuatUC4231_DOINHA.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC442_DOINHA.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC433_DOINHA.DataContext = a.Teamformat1;
                ///Thêm datacontext cho DoiHinhChienThuatUC433
            }
            else if (a.Team1.SODOCHIENTHUAT == "4-4-2")
            {
                DoiHinhChienThuatUC433_DOINHA.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC4231_DOINHA.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC442_DOINHA.Visibility = Visibility.Visible;
                DoiHinhChienThuatUC442_DOINHA.DataContext = a.Teamformat1;
                ///Thêm datacontext cho DoiHinhChienThuatUC442
            }
            else
            {
                DoiHinhChienThuatUC433_DOINHA.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC4231_DOINHA.Visibility = Visibility.Visible;
                DoiHinhChienThuatUC442_DOINHA.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC4231_DOINHA.DataContext = a.Teamformat1;
                ///Thêm datacontext cho DoiHinhChienThuatUC4231
            }

            //Đội khách

            if (a.Team2.SODOCHIENTHUAT == "4-3-3")
            {
                DoiHinhChienThuatUC433_DOINHA.Visibility = Visibility.Visible;
                DoiHinhChienThuatUC4231_DOIKHACH.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC442_DOIKHACH.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC433_DOIKHACH.DataContext = a.Teamformat2;
                ///Thêm datacontext cho DoiHinhChienThuatUC433
            }
            else if (a.Team2.SODOCHIENTHUAT == "4-4-2")
            {
                DoiHinhChienThuatUC433_DOIKHACH.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC4231_DOIKHACH.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC442_DOIKHACH.Visibility = Visibility.Visible;
                DoiHinhChienThuatUC442_DOIKHACH.DataContext = a.Teamformat2;
                ///Thêm datacontext cho DoiHinhChienThuatUC442
            }
            else
            {
                DoiHinhChienThuatUC433_DOIKHACH.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC4231_DOIKHACH.Visibility = Visibility.Visible;
                DoiHinhChienThuatUC442_DOIKHACH.Visibility = Visibility.Collapsed;
                DoiHinhChienThuatUC4231_DOIKHACH.DataContext = a.Teamformat2;
                ///Thêm datacontext cho DoiHinhChienThuatUC4231
            }
        }
    }
}

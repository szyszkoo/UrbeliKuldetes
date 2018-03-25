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

namespace UrbeliKuldetes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow ( )
        {
            InitializeComponent ( );
            this.Title = "Space Mission";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        #region Commands buttons
        private void ScanBtn_Click ( object sender, RoutedEventArgs e )
        {
            ParametersBox.Visibility = Visibility.Visible;
        }

        // TODO : delete this method without errors
        private void MoveTo_Click ( object sender, RoutedEventArgs e )
        {
            
        }
        private void MoveToBtn_Click ( object sender, RoutedEventArgs e )
        {
            ParametersBox.Visibility = Visibility.Visible;
        }

        private void ProduceBtn_Click ( object sender, RoutedEventArgs e )
        {

        }

        private void HarvestBtn_Click ( object sender, RoutedEventArgs e )
        {
            ParametersBox.Visibility = Visibility.Visible;
        }

        private void RepairBtn_Click ( object sender, RoutedEventArgs e )
        {

        }

        private void OrderBtn_Click ( object sender, RoutedEventArgs e )
        {

        }

        #endregion
        #region Parameters for Scan, MoveTo, Harvest
        private void ChaarrBtn_Click ( object sender, RoutedEventArgs e )
        {

        }

        private void EsthBtn_Click ( object sender, RoutedEventArgs e )
        {

        }

        private void ShuttleBtn_Click ( object sender, RoutedEventArgs e )
        {

        }

        private void AsteroidsBtn_Click ( object sender, RoutedEventArgs e )
        {

        }

        private void PoludnicaBtn_Click ( object sender, RoutedEventArgs e )
        {

        }
        #endregion
    }
}

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
using UrbeliKuldetes.Commnication;
using UrbeliKuldetes.CreatingPayload;
using UrbeliKuldetes.Models;

namespace UrbeliKuldetes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO: manage login and token better, somehow
        // and manage the endpoint - a toggle switch ?
        private string endpoint;
        private Commands command;
        private Parameters parameter;
        private Result result;


        public MainWindow ( )
        {
            InitializeComponent ( );
            endpoint = $"https://simulation.future-processing.pl/execute";
            this.Title = "Space Mission";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        #region Commands buttons
        private void ScanBtn_Click ( object sender, RoutedEventArgs e )
        {
            ParametersBox.Visibility = Visibility.Visible;
            command = Commands.Scan;

        }

        // TODO : delete this method without errors
        private void MoveTo_Click ( object sender, RoutedEventArgs e )
        {
            // should be deleted 
        }

        private void MoveToBtn_Click ( object sender, RoutedEventArgs e )
        {
            ParametersBox.Visibility = Visibility.Visible;
            command = Commands.MoveTo;
        }

        private void ProduceBtn_Click ( object sender, RoutedEventArgs e )
        {
            ParametersBoxProduce.Visibility = Visibility.Visible;
            command = Commands.Produce;
        }

        private void HarvestBtn_Click ( object sender, RoutedEventArgs e )
        {
            ParametersBox.Visibility = Visibility.Visible;
            command = Commands.Harvest;
        }

        private void RepairBtn_Click ( object sender, RoutedEventArgs e )
        {
            ParametersBoxRepair.Visibility = Visibility.Visible;
            command = Commands.Repair;
        }

        private void OrderBtn_Click ( object sender, RoutedEventArgs e )
        {
            command = Commands.Order;
        }

        #endregion

        #region Parameters for Scan, MoveTo, Harvest
        private void ChaarrBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Chaarr;
        }

        private void EsthBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Esth;
        }

        private void ShuttleBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Shuttle;
        }

        private void AsteroidsBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Asteroids;
        }

        private void PoludnicaBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Południca;
        }
        #endregion

        #region Parameters for produce
        private void DecoyBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Decoy;
        }

        private void WeaponsBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Weapons;
        }

        private void SuppliesBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Supplies;
        }

        private void ToolsBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Tools;
        }

        private void EnergyBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Energy;
        }

        private void ShuttlewrenchBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Shuttlewrench;
        }
        #endregion

        #region Communication buttons
        private void BackBtn_Click ( object sender, RoutedEventArgs e )
        {
            ParametersBox.Visibility = Visibility.Hidden;
            ParametersBoxProduce.Visibility = Visibility.Hidden;
        }

        private void SendRequestBtn_Click ( object sender, RoutedEventArgs e )
        {
            if(!parameter.Equals("") && !command.Equals(""))
            {
                var execute = new CommandsExcecutor ( );
                result = execute.Execute ( endpoint, command, parameter);
                Turn.Text = result.Turn.ToString();
                Location.Text = result.Location;
                IsItOver.Text = result.IsTerminated.ToString ( );
            }
            else
            {
                MessageBox.Show ( "Choose your command and parameter first" );
            }
        }
        #endregion

        #region Parameters for Repair
        private void CommunicationsBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Communications;
        }

        private void ShuttleRBtn_Click ( object sender, RoutedEventArgs e )
        {
            //should be deleted
        }

        private void PartialShuttleBtn_Click ( object sender, RoutedEventArgs e )
        {
            parameter = Parameters.Partialshuttle;
        }
        #endregion
    }
}

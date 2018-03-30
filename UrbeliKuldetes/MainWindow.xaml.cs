using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using UrbeliKuldetes.Models.ResponseModel;

namespace UrbeliKuldetes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO: manage login and token better, somehow
        // and manage the endpoint - a toggle switch ?
        // TODO: delete login and token out of here, it should be only temporary
        private static string Login = "agata.szysz@gmail.com.google";
        private static string Token = "40FEBC05C9F74D4F53503794F1368B6A";
        private string endpoint;
        private Commands command;
        private Parameters parameter;
        private Result result;
        private Params resultParams = new Params ( );
        private string value = null;


        public MainWindow ( )
        {
            InitializeComponent ( );
            endpoint = $"https://simulation.future-processing.pl/execute";
            this.Title = "Space Mission";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_MouseLeftButtonDown ( object sender, MouseButtonEventArgs e )
        {
            // TODO: naprawić wyswietlanie poludnica energy i poludnica matter , naprawić scores
            CurrentRequest.Text = command.ToString ( ) + "\n" + parameter.ToString ( )+"\t"+value;
            result = DescribeExecutor.Describe ( Login, Token );
            UpdateInfo ( result );
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

        #region Parameters for Produce
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
            SuppliesGrid.Visibility = Visibility.Visible;
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
            ParametersBoxRepair.Visibility = Visibility.Hidden;
            SuppliesSlider.Visibility = Visibility.Hidden;
            this.value = null;
            
        }
        private void RestartBtn_Click ( object sender, RoutedEventArgs e )
        {
            MessageBox.Show ( "Your simulation will be restarted now " );
            var restarter = new CommandsExecutor ( );
            result = restarter.RestartSimulation ( endpoint );
            if ( result != null )
            {
                CleanInfo ( );
                UpdateInfo ( result );
            }
        }

        private void SendRequestBtn_Click ( object sender, RoutedEventArgs e )
        {
                var executor = new CommandsExecutor ( );
                result = executor.Execute ( endpoint, command, parameter, this.value);
                if ( result != null )
                {
                    CleanInfo ( );
                    UpdateInfo ( result );
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

        #region Updating and cleaning info
        private void UpdateInfo(Result result)
        {
            Turn.Text = result.Turn.ToString ( );
            Location.Text = result.Location;
            IsItOver.Text = result.IsTerminated.ToString ( );
            foreach(var evnt in result.LastTurnEvents)
            {
                LastTurnEv.Text = LastTurnEv.Text + evnt +"\n";
            }
            foreach ( var equipment in result.Equipments )
            {
                Equipment.Text = Equipment.Text + equipment + "\n";
            }
            foreach(var log in result.LogBook)
            {
                Logs.Text = Logs.Text + log + "\n";
            }
            ParamsNames.Text = result.Parameters.GetParamsNames ( );
            UpdateParamsValues ( result.Parameters );
            ScoresNames.Text = result.AllScores.GetScoresNames ( );
            UpdateScoresValues ( result.AllScores );
        }
        private void CleanInfo ( )
        {
            LastTurnEv.Text = "";
            Equipment.Text = "";
            Logs.Text = "";
            ParamsValue.Text = "";
            ScoresValues.Text = "";
            Turn.Text = "";
            Location.Text = "";
            IsItOver.Text = "";
        }


        private void UpdateParamsValues(Params receivedParams)
        {
            StringBuilder paramsValues = new StringBuilder ( );

            paramsValues.AppendLine( receivedParams.SavedScience.ToString ( ));
            paramsValues.AppendLine( receivedParams.SavedSurvivors.ToString ( ));
            paramsValues.AppendLine( receivedParams.Knowledge.ToString ( ));
            paramsValues.AppendLine( receivedParams.CrewDeaths.ToString ( ));
            paramsValues.AppendLine( receivedParams.SurvivorDeaths.ToString ( ));
            paramsValues.AppendLine( receivedParams.ChaarrHatred.ToString ( ));
            paramsValues.AppendLine( receivedParams.PoludnicaMatter.ToString ( ));
            paramsValues.AppendLine( receivedParams.PoludnicaEnergy.ToString ( ));
            paramsValues.AppendLine( receivedParams.ExpeditionMatter.ToString ( ));
            paramsValues.AppendLine( receivedParams.ExpeditionEnergy.ToString ( ));


            ParamsValue.Text = paramsValues.ToString();
        }
        private void UpdateScoresValues(Scores receivedScores)
        {
            StringBuilder scoresValues = new StringBuilder ( );

            scoresValues.AppendLine ( receivedScores.SurvivorsScore.ToString ( ) );
            scoresValues.AppendLine ( receivedScores.ScienceScore.ToString ( ) );
            scoresValues.AppendLine ( receivedScores.CrewMalus.ToString ( ) );
            scoresValues.AppendLine ( receivedScores.KnowledgeScore.ToString ( ) );
            scoresValues.AppendLine ( receivedScores.EventScore.ToString ( ) );
            scoresValues.AppendLine ( receivedScores.TotalScore.ToString ( ) );


            ScoresValues.Text = scoresValues.ToString ( );
        }
        private void SuppliesSlider_ValueChanged ( object sender, RoutedPropertyChangedEventArgs<double> e )
        {
            SuppliesValue.Text = SuppliesSlider.Value.ToString();
            this.value = SuppliesSlider.Value.ToString ( );
        }
        #endregion
    }
}

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
        private static string Login;
        private static string Token;
        private static string SimulationOrChaarr;
        private Commands command;
        private Parameters parameter;
        private Result result;
        private Params resultParams = new Params ( );
        private Scores resultScores = new Scores ( );
        private string value = null;


        public MainWindow ( string _login, string _token, string _simulationOrChaarr)
        {
            InitializeComponent ( );
            Login = _login;
            Token = _token;
            SimulationOrChaarr = _simulationOrChaarr;
            this.Title = "Space Mission";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }
        private void Window_MouseLeftButtonDown ( object sender, MouseButtonEventArgs e )
        {
            CurrentRequest.Text = command.ToString ( ) + "\n" + parameter.ToString ( )+"\n"+value;
            result = DescribeExecutor.Describe ( Login, Token, SimulationOrChaarr);
            UpdateInfo ( result );
        }
        #region Commands buttons
        private void ScanBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetVisibility ( ParametersBox, Visibility.Visible );
            SetCommand ( Commands.Scan );
        }

        // TODO : delete this method without errors
        private void MoveTo_Click ( object sender, RoutedEventArgs e )
        {
            // should be deleted 
        }

        private void MoveToBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetVisibility ( ParametersBox, Visibility.Visible );
            SetCommand ( Commands.MoveTo );
        }

        private void ProduceBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetVisibility ( ParametersBoxProduce, Visibility.Visible );
            SetCommand ( Commands.Produce );
        }

        private void HarvestBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetVisibility ( ParametersBox, Visibility.Visible );
            SetCommand ( Commands.Harvest );
        }

        private void RepairBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetVisibility ( ParametersBoxRepair , Visibility.Visible );
            SetCommand ( Commands.Repair );
        }

        private void OrderBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetCommand ( Commands.Order );
            SetVisibility ( ParametersBoxOrder, Visibility.Visible );
        }

        #endregion

        #region Parameters for Scan, MoveTo, Harvest
        private void ChaarrBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Chaarr );
        }

        private void EsthBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Esth );
        }

        private void ShuttleBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Shuttle );
        }

        private void AsteroidsBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Asteroids );
        }

        private void PoludnicaBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Południca );
        }
        #endregion

        #region Parameters for Produce
        private void DecoyBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Decoy );
        }

        private void WeaponsBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Weapons );
        }

        private void SuppliesBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Supplies );
            SetVisibility ( SuppliesGrid, Visibility.Visible );
        }

        private void ToolsBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Tools );
        }

        private void EnergyBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Energy );
        }

        private void ShuttlewrenchBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Shuttlewrench );
        }
        #endregion

        #region Parameters for Repair
        private void CommunicationsBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Communications );
        }

        private void ShuttleRBtn_Click ( object sender, RoutedEventArgs e )
        {
            //should be deleted
        }

        private void PartialShuttleBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Partialshuttle );
        }
        #endregion

        #region Communication 
        private void BackBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetVisibility ( ParametersBox, Visibility.Hidden );
            SetVisibility ( ParametersBoxProduce, Visibility.Hidden );
            SetVisibility ( ParametersBoxRepair, Visibility.Hidden );
            SetVisibility ( ParametersBoxOrder, Visibility.Hidden );
            SetVisibility ( ValuesBoxOrder, Visibility.Hidden );
            SetVisibility ( SuppliesGrid, Visibility.Hidden );

            //SuppliesSlider.Visibility = Visibility.Hidden;
            this.value = null;
            
        }
        private void RestartBtn_Click ( object sender, RoutedEventArgs e )
        {
            MessageBox.Show ( "Your simulation will be restarted now " );
            var restarter = new CommandsExecutor (Login, Token, SimulationOrChaarr );
            result = restarter.RestartSimulation ( );
            if ( result != null )
            {
                UpdateInfo ( result );
            }
        }

        private void SendRequestBtn_Click ( object sender, RoutedEventArgs e )
        {
                var executor = new CommandsExecutor ( Login, Token, SimulationOrChaarr );
                result = executor.Execute ( command, parameter, this.value);
                if ( result != null )
                {
                    UpdateInfo ( result );
                }
       
        }

        #endregion

        #region Updating and cleaning info
        private void UpdateInfo(Result result)
        {
            CleanInfo ( );
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
                Logs.Text = Logs.Text + log + "\n\n";
            }
            ParamsNames.Text = result.Parameters.GetParamsNames ( );
            UpdateParamsValues ( result.Parameters );
            ScoresNames.Text = result.Scores.GetScoresNames ( );
            UpdateScoresValues ( result.Scores );
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
            //"0.##" -> displays a number without decimal places
            paramsValues.AppendLine( receivedParams.SavedScience.ToString ( "0.##" ) );
            paramsValues.AppendLine( receivedParams.SavedSurvivors.ToString ( "0.##" ) );
            paramsValues.AppendLine( receivedParams.Knowledge.ToString ( "0.##" ) );
            paramsValues.AppendLine( receivedParams.CrewDeaths.ToString ( "0.##" ) );
            paramsValues.AppendLine( receivedParams.SurvivorDeaths.ToString ( "0.##" ) );
            paramsValues.AppendLine( receivedParams.ChaarrHatred.ToString ( "0.##" ) );
            paramsValues.AppendLine( receivedParams.PoludnicaMatter.ToString ( "0.##" ) );
            paramsValues.AppendLine( receivedParams.PoludnicaEnergy.ToString ( "0.##" ) );
            paramsValues.AppendLine( receivedParams.ExpeditionMatter.ToString ( "0.##" ) );
            paramsValues.AppendLine( receivedParams.ExpeditionEnergy.ToString ( "0.##" ) );


            ParamsValue.Text = paramsValues.ToString();
        }
        private void UpdateScoresValues(Scores receivedScores)
        {
            StringBuilder scoresValues = new StringBuilder ( );
            //"0.##" -> displays a number without decimal places
            scoresValues.AppendLine ( receivedScores.SurvivorsScore.ToString ( "0.##" ) );
            scoresValues.AppendLine ( receivedScores.ScienceScore.ToString ( "0.##" ) );
            scoresValues.AppendLine ( receivedScores.CrewMalus.ToString ( "0.##" ) );
            scoresValues.AppendLine ( receivedScores.KnowledgeScore.ToString ( "0.##" ) );
            scoresValues.AppendLine ( receivedScores.EventScore.ToString ( "0.##" ) );
            scoresValues.AppendLine ( receivedScores.TotalScore.ToString ( "0.##" ) );


            ScoresValues.Text = scoresValues.ToString ( );
        }
        private void SuppliesSlider_ValueChanged ( object sender, RoutedPropertyChangedEventArgs<double> e )
        {
            SuppliesValue.Text = SuppliesSlider.Value.ToString();
            this.value = SuppliesSlider.Value.ToString ( );
        }
        private void SetParameter(Parameters paramForRequest)
        {
            parameter = paramForRequest;
        }
        private void SetCommand(Commands commandForRequest)
        {
            command = commandForRequest;
        }
        private void SetVisibility(Grid gridName, Visibility visibilityMode)
        {
            gridName.Visibility = visibilityMode;
        }
        private void SetValueForOrderCommand(Parameters valueForOrderCommand)
        {
            this.value = valueForOrderCommand.ToString ( );
        }
        #endregion
        #region Parameters for Order
        private void HelpBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Help );
            SetVisibility ( ParametersBoxOrder, Visibility.Hidden );
            SetVisibility ( ValuesBoxOrder, Visibility.Visible );
        }

        private void FinalWarBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.FinalWar );
            SetVisibility ( ParametersBoxOrder, Visibility.Hidden );
            SetVisibility ( ValuesBoxOrder, Visibility.Visible );
        }

        private void EvacScience_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.EvacScience );
            SetVisibility ( ParametersBoxOrder, Visibility.Hidden );
            SetVisibility ( ValuesBoxOrder, Visibility.Visible );
        }

        private void EvacSurvivors_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.EvacSurvivors );
            SetVisibility ( ParametersBoxOrder, Visibility.Hidden );
            SetVisibility ( ValuesBoxOrder, Visibility.Visible );
        }

        private void Retreat_Click ( object sender, RoutedEventArgs e )
        {
            SetParameter ( Parameters.Retreat );
            SetVisibility ( ParametersBoxOrder, Visibility.Hidden );
            SetVisibility ( ValuesBoxOrder, Visibility.Visible );
        }
        #endregion
        #region Values for Order
        private void VChaarrBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetValueForOrderCommand ( Parameters.Chaarr );
        }

        private void VEsthBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetValueForOrderCommand ( Parameters.Esth );
        }

        private void VShuttleBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetValueForOrderCommand ( Parameters.Shuttle );
        }

        private void VAsteroidsBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetValueForOrderCommand ( Parameters.Asteroids );
        }

        private void VPoludnicaBtn_Click ( object sender, RoutedEventArgs e )
        {
            SetValueForOrderCommand ( Parameters.Południca );
        }
        #endregion
    }
}

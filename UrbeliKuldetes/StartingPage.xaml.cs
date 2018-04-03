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

namespace UrbeliKuldetes
{
    /// <summary>
    /// Interaction logic for StartingPage.xaml
    /// </summary>
    public partial class StartingPage : Window
    {
        public string login="";
        public string token="";
        public string simulationOrChaarr="";
        public StartingPage()
        {
            InitializeComponent();
            this.Title = "Space Mission";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void SimulationBtn_Click ( object sender, RoutedEventArgs e )
        {
            simulationOrChaarr = "simulation";
        }

        private void ChaarrBtn_Click ( object sender, RoutedEventArgs e )
        {
            simulationOrChaarr = "chaarr";
        }

        private void SubmitBtn_Click ( object sender, RoutedEventArgs e )
        {
            MainWindow mainWindow = new MainWindow(login, token, simulationOrChaarr);
            mainWindow.Show ( );
            this.Close ( );
        }

        private void LoginTextBox_TextChanged ( object sender, TextChangedEventArgs e )
        {
            login = LoginTextBox.Text;
        }

        private void TokenTextBox_TextChanged ( object sender, TextChangedEventArgs e )
        {
            token = TokenTextBox.Text;
        }
    }
}

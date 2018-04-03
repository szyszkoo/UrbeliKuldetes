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
using UrbeliKuldetes.Commnication;

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
            MyLoginAndToken loginAndTokenClass = new MyLoginAndToken ( );
            LoginTextBox.Text = loginAndTokenClass.getLogin ( );
            TokenTextBox.Text = loginAndTokenClass.getToken ( );
        }

        private void SimulationBtn_Click ( object sender, RoutedEventArgs e )
        {
            simulationOrChaarr = "simulation";
            ShowSubmitBtnIfLoginAndTokenNotEmpty ( );
        }

        private void ChaarrBtn_Click ( object sender, RoutedEventArgs e )
        {
            simulationOrChaarr = "chaarr";
            ShowSubmitBtnIfLoginAndTokenNotEmpty ( );
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
        private void ShowSubmitBtnIfLoginAndTokenNotEmpty()
        {
            if ( login != "" && token != "" )
            {
                WarningLbl.Visibility = Visibility.Hidden;
                SubmitBtn.Visibility = Visibility.Visible;
            }
            else
            {
                SubmitBtn.Visibility = Visibility.Hidden;
                WarningLbl.Visibility = Visibility.Visible;
            }
        }
    }
}

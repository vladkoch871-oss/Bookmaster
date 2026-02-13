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

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginMi_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog()==true)
            {
                LibraryMi.Visibility = Visibility.Visible;
                LoginMi.Visibility = Visibility.Collapsed;
                LogoutMi.Visibility = Visibility.Visible;
            }
        }

        private void ReportsMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CirculationMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManageCustomersMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseMi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BrowseCatalogMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogoutMi_Click(object sender, RoutedEventArgs e)
        {
            LibraryMi.Visibility = Visibility.Collapsed;
            LoginMi.Visibility = Visibility.Visible;
            LogoutMi.Visibility = Visibility.Collapsed;
        }
    }
}

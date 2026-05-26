using Bookmaster.AppData;
using Bookmaster.Models;
using Bookmaster.View.Windows;
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

namespace Bookmaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        //Определяем
        private readonly Bookmaster36Context _context;
        //Инициализация
        private List<Customer> _customers = new List<Customer>();
        public ManageCustomersPage()
        {
            InitializeComponent();
            //Инициализируем
            _context = new Bookmaster36Context();
            // В список присваиваем записи из таблицы
            _customers = _context.Customers.ToList();

            CustomersLV.ItemsSource = _customers;
        }

        private void CustomersLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EditCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersLV.SelectedItem is Customer selectedCustomer)
            {
                AddCustomerWindow editCustomerWindow = new AddCustomerWindow(selectedCustomer);
                editCustomerWindow.ShowDialog();
                if (editCustomerWindow.ShowDialog() == true)
                {
                    CustomersLV.ItemsSource = _customers = App.GetContext().Customers.ToList();
                }
            }
            else 
            {
                FeedbackService.Error("Вы не выбрали читателя!"); 
            }
            
        }

        private void AddCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            if (addCustomerWindow.ShowDialog()==true)
            {
                CustomersLV.ItemsSource= _customers =App.GetContext().Customers.ToList();
            }
        }

        private void SearchCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            string customerId = CustomerIdTb.Text;
            string customerName = NameTb.Text;

            if (string.IsNullOrWhiteSpace(customerId) && string.IsNullOrWhiteSpace(customerName))
            {

                CustomersLV.ItemsSource = _customers;
                return;
            }
            var filteredCustomers = _customers.Where(customer => customer.Id.ToLower().Contains(customerId) && customer.Name.ToLower().Contains(customerName));

            CustomersLV.ItemsSource = filteredCustomers;
        }
    }
}

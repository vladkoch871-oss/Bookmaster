using Bookmaster.AppData;
using Bookmaster.Models;
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
    /// Логика взаимодействия для AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        List<City> _cities = App.GetContext().Cities.ToList();

        public AddCustomerWindow(Customer selectedCustomer)
        {
            InitializeComponent();
            Title = "Редактирование читателя";
            AddBtn.Visibility = Visibility.Collapsed;
            SaveBtn.Visibility = Visibility.Visible;

            AddressCmb.ItemsSource = _cities;
            DataContext = selectedCustomer;

            IDTb.Text = selectedCustomer.Id;
            AddressCmb.SelectedItem=selectedCustomer.City;
        }
        public AddCustomerWindow()
        {
            InitializeComponent();
            Title = "Добавление читателя";
            AddBtn.Visibility = Visibility.Visible;
            SaveBtn.Visibility = Visibility.Collapsed;

            AddressCmb.ItemsSource = _cities;

            IDTb.Text=GenerateId();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.GetContext().SaveChanges();
                FeedbackService.Information("Данные читателя успешно отредактированы!");
                DialogResult = true;
            }
            catch (Exception ex) 
            {
                FeedbackService.Error(ex);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult=false;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameCustomerTb.Text)|| string.IsNullOrWhiteSpace(AddressTb.Text) || string.IsNullOrWhiteSpace(MailTb.Text) || string.IsNullOrWhiteSpace(PhoneTb.Text) || string.IsNullOrWhiteSpace(ZipTb.Text))
            {
                FeedbackService.Error("Заполните все поля!");
            }
            else
            {
                try
                {
                    Customer newCustomer = new Customer()
                    {
                        Id = IDTb.Text,
                        Name = NameCustomerTb.Text,
                        Address = AddressTb.Text,
                        CityId = (int)AddressCmb.SelectedValue,
                        Phone = PhoneTb.Text,
                        Email = MailTb.Text,
                        Zip = ZipTb.Text,
                    }
                    ;
                    App.GetContext().Customers.Add(newCustomer);
                    App.GetContext().SaveChanges();
                    FeedbackService.Information("Читатель успешно добавлен!");
                    DialogResult = true;
                }
                catch (Exception exception)
                {
                    FeedbackService.Error(exception);
                }
            }
        }
        private string GenerateId()
        {
            int lastId = Convert.ToInt32(App.GetContext().Customers.Max(c => c.Id).Substring(1));
            ++lastId;
            return $"C{lastId}";
        }
    }
}

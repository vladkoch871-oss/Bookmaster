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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            CredentialsService.Load(LoginTb, PasswordPPb, RememberDataCb);
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            CredentialsService.Administrator = App.GetContext().Administrators.FirstOrDefault(a => a.Username == LoginTb.Text && a.Password == PasswordPPb.Password);

            if (CredentialsService.HasAdministrator)
            {
                if (RememberDataCb.IsChecked==true)
                {
                    CredentialsService.Save(LoginTb.Text, PasswordPPb.Password);
                }
                else
                {
                    CredentialsService.Clear();
                }

                FeedbackService.Information("Пользователь успешно авторизовался.");
                  DialogResult = true;
            }
            else
            {
                FeedbackService.Error("Пользователь не найден. Проверьте учётные данные.");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

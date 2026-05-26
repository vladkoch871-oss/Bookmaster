using Bookmaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bookmaster.AppData
{
    public static class CredentialsService
    {
        #region Хранение текущего пользователя (в оперативной памяти)
        public static Administrator? Administrator { get; set; }

        public static bool HasAdministrator
        {
            get
            {
                return Administrator != null;
            }
        }
        public static void ClearData()
        {
            Administrator = null;
        }
        
        #endregion

        #region Хранение данных для автозаполнения (в параметрах пректа)
        public static string? SavedLogin
        {
            get => Properties.Settings.Default.SavedLogin;
            set => Properties.Settings.Default.SavedLogin = value;
            
        }
        public static string? SavedPassword
        {
            get => Properties.Settings.Default.SavedPassword;
            set => Properties.Settings.Default.SavedPassword = value;
        }
        public static bool IsRemember
        {
            get => Properties.Settings.Default.IsRemember;
            set => Properties.Settings.Default.IsRemember = value;
        }

        public static void Save(string login, string password)
        {
            SavedLogin = login;
            SavedPassword = password;
            IsRemember = true;

            Properties.Settings.Default.Save();
        }

        public static void Clear()
        {
            SavedLogin = string.Empty;
            SavedPassword = string.Empty;
            IsRemember = false;

            Properties.Settings.Default.Save();
        }
        public static void Load(TextBox login, PasswordBox password, CheckBox checkBox)
        {
            login.Text = SavedLogin;
            password.Password = SavedPassword;
            checkBox.IsChecked = IsRemember;
        }
        #endregion
    }
}

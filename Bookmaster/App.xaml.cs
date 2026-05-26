using Bookmaster.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Bookmaster
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Bookmaster36Context _context;

        public static Bookmaster36Context GetContext()
        {
            if (_context == null)
            {
                _context = new Bookmaster36Context();
            }
            return _context;
        }
    }

}

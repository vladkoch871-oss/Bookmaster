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
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {
        //Определяем
        private readonly Bookmaster36Context _context;
        //Инициализация
        private List<Book> _books = new List<Book>();
        public BrowseCatalogPage()
        {
            InitializeComponent();

            //Инициализируем
            _context = new Bookmaster36Context();
            // В список присваиваем записи из таблицы
            _books = _context.Books.ToList();

            BookAuthorsLV.ItemsSource = _books;
        }

        private void SearchBookBtn_Click(object sender, RoutedEventArgs e)
        {
            string bookTitle = BookTitleTb.Text;
            string authorName = AuthorNameTb.Text;
            string bookGenre = BookGenreTb.Text;

            if (string.IsNullOrWhiteSpace(bookTitle) && string.IsNullOrWhiteSpace(authorName) && string.IsNullOrWhiteSpace(bookGenre))
            {
                
                BookAuthorsLV.ItemsSource = _books;
                return;
            }
            var filteredBooks = _books.Where(book => book.Title.ToLower().Contains(bookTitle) && book.Authors.ToLower().Contains(authorName) && book.Subjects.ToLower().Contains(bookGenre));

            BookAuthorsLV.ItemsSource = filteredBooks;
        }

        private void PreviousPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BookAuthorsDetailsHl_Click(object sender, RoutedEventArgs e)
        {
            if (BookAuthorsLV.SelectedItem is Book selectedBook)
            {
                BookAuthorsDetailsWindow bookAuthorsDetailWindow = new BookAuthorsDetailsWindow (selectedBook.BookAuthors);
                bookAuthorsDetailWindow.ShowDialog();
            }
        }

        private void BookAuthorsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookAuthorsLV.SelectedItem is Book selectedBook)
            {
                DataContext = selectedBook;
            }
        }
    }
}

using Bookmaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmaster.AppData
{
    public class PaginationController
    {
        private List<Book> _books; //Список книг
        private const int PAGE_SIZE = 50; //кол-во книг на одной странице
        
        public int CurrentPage { get; set; } // номер текущей страницы
        public int TotalPages { get; set; } // общее кол-во страниц
        public int BooksCount => _books.Count; // общее кол-во книг
        public bool CanGoNext => CurrentPage < TotalPages;
        public bool CanGoPrevious => CurrentPage > 1;
    }
}

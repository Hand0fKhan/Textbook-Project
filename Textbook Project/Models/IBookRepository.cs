using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Textbook_Project.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> BookLibrary { get; }

        public void SaveBook(Book b);
        public void CreateBook(Book b);
        public void DeleteBook(Book b);
    }
}

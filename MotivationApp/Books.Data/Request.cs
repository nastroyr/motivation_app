using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    class Request
    {
        Context context = new Context();

        public List<BookViewModel> ShowAll()
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from b in context.Books
                              .Include(st => st.Subject)
                              .Include(g => g.Genre)
                              .OrderBy(b => b.Genre.GenreName)                              
                          select new BookViewModel { NameOfBook = b.NameOfBook, AuthorName = b.AuthorName, AboutAuthor = b.AboutAuthor, AboutBook = b.AboutBook, GenreName = b.Genre.GenreName, SubjectName = b.Subject.SubjectName, WhereToBuy = b.WhereToBuy, WhereToDownloadFree = b.WhereToDownloadFree }).ToList();
            foreach (var book in result)
            {
                books.Add(r);
            }

        }
        public List<BookViewModel> SortByGenre()
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from b in context.Books
                              .Include(st => st.Subject)
                              .Include(g => g.Genre)
                              .Where(b => b.Genre.GenreID == 1)
                          select new BookViewModel { NameOfBook = b.NameOfBook, AuthorName = b.AuthorName, AboutAuthor = b.AboutAuthor, AboutBook = b.AboutBook, GenreName = b.Genre.GenreName, SubjectName = b.Subject.SubjectName, WhereToBuy = b.WhereToBuy, WhereToDownloadFree = b.WhereToDownloadFree }).ToList();
            foreach (var r in result)
            {
                books.Add(r);
            }
            return books;
        }
    }
}

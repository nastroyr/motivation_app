using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public class Request
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
                books.Add(book);
            }
            return books;
        }

        public List<BookViewModel> SortByGenre(int id)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from b in context.Books
                              .Include(st => st.Subject)
                              .Include(g => g.Genre)
                              .Where(b => b.Genre.GenreID == id)
                          select new BookViewModel { NameOfBook = b.NameOfBook, AuthorName = b.AuthorName, AboutAuthor = b.AboutAuthor, AboutBook = b.AboutBook, GenreName = b.Genre.GenreName, SubjectName = b.Subject.SubjectName, WhereToBuy = b.WhereToBuy, WhereToDownloadFree = b.WhereToDownloadFree }).ToList();
            foreach (var r in result)
            {
                books.Add(r);
            }
            return books;
        }

        public List<BookViewModel> SortByGenre(int id1, int id2)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from b in context.Books
                              .Include(st => st.Subject)
                              .Include(g => g.Genre)
                              .Where(b => b.Genre.GenreID == id1 || b.Genre.GenreID == id2)
                          select new BookViewModel { NameOfBook = b.NameOfBook, AuthorName = b.AuthorName, AboutAuthor = b.AboutAuthor, AboutBook = b.AboutBook, GenreName = b.Genre.GenreName, SubjectName = b.Subject.SubjectName, WhereToBuy = b.WhereToBuy, WhereToDownloadFree = b.WhereToDownloadFree }).ToList();
            foreach (var r in result)
            {
                books.Add(r);
            }
            return books;
        }

        public List<BookViewModel> SortByGenre(int id1, int id2, int id3)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from b in context.Books
                              .Include(st => st.Subject)
                              .Include(g => g.Genre)
                              .Where(b => b.Genre.GenreID == id1 || b.Genre.GenreID == id2 || b.Genre.GenreID == id3)
                          select new BookViewModel { NameOfBook = b.NameOfBook, AuthorName = b.AuthorName, AboutAuthor = b.AboutAuthor, AboutBook = b.AboutBook, GenreName = b.Genre.GenreName, SubjectName = b.Subject.SubjectName, WhereToBuy = b.WhereToBuy, WhereToDownloadFree = b.WhereToDownloadFree }).ToList();
            foreach (var r in result)
            {
                books.Add(r);
            }
            return books;
        }

        public List<BookViewModel> SortByGenre(int id1, int id2, int id3, int id4)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from b in context.Books
                              .Include(st => st.Subject)
                              .Include(g => g.Genre)
                              .Where(b => b.Genre.GenreID == id1 || b.Genre.GenreID == id2 || b.Genre.GenreID == id3 || b.Genre.GenreID == id4)
                          select new BookViewModel { NameOfBook = b.NameOfBook, AuthorName = b.AuthorName, AboutAuthor = b.AboutAuthor, AboutBook = b.AboutBook, GenreName = b.Genre.GenreName, SubjectName = b.Subject.SubjectName, WhereToBuy = b.WhereToBuy, WhereToDownloadFree = b.WhereToDownloadFree }).ToList();
            foreach (var r in result)
            {
                books.Add(r);
            }
            return books;
        }
        public List<BookViewModel> SortBySubject(List<BookViewModel> model, string subject)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from m in model
                              .Where(m => m.SubjectName == subject)
                          select m).ToList();
            foreach (var r in result)
            {
                books.Add(r);
            }
            return books;
        }
        public List<BookViewModel> SortBySubject(List<BookViewModel> model, string subject, string subject2)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from m in model
                              .Where(m => m.SubjectName == subject || m.SubjectName == subject2)
                          select m).ToList();
            foreach (var r in result)
            {
                books.Add(r);
            }
            return books;
        }
        public List<BookViewModel> SortBySubject(List<BookViewModel> model, string subject, string subject2, string subject3)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from m in model
                              .Where(m => m.SubjectName == subject || m.SubjectName == subject2 || m.SubjectName == subject3)
                          select m).ToList();
            foreach (var r in result)
            {
                books.Add(r);
            }
            return books;
        }
        public List<BookViewModel> SortBySubject(string subject)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from b in context.Books
                              .Include(st => st.Subject)
                              .Include(g => g.Genre)
                              .Where(b => b.Subject.SubjectName == subject)
                          select new BookViewModel { NameOfBook = b.NameOfBook, AuthorName = b.AuthorName, AboutAuthor = b.AboutAuthor, AboutBook = b.AboutBook, GenreName = b.Genre.GenreName, SubjectName = b.Subject.SubjectName, WhereToBuy = b.WhereToBuy, WhereToDownloadFree = b.WhereToDownloadFree }).ToList();
            foreach (var r in result)
            {
                books.Add(r);
            }
            return books;
        }

        public List<BookViewModel> SortBySubject(string subject, string subject2)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from b in context.Books
                              .Include(st => st.Subject)
                              .Include(g => g.Genre)
                              .Where(b => b.Subject.SubjectName == subject || b.Subject.SubjectName == subject2)
                          select new BookViewModel { NameOfBook = b.NameOfBook, AuthorName = b.AuthorName, AboutAuthor = b.AboutAuthor, AboutBook = b.AboutBook, GenreName = b.Genre.GenreName, SubjectName = b.Subject.SubjectName, WhereToBuy = b.WhereToBuy, WhereToDownloadFree = b.WhereToDownloadFree }).ToList();
            foreach (var r in result)
            {
                books.Add(r);
            }
            return books;
        }

        public List<BookViewModel> SortBySubject(string subject, string subject2, string subject3)
        {
            List<BookViewModel> books = new List<BookViewModel>();
            var result = (from b in context.Books
                              .Include(st => st.Subject)
                              .Include(g => g.Genre)
                              .Where(b => b.Subject.SubjectName == subject || b.Subject.SubjectName == subject2 || b.Subject.SubjectName == subject3)
                          select new BookViewModel { NameOfBook = b.NameOfBook, AuthorName = b.AuthorName, AboutAuthor = b.AboutAuthor, AboutBook = b.AboutBook, GenreName = b.Genre.GenreName, SubjectName = b.Subject.SubjectName, WhereToBuy = b.WhereToBuy, WhereToDownloadFree = b.WhereToDownloadFree }).ToList();
            foreach (var r in result)
            {
                books.Add(r);
            }
            return books;
        }

    }
}

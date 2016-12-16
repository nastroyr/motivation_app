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
            return (from b in context.Books
                               .Include(st => st.Subject)
                               .Include(g => g.Genre)
                               .OrderBy(b => b.Genre.GenreName)
                    select new BookViewModel
                    {
                        NameOfBook = b.NameOfBook,
                        AuthorName = b.AuthorName,
                        AboutAuthor = b.AboutAuthor,
                        AboutBook = b.AboutBook,
                        GenreName = b.Genre.GenreName,
                        SubjectName = b.Subject.SubjectName,
                        WhereToBuy = b.WhereToBuy,
                        WhereToDownloadFree = b.WhereToDownloadFree
                    }).ToList();
        }

        public List<BookViewModel> SortByGenre(List<int> ids)
        {
            return (from b in context.Books
                              .Include(st => st.Subject)
                              .Include(g => g.Genre)
                              .Where(b => ids.Contains(b.GenreID))
                    select new BookViewModel
                    {
                        NameOfBook = b.NameOfBook,
                        AuthorName = b.AuthorName,
                        AboutAuthor = b.AboutAuthor,
                        AboutBook = b.AboutBook,
                        GenreName = b.Genre.GenreName,
                        SubjectName = b.Subject.SubjectName,
                        WhereToBuy = b.WhereToBuy,
                        WhereToDownloadFree = b.WhereToDownloadFree
                    }).ToList();
        }
        
        public List<BookViewModel> SortBySubject(List<BookViewModel> model, List<string> subjects)
        {
            if (model == null)
            {
                model = this.ShowAll();
            }
            return (from m in model
                              .Where(m => subjects.Contains(m.SubjectName))
                    select m).ToList();
        }

        public IEnumerable<MotivationQuote> GetAllQuotes()
        {
            throw new NotImplementedException();
        }
    }
}

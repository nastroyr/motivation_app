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

        public MotivationQuote RandomQuote()
        {
            MotivationQuote quote = null;
            int qCount = context.MotivationQuotes.Count(q => true);
            if (qCount > 0)
            {
                Random rand = new Random();
                int skip = rand.Next(qCount);
                quote = context.MotivationQuotes.OrderBy(q => q.MotivationQuoteID).Skip(skip).Take(1).First();
            }
            return quote;
        }

        public Book RandomBook()
        {
            Book book = null;
            int bCount = context.Books.Count(b => true);
            if (bCount > 0)
            {
                Random rand = new Random();
                int skip = rand.Next(bCount);
                book = context.Books.OrderBy(b => b.BookID).Skip(skip).Take(1).Include(b => b.Genre).Include(b => b.Subject).First();
            }
            return book;
        }

        public MotivationImage RandomMotivationImage()
        {
            MotivationImage img = null;
            int iCount = context.MotivationImages.Count(i => true);
            if (iCount > 0)
            {
                Random rand = new Random();
                int skip = rand.Next(iCount);
                img = context.MotivationImages.OrderBy(i => i.MotivationImageID).Skip(skip).Take(1).First();
            }
            return img;
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
            return context.MotivationQuotes;
        }

        public void AddQuote(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                context.MotivationQuotes.Add(new MotivationQuote(text));
            }
            context.SaveChanges();
        }

        public void RemoveQuote(MotivationQuote quote)
        {
            if (quote != null && context.MotivationQuotes.Any(q => q.MotivationQuoteID == quote.MotivationQuoteID))
            {
                context.MotivationQuotes.Remove(quote);
            }
            context.SaveChanges();
        }
    }
}

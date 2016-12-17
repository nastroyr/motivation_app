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

        public List<Genre> getAllGenres()
        {
            return (from g in context.Genres
                    select g).ToList();
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

        public List<MotivationEvent> GetAllEvents()
        {
            return (from e in context.MotivationEvents
                    orderby e.DateDue ascending
                    select e).ToList();
        }

        public List<MotivationEvent> GetEventsToShow()
        {
            return context.MotivationEvents
                .Where(
                    e => e.RepeatSeconds != 0 &&
                    DbFunctions.DiffSeconds(e.LastRemind, DateTime.Now) >= e.RepeatSeconds)
                .OrderBy(e => e.DateDue)
                .ToList();
            
        }

        public void ClearOldEvents()
        {
            List<MotivationEvent> eventsToDelete = (from e in context.MotivationEvents
                                                    where e.DateDue <= DateTime.Now
                                                    select e).ToList();
            context.MotivationEvents.RemoveRange(eventsToDelete);
            context.SaveChanges();
        }

        public void AddEvent(MotivationEvent e)
        {
            if (e != null)
            {
                context.MotivationEvents.Add(e);
            }
            context.SaveChanges();
        }

        public void RemoveEvent(MotivationEvent ev)
        {
            if (ev != null && context.MotivationEvents.Any(e => e.MotivationEventID == ev.MotivationEventID))
            {
                context.MotivationEvents.Remove(ev);
                context.SaveChanges();
            }
        }
    }
}

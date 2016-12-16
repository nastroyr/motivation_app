using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<MotivationQuote> MotivationQuotes { get; set; }

        public DbSet<MotivationImage> MotivationImages { get; set; }

        public Context() : base("localsql")
        {

        }
    }
}

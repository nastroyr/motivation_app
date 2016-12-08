using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public class Book
    {
        public int BookID { get; set; }
        public string NameOfBook { get; set; }
        public string AuthorName { get; set; }
        public string AboutAuthor { get; set; }
        public string AboutBook { get; set; }
        public string WhereToBuy { get; set; }
        public string WhereToDownloadFree { get; set; }
        public Genre Genre { get; set; }
        public Subject Subject { get; set; }
    }
}

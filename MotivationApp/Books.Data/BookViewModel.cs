using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    class BookViewModel
    {
        public string NameOfBook { get; set; }
        public string AuthorName { get; set; }
        public string AboutAuthor { get; set; }
        public string AboutBook { get; set; }
        public string WhereToBuy { get; set; }
        public string WhereToDownloadFree { get; set; }
        public string GenreName { get; set; }
        public string SubjectName { get; set; }
    }
}

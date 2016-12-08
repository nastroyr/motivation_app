using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public List<Book> Book { get; set; }
    }
}

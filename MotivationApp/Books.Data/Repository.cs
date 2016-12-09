using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public class Repository
    {
        private class DataSet
        {
            public List<Genre> Genres { get; set; }
            public List<Subject> Subjects { get; set; }
            public List<Book> Books { get; set; }
        }

        DataSet _dataset;

        public IEnumerable<Genre> GenresRep
        {
            get
            {
                return _dataset.Genres;
            }
        }

        public IEnumerable<Subject> SubjectsRep
        {
            get
            {
                return _dataset.Subjects;
            }
        }

        public IEnumerable<Book> Books
        {
            get
            {
                return _dataset.Books;
            }
        }
        public Repository()
        {
            _dataset = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText("Books.json"));
        }
    }
}

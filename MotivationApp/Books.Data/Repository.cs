using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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
        IEnumerable<MotivationQuote> _quotes;
        IEnumerable<MotivationImage> _images;

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

        public IEnumerable<MotivationQuote> Quotes
        {
            get
            {
                return _quotes;
            }
        }

        public IEnumerable<MotivationImage> Images
        {
            get
            {
                return _images;
            }
        }

        public string LastPath {get ;set;}

        public Repository()
        {
            string pathBase = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "../../../");
            _dataset = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText(pathBase + "Books.json"));

            _quotes = new List<MotivationQuote>();
            string[] allQuotes = File.ReadAllLines(pathBase + "quotes.txt");
            foreach(string q in allQuotes)
            {
                ((List<MotivationQuote>)_quotes).Add(new MotivationQuote(q));
            }

            _images = new List<MotivationImage>();
            int i = 1;
            while(true)
            {
                string url = pathBase + "img\\img (" + i.ToString() + ").jpg";
                LastPath = url;
                if (File.Exists(url))
                    ((List<MotivationImage>)_images).Add(new MotivationImage(url));
                else
                    break;
                i++;
            }
        }
    }
}

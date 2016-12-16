using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public class MotivationQuote
    {
        public int MotivationQuoteID { get; set; }
        public string QuoteText { get; set; }

        public MotivationQuote(string q)
        {
            QuoteText = q;
        }

        public MotivationQuote()
        {
            
        }
    }
}

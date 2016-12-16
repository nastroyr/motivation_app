using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data
{
    public class MotivationImage
    {

        public int MotivationImageID { get; set; }
        public string ImgURL { get; set; }

        public MotivationImage(string url)
        {
            ImgURL = url;
        }

        public MotivationImage()
        {
            
        }
    }
}

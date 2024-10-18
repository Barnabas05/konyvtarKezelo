using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtarKezelo
{
    public class Book
    {
        public string Title { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Category})";
        }
    }

}

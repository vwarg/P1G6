using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    public class Category
    {
        public int ID { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int parentCategory { get; set; }

    }

}

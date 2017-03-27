using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    public class Category
    {
        // This is a comment
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentCategory { get; set; }
    }
}

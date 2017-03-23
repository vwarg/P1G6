using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    public class Product
    {
        public int ID { get; set; }

        public string name { get; set; }

        public string short_description { get; set; }

        public string description { get; set; }

        public int parentProduct { get; set; }

        public float price { get; set; }

        public int countPerUnit { get; set; }

        public int quantity { get; set; }

        public string comment { get; set; }

        public string image { get; set; }

        public string video { get; set; }

        public int status { get; set; }

        public int manufacturerID { get; set; }

        public string manufacturer_productnumber { get; set; }

        public int categoryID { get; set; }

    }
}

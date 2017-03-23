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

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public int ParentProduct { get; set; }

        public float Price { get; set; }

        public int CountPerUnit { get; set; }

        public int Quantity { get; set; }

        public string Comment { get; set; }

        public string Image { get; set; }

        public string Video { get; set; }

        public int Status { get; set; }

        public int ManufacturerID { get; set; }

        public string ManufacturerProductNumber { get; set; }

        public int CategoryID { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    public class OrderToProduct
    {
        public int ID { get; set; }

        public int productID { get; set; }

        public int orderID { get; set; }

        public int quantity { get; set; }

        public float price { get; set; }

    }
}

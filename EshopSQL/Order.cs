using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    /// <summary>
    /// Order
    /// </summary>
    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int BillingAdressID { get; set; }
        public int DeliveryAdressID { get; set; }
        public float TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateProcessed { get; set; }
        public DateTime DateFulfilled { get; set; }
        public int Status { get; set; }

        public List<OrderToProduct> GetRows()
        {
            // SELECT * FROM OrderToProduct WHERE orderID = {ID}
            return null;
        }
    }
}

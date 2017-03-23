using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    public class Orders
    {
        public int ID { get; set; }

        public int userID { get; set; }

        public int billingadressID { get; set; }

        public int deliveryadressID { get; set; }

        public float total_price { get; set; }

        public DateTime dateCreated { get; set; }

        public DateTime dateProcessed { get; set; }

        public DateTime dateFulfilled { get; set; }

        public int status { get; set; }

    }
}

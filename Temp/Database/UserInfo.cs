using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public int DeliveryAdressID { get; set; }
        public int BillingAdressID { get; set; }

        public Adress GetBillingAdress()
        {
            return null;
        }
        public Adress GetShippingAdress()
        {
            return null;
        }
    }
}

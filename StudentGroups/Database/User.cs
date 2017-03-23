using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    public class User
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int ContactInfo { get; set; }

        public byte IsCompany { get; set; }

        public int Status { get; set; }

        public UserInfo GetInfo()
        {
            return null;
        }


    }
}
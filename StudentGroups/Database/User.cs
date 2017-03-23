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

        public string email { get; set; }

        public string password { get; set; }

        public int contactinfo { get; set; }

        public byte isCompany { get; set; }

        public int status { get; set; }

    }
}
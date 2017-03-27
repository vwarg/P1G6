using HeftITGemer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSQL
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Contactinfo { get; set; }
        public byte IsCompany { get; set; }
        public int Status { get; set; }
        private UserInfo ui;
        public UserInfo Info
        {
            get
            {
                
                return ui ?? (ui = SQL.GetUserInfoByID(Contactinfo));
            }
        }

        public User(int id, string email, string password, int contactinfo, byte isCompany, int status)
        {
            ID = id;
            Email = email;
            Password = password;
            Contactinfo = contactinfo;
            IsCompany = isCompany;
            Status = status;
        }

        public User()
        {

        }
    }
}

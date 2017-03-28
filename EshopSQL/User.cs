using EshopSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    /// <summary>
    /// User
    /// </summary>
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

        public User(string email, string password, int contactinfo, int status)
        {
            Email = email;
            Password = password;
            Contactinfo = contactinfo;
            Status = status;
        }

        public User()
        {

        }

        public override string ToString()
        {
            var nl = Environment.NewLine;
            var str = "User: " + nl;
            str += $"ID: {ID}" + nl;
            str += $"Email: {Email}" + nl;
            str += $"Password: {Password}" + nl;
            str += $"IsCompany: {IsCompany}" + nl;
            str += $"Status: {Status}" + nl;
            str += $"Info: {nl}";
            str += $"{Info.ToString()}";

            return str;
        }

        
    }
}

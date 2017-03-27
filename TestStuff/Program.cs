using EshopSQL;
using HeftITGemer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Adress a = new Adress("Sweden", "Karlstad", "Signalhornsgatan 66", "65634", "0", " ");
            int aid = Adress.AddAdress(a);
            UserInfo ui = new UserInfo("Test", "Testsson", "0", " ", aid, aid);
            
            User u = SQL.AddUser("test@email.com", "PASSW", ui);
            //User u = SQL.GetUserByEmail("test@email.com");
            Console.WriteLine($"User has password PSSWD? {SQL.Login(u, "PSSWD")}");
            Console.WriteLine($"User has password PASSW? {SQL.Login(u, "PASSW")}");
            Console.ReadKey();
        }
    }
}

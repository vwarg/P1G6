using EshopSQL;
using HeftITGemer;
using PasswordLib;
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
            
            User u = SQL.AddUser("toast@email.com", "PASSWO", ui);
            User tst = SQL.GetUserByEmail("toast@email.com");
            //User u = SQL.GetUserByEmail("test@email.com");
            
            //Console.WriteLine($"HASH: {h} | PLAINTEXT: {p} -- hash matches plaintext? {PasswordHelper.MatchesHash(h, p)}");
            Console.WriteLine($"User has password PASSWO? {SQL.Login(tst, "PASSWO")}");
            Console.ReadKey();
        }
    }
}

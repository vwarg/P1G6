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

            ui.BillingadressID = aid;
            ui.DeliveryadressID = aid;
            int uiid = UserInfo.AddUserInfo(ui);

            SQL.AddUser("test@email.com", "PASSW", uiid);
            User u = SQL.GetUserByEmail("test@email.com");
            //User u = new User(-1, "test@email.com", "PASSW", -1, 0, 1);
            Console.ReadKey();
        }
    }
}

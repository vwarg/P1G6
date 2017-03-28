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
            Console.WriteLine("Cache init...");
            SQL.UpdateUserCache();
            Console.WriteLine("Cache init done.");
            TestUserFlow();
            //TestProductFlow();
            //TestOrderFlow();
            Console.WriteLine("Tests done. Press any key to exit.");
            Console.ReadKey();
        }

        static void TestUserFlow()
        {
            Adress a = new Adress("Sweden", "Karlstad", "Signalhornsgatan 66", "65634", "0", " ");
            int aid = Adress.AddAdress(a);
            UserInfo ui = new UserInfo("Test", "Testsson", "0", " ", aid, aid);
            User u = SQL.AddUser("test@email.com", "PASSWO", ui);
            User tst = SQL.GetUserByEmail("test@email.com");
            Console.WriteLine($"User has password PASSWO? {SQL.Login(tst, "PASSWO")}");

            tst = SQL.GetUserByEmail("test@email.com");
            tst = SQL.GetUserByEmail("test@email.com");
            Console.WriteLine($"Fetched 4 users.");
        }

        static void TestProductFlow()
        {
            Category c = new Category(-1, "Test", "Testkategori", -1);
            int cid = Category.AddCategory(c);
            Manufacturer m = new Manufacturer(-1, "Testtillverkare", "");
            int mid = Manufacturer.AddManufacturer(m);
            Product pr = new Product(-1, "Testprodukt", "Test", "Längre test", -1, 37.5f, 2, 100, "", "", "", 1, mid, "8", cid);
            int pid = Product.AddProduct(pr);
            Console.WriteLine($"Product ID {pid} added.");
        }

        static void TestOrderFlow()
        {
            List<Product> l = SQL.GetProductsInOrder(1513);
            Console.WriteLine($"l.Count == {l.Count} (Should be 4!)");
            Console.WriteLine($"l[0].Name = {l[0].Name}");
        }
    }
}

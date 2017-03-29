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
            //TestUserFlow();
            //TestProductFlow();
            //TestOrderFlow();
            AddSomeCategoriesAndProducts(AddSomeManufacturers());
            Console.WriteLine("Tests done. Press any key to exit.");
            Console.ReadKey();
        }

        static List<int> AddSomeManufacturers()
        {
            List<int> manufaturersIDs = new List<int>();
            manufaturersIDs.Add(Manufacturer.AddManufacturer("Glada Gemet", "www.gladagemet.se"));
            manufaturersIDs.Add(Manufacturer.AddManufacturer("Happy Hålslag", "www.happyhalslag.se"));
            manufaturersIDs.Add(Manufacturer.AddManufacturer("Smajling Stift", "www.smajlingstift.se"));
            return manufaturersIDs;
        }

        static List<int> AddSomeCategoriesAndProducts(List<int> manufacturers)
        {
            List<int> categoryIDs = new List<int>();
            List<int> products = new List<int>();

            //Huvudkategorier
            int huvudkatergori = Category.AddCategory("Huvudkategori", "Huvudkategori", -1);
            int parm = Category.AddCategory("Pärmar", "All våra fina pärmar", -1);
            int gem = Category.AddCategory("Gem", "All våra fina gem", -1);
            int halslag = Category.AddCategory("Hålslag", "All våra fina hålslag", -1);
            int stift = Category.AddCategory("Stift", "All våra fina stift", -1);
            int haftapparater = Category.AddCategory("Häftapparater", "Alla våra fina häftapparater", -1);
            int pennor = Category.AddCategory("Pennor", "Alla våra fina pennor", -1);
            int miniraknare = Category.AddCategory("Minräknare", "Alla våra fina minräknare", -1);

            #region CALCS //OK
            //Miniräknare 
            int casio = Product.AddProduct("CASIO miniräknare", "En grym miniräknare", "En grym miniräknare. Kan räkna upp till 100", -1, 49.90f, 1, 1, "", "calculator.png", "", 1, manufacturers[1], "-", miniraknare);
            {
                products.Add(casio);
                Product.AddProduct("Enkel", "Enkel", "Enkel miniräknare. Kan räkna upp till 100", casio, 49.90f, 1, 1, "", "calc_simple.png", "", 1, manufacturers[1], "M1", miniraknare);
                Product.AddProduct("Avancerad", "Avancerad", "Avancerad miniräknare. Kan räkna upp till 1000", casio, 49.90f, 1, 1, "", "calc_advanced.png", "", 1, manufacturers[1], "M2", miniraknare);
            }
            #endregion //OK
            #region PENNOR
            //Pennor OK
            Product.AddProduct("Pilot Vega Gel (50-pack)", "Bra penna", "En bra penna. Kan skriva upp till 100 sidor", -1, 729.90f, 50, 1, "", "ballpoint_pen.png", "", 1, manufacturers[1], "P1", pennor);
            Product.AddProduct("Stiftpennor (50-pack)", "Bra penna", "En bra penna. Kan skriva upp till 100 sidor", -1, 329.90f, 50, 1, "", "pens.png", "", 1, manufacturers[1], "P2", pennor);
            Product.AddProduct("Färgpennor (20-pack)", "Bra penna", "En bra penna. Kan skriva upp till 100 färger", -1, 39.90f, 20, 1, "", "colored_pens.png", "", 1, manufacturers[1], "P3", pennor);
            #endregion //OK
            #region PÄRMAR //OK

            int storParm = Product.AddProduct("Pärm - Blandade färger", "En grym pärm", "En grym pärm. Kan hålla ihop upp till 100 sidor", -1, 49.90f, 1, 1, "", "binder.png", "", 1, manufacturers[1], "-", parm);
            {
                products.Add(storParm);
                Product.AddProduct("Röd", "En RÖD pärm", "En grym pärm. Kan hålla ihop upp till 100 sidor", storParm, 49.90f, 1, 1, "", "binder.png", "", 1, manufacturers[1], "ABC123R", parm);
                Product.AddProduct("Blå", "En BLÅ pärm", "En grym pärm. Kan hålla ihop upp till 100 sidor", storParm, 49.90f, 1, 1, "", "binder.png", "", 1, manufacturers[1], "ABC123B", parm);
                Product.AddProduct("Grön", "En GRÖN  pärm", "En grym pärm. Kan hålla ihop upp till 100 sidor", storParm, 49.90f, 1, 1, "", "binder.png", "", 1, manufacturers[1], "ABC123G", parm);
            }
            int deluxeParm = Product.AddProduct("Pärmar deluxe", "Pärm", "En grym pärm. Kan hålla ihop upp till 100 sidor", -1, 49.90f, 1, 1, "", "binder_deluxe.png", "", 1, manufacturers[1], "-", parm);
            {
                products.Add(deluxeParm);                
                Product.AddProduct("30x15cm", "30x15cm", "En grym pärm. Kan hålla ihop upp till 100 sidor", deluxeParm, 49.90f, 1, 1, "", "binder_deluxe.png", "", 1, manufacturers[1], "DP2", parm);
                Product.AddProduct("30x25cm", "30x25cm", "En grym pärm. Kan hålla ihop upp till 100 sidor", deluxeParm, 49.90f, 1, 1, "", "binder_deluxe.png", "", 1, manufacturers[1], "DP3", parm);
                Product.AddProduct("20x15cm", "20x15cm", "En grym pärm. Kan hålla ihop upp till 100 sidor", deluxeParm, 49.90f, 1, 1, "", "binder_deluxe.png", "", 1, manufacturers[1], "DP4", parm);
            }
            #endregion
            #region GEM
            int stortGem = Product.AddProduct("Stort gem", "Ett väldigt stort gem", "Ett stort gem för det riktigt stora jobben. Kan hålla ihop upp till 100 sidor", -1, 39.90f, 500, 1, "", "gem.png", "", 1, manufacturers[0], "-", gem);
            {
                products.Add(stortGem);
                Product.AddProduct("Röda", "Ett väldigt stort RÖTT gem", "Ett stort gem för det riktigt stora jobben. Kan hålla ihop upp till 100 sidor", stortGem, 39.90f, 500, 1, "", "gemRED.png", "", 1, manufacturers[0], "ABC123R", gem);
                Product.AddProduct("Blåa", "Ett väldigt stort BLÅTT gem", "Ett stort gem för det riktigt stora jobben. Kan hålla ihop upp till 100 sidor", stortGem, 39.90f, 500, 1, "", "gemBLUE.png", "", 1, manufacturers[0], "ABC123B", gem);
                Product.AddProduct("Gröna", "Ett väldigt stort GRÖNT gem", "Ett stort gem för det riktigt stora jobben. Kan hålla ihop upp till 100 sidor", stortGem, 39.90f, 500, 1, "", "gemGREEN.png", "", 1, manufacturers[0], "ABC123G", gem);
            }
            #endregion
            #region HÅLSLAG
            //Hålslag
            {
                Product.AddProduct("Bra hålslag", "Ett väldigt bra hålslag", "Ett väldigt bra hålslag. Kan håla upp till 100 sidor", -1, 129.90f, 1, 1, "", "halslag1.png", "", 1, manufacturers[1], "H1", halslag);
                Product.AddProduct("Fint hålslag", "Ett väldigt fint hålslag", "Ett väldigt bra hålslag. Kan håla upp till 100 sidor", -1, 99.90f, 1, 1, "", "halslag2.png", "", 1, manufacturers[1], "H2", halslag);
                Product.AddProduct("Snyggt hålslag", "Ett väldigt snyggt hålslag", "Ett väldigt bra hålslag. Kan håla upp till 100 sidor", -1, 119.90f, 1, 1, "", "halslag3.png", "", 1, manufacturers[1], "H3", halslag);
            }
            #endregion
            #region STIFT
            //Stift
            {
                Product.AddProduct("Stift", "Ett väldigt bra stift", "Ett väldigt bra stift. Kan hålla upp till 100 sidor", -1, 129.90f, 100, 1, "", "pin1.png", "", 1, manufacturers[2], "S1", stift);
                Product.AddProduct("Häftstift", "Ett väldigt bra häftstift", "Ett väldigt bra stift. Kan hålla upp till 100 sidor", -1, 99.90f, 200, 1, "", "pin2.png", "", 1, manufacturers[2], "S2", stift);
                Product.AddProduct("Pins", "En väldigt bra pin", "Ett väldigt bra stift. Kan hålla upp till 100 sidor", -1, 95.90f, 50, 1, "", "pin3.png", "", 1, manufacturers[2], "S3", stift);
            }
            #endregion
            #region HÄFTAPPARATER
            //Häftapparater
            {
                Product.AddProduct("Bra häftapparat", "En väldigt bra häftapparat", "En väldigt bra häftapparat. Kan häfta upp till 100 sidor", -1, 129.90f, 1, 1, "", "ha1.png", "", 1, manufacturers[2], "HA1", haftapparater);
                Product.AddProduct("Fin häftapparat", "En väldigt fin häftapparat", "En väldigt fin häftapparat. Kan häfta upp till 100 sidor", -1, 99.90f, 1, 1, "", "ha2.png", "", 1, manufacturers[2], "HA2", haftapparater);
                Product.AddProduct("Snygg häftapparat", "En väldigt snygg häftapparat", "En väldigt snygg häftapparat. Kan häfta upp till 100 sidor", -1, 119.90f, 1, 1, "", "ha3.png", "", 1, manufacturers[2], "HA3", haftapparater);

                Product.AddProduct("Klämborttagare", "En väldigt snygg Klämborttagare", "En väldigt snygg Klämborttagare. Kan ta bort upp till 100 stift", -1, 119.90f, 1, 1, "", "clamp_remover.png", "", 1, manufacturers[2], "HA4", haftapparater);
            }
            #endregion

            return products;

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

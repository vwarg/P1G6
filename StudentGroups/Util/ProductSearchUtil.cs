using HeftITGemer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroups.Util
{
    static class ProductSearchUtil
    {
        public static List<Product> Find(string searchFor)
        {
            List<Product> found = new List<Product>();

            var all = new List<Product>();  // TODO: Fetch all products and store in all

            /*        
             *        PRIORITIES FOR SEARCHING
             *          #1: ID
             *          #2: ManufacturerProductNumber
             *          #3: Name
             *          #4: Description / ShortDescription
             *          #5: Manufacturer
             *          #6: Category
             *          
             *          Exact > Fuzzy (Contains)
             */

            found.AddRange(AddExactMatches(searchFor, all));
            found.AddRange(AddFuzzyMatches(searchFor, all));

            return found;
        }

        private static List<Product> AddFuzzyMatches(string searchFor, List<Product> all)
        {
            var found = new List<Product>();
            // #1
            found.AddRange(all.Where(p => p.ID.ToString().Contains(searchFor)));

            // #2
            found.AddRange(all.Where(p => p.ManufacturerProductNumber.Contains(searchFor)));

            // #3
            found.AddRange(all.Where(p => p.Name.Contains(searchFor)));

            // #4
            found.AddRange(all.Where(p => (p.Description != null && p.Description.Contains(searchFor)) || (p.ShortDescription != null && p.ShortDescription.Contains(searchFor))));

            // #5 -- TODO
            // #6 -- TODO
            return found;
        }

        private static List<Product> AddExactMatches(string searchFor, List<Product> all)
        {
            var found = new List<Product>();
            // #1
            found.AddRange(all.Where(p => p.ID.ToString() == searchFor));

            // #2
            found.AddRange(all.Where(p => p.ManufacturerProductNumber == searchFor));

            // #3
            found.AddRange(all.Where(p => p.Name == searchFor));

            // #4
            found.AddRange(all.Where(p => (p.Description != null && p.Description == searchFor) || (p.ShortDescription != null && p.ShortDescription == searchFor)));

            // #5 -- TODO
            // #6 -- TODO
            return found;
        }
    }
}

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
             *          #5: Manufacturer.Name
             *          #6: Category.Name
             *          
             *          Exact > Contains > Fuzzy (threshold: 2)
             */

            found.AddRange(AddExactMatches(searchFor, all));
            found.AddRange(AddContainsMatches(searchFor, all));
            found.AddRange(AddFuzzyMatches(searchFor, all));

            return found;
        }

        private static List<Product> AddContainsMatches(string searchFor, List<Product> all)
        {
            var found = new List<Product>();
            // #1
            // found.AddRange(all.Where(p => p.ID.ToString().Contains(searchFor))); Logic error, should not match ID on contains

            // #2
            // found.AddRange(all.Where(p => p.ManufacturerProductNumber.Contains(searchFor))); same as above

            // #3
            found.AddRange(all.Where(p => p.Name.Contains(searchFor)));

            // #4
            found.AddRange(all.Where(p => (p.Description != null && p.Description.Contains(searchFor)) || (p.ShortDescription != null && p.ShortDescription.Contains(searchFor))));

            // #5 -- TODO
            // #6 -- TODO
            return found;
        }

        private static List<Product> AddFuzzyMatches(string searchFor, List<Product> all)
        {
            var found = new List<Product>();
            int thresh = 2;
            // #1
            // found.AddRange(all.Where(p => DamerauLevenshteinDistance(p.ID.ToString(),searchFor, thresh) < int.MaxValue)); logic error, should not fuzzy-match ID

            // #2
            // found.AddRange(all.Where(p => DamerauLevenshteinDistance(p.ManufacturerProductNumber, searchFor, thresh) < int.MaxValue)); same as above

            // #3
            found.AddRange(all.Where(p => DamerauLevenshteinDistance(p.Name, searchFor, thresh) < int.MaxValue));

            // #4
            found.AddRange(all.Where(p => (p.Description != null && DamerauLevenshteinDistance(p.Description, searchFor, thresh) < int.MaxValue) || (p.ShortDescription != null && DamerauLevenshteinDistance(p.ShortDescription, searchFor, thresh) < int.MaxValue)));

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



        //Code from SO: http://stackoverflow.com/a/9454016

        /// <summary>
        /// Computes the Damerau-Levenshtein Distance between two strings.
        /// Includes an optional threshhold which can be used to indicate the maximum allowable distance.
        /// </summary>
        /// <param name="source">An array of the code points of the first string</param>
        /// <param name="target">An array of the code points of the second string</param>
        /// <param name="threshold">Maximum allowable distance</param>
        /// <returns>Int.MaxValue if threshhold exceeded; otherwise the Damerau-Leveshteim distance between the strings</returns>
        public static int DamerauLevenshteinDistance(string source, string target, int threshold)
        {

            int length1 = source.Length;
            int length2 = target.Length;

            // Return trivial case - difference in string lengths exceeds threshhold
            if (Math.Abs(length1 - length2) > threshold) { return int.MaxValue; }

            // Ensure arrays [i] / length1 use shorter length 
            if (length1 > length2)
            {
                Swap(ref target, ref source);
                Swap(ref length1, ref length2);
            }

            int maxi = length1;
            int maxj = length2;

            int[] dCurrent = new int[maxi + 1];
            int[] dMinus1 = new int[maxi + 1];
            int[] dMinus2 = new int[maxi + 1];
            int[] dSwap;

            for (int i = 0; i <= maxi; i++) { dCurrent[i] = i; }

            int jm1 = 0, im1 = 0, im2 = -1;

            for (int j = 1; j <= maxj; j++)
            {

                // Rotate
                dSwap = dMinus2;
                dMinus2 = dMinus1;
                dMinus1 = dCurrent;
                dCurrent = dSwap;

                // Initialize
                int minDistance = int.MaxValue;
                dCurrent[0] = j;
                im1 = 0;
                im2 = -1;

                for (int i = 1; i <= maxi; i++)
                {

                    int cost = source[im1] == target[jm1] ? 0 : 1;

                    int del = dCurrent[im1] + 1;
                    int ins = dMinus1[i] + 1;
                    int sub = dMinus1[im1] + cost;

                    //Fastest execution for min value of 3 integers
                    int min = (del > ins) ? (ins > sub ? sub : ins) : (del > sub ? sub : del);

                    if (i > 1 && j > 1 && source[im2] == target[jm1] && source[im1] == target[j - 2])
                        min = Math.Min(min, dMinus2[im2] + cost);

                    dCurrent[i] = min;
                    if (min < minDistance) { minDistance = min; }
                    im1++;
                    im2++;
                }
                jm1++;
                if (minDistance > threshold) { return int.MaxValue; }
            }

            int result = dCurrent[maxi];
            return (result > threshold) ? int.MaxValue : result;
        }
        static void Swap<T>(ref T arg1, ref T arg2)
        {
            T temp = arg1;
            arg1 = arg2;
            arg2 = temp;
        }
    }
}

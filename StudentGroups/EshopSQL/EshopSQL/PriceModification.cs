using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    public class PriceModification
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        public float? ModifierPercent { get; set; }
        public float? ModifierAbsolute { get; set; }
        public DateTime? DateStarts { get; set; }
        public DateTime? DateEnds { get; set; }

        public bool AppliesTo(Product p)
        {
            //  ((SELECT COUNT(*) AS c FROM PriceModToProduct WHERE modifierID = {ID} AND productID = {p.ID}) > 0 || (p.CategoryID == CategoryID))          // Is the product affected by this modifier at all
            //      && ((DateStarts == null || DateStarts.CompareTo(DateTime.Now) < 0) && (DateEnds == null || DateEnds.CompareTo(DateTime.Now) > 0))       // Is current date inside the interval (if any)
            return false;
        }
    }
}

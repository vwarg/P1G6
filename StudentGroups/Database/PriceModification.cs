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

        public int? categoryID { get; set; }

        public float? modifierPercent { get; set; }

        public float? modifierAbsolute { get; set; }

        public DateTime? dateStarts { get; set; }

        public DateTime? dateEnds { get; set; }

    }
}

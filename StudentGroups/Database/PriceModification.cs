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

    }
}

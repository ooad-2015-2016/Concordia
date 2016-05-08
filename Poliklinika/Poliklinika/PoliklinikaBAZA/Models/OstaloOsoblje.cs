using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaBAZA.Models
{
    public enum tipZaposlenika { Blagajnik, Recepcionar, Administrator}
    public class OstaloOsoblje : Osoblje
    {
       public tipZaposlenika tip { get; set; }

        public OstaloOsoblje(string ime, string prezime, DateTime datumRodjenja, float plata, tipZaposlenika tip) : base(ime, prezime, datumRodjenja, plata)
        {
            this.tip = tip;
        }
    }
}

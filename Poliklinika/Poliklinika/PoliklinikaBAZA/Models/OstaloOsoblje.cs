using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaBAZA.Models
{
    public class OstaloOsoblje : Osoblje
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OstaloOsobljeId { get; set; }
        public string tip { get; set; }

        public OstaloOsoblje()
        {

        }
        public OstaloOsoblje(string ime, string prezime, DateTime datumRodjenja, float plata, string tip) : base(ime, prezime, datumRodjenja, plata)
        {
            this.tip = tip;
        }
    }
}

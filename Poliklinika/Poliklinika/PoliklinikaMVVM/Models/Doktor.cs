using Poliklinika.PoliklinikaBAZA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
    public class Doktor : Osoblje
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoktorId { get; set; }
        public int odjelId { get; set; }

        public Doktor() { }

        public Doktor(string ime, string prezime, DateTime datumRodjenja, float plata, int odjel) : base(ime, prezime, datumRodjenja, plata)
        {

            this.odjelId = odjel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
   public class PacijentA
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string JMBG { get; set; }

        public PacijentA() { }
        public PacijentA(string ime, string prezime, DateTime datumr, string jmbg)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumr;
            this.JMBG = jmbg;
        }

        public string dajNaziv() { return ime + " " + prezime; }

    }
}

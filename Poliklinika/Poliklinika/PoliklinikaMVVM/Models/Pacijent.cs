using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
   public class Pacijent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacijentId { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string JMBG { get; set; }

        public Pacijent() { }
        public Pacijent(string ime, string prezime, DateTime datumr, string jmbg)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumr;
            this.JMBG = jmbg;
        }

        public string dajNaziv() { return ime + " " + prezime; }

    }
}

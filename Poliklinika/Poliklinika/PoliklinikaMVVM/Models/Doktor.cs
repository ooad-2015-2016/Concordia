using Poliklinika.PoliklinikaBAZA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
   public class Doktor : Osoblje
    {
        public Odjel odjel { get; set; }

        public Doktor(string ime, string prezime, DateTime datumRodjenja, float plata, Odjel odjel) : base(ime, prezime, datumRodjenja, plata)
        {

            this.odjel = odjel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
    public class Zaposlenik
    {
        public int zaposlenikId { get; set; }//primary key u bazi
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public DateTime datumZaposlenja { get; set; }
        public double plata { get; set; }
        public string username { get; set; }
        public int password { get; set; }

        public Zaposlenik(string ime, string prezime, DateTime datumRodjenja, double plata)
        {
            this.zaposlenikId = 1;//?
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.datumZaposlenja = DateTime.Now;
            this.plata = plata;
            this.password = new Random().Next(10000, 99999);
        }
        public Zaposlenik()
        {
            this.password = new Random().Next(10000, 99999);
        }
    }
}

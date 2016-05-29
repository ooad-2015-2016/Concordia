using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaBAZA.Models
{
   public class Osoblje
    {

       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int OsobljeId { get; set; }//primary key u bazi
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public double Plata { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Osoblje(string ime, string prezime, DateTime datumRodjenja,  float plata)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datumRodjenja;
            this.DatumZaposlenja = DateTime.Now;
            this.Plata = plata;
            this.Password = Convert.ToString(new Random().Next(10000, 99999));
        }

        public Osoblje()
        {
            this.Password = Convert.ToString(new Random().Next(10000, 99999));
        }
    }
}

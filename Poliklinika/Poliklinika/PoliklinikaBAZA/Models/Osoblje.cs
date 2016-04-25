using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaBAZA.Models
{
    class Osoblje
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OsobljeId { get; set; }//primary key u bazi
        public string Ime { get; set; }//trebati ce za sihronizaciju kasnije
        public string Prezime { get; set; }//naziv restorana
        public float DatumRodjenja { get; set; }//tekst o restoranu
        public float DatumZaposlenja { get; set; }//slika restorana
        public float Plata { get; set; }//broj telefona
        public string Username { get; set; }//geografska sirina i duzina gdje se nalazi restoran
        public string Password { get; set; }
    }
}

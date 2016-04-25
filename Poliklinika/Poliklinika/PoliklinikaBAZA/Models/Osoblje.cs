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
        public int OsobljeId { get; set; }//primary key u bazi
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public float Plata { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

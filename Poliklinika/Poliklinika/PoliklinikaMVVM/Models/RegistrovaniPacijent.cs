using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
    public class RegistrovaniPacijent : PacijentA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistrovaniPacijentId { get; set; }
        public DateTime? datumRegistracije { get; set; }
        public string username { get; set; }
        public int password { get; set; }

        public RegistrovaniPacijent(string ime, string prezime, DateTime datumr, string jmbg) : base(ime, prezime, datumr, jmbg)
        {
            int br = new Random().Next(1000, 9999);
            username = prezime + Convert.ToString(br);
            password = new Random().Next(10000, 99999);
        }
        public RegistrovaniPacijent()
        {

        }

        
    }
}

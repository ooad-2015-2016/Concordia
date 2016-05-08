using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
    public class RegistrovaniPacijent : Pacijent
    {
        public DateTime datumRegistracije { get; set; }
        public string username { get; set; }
        public int password { get; set; }

        public RegistrovaniPacijent(string ime, string prezime, DateTime datumr, string jmbg) : base(ime, prezime, datumr, jmbg)
        {
            int br = new Random().Next(1000, 9999);
            username = prezime + Convert.ToString(br);
            password = new Random().Next(10000, 99999);
        }

    }
}

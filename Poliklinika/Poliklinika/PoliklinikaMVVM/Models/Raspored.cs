using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
    public class Raspored
    {
        public List<Pregled> zakazaniPregledi { get; set; }

        public Raspored()
        {
            zakazaniPregledi = new List<Pregled>();
        }

        public void dodajPregled(Pregled pregled)
        {
            zakazaniPregledi.Add(pregled);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
    public class Pretraga
    {
        public string naziv { get; set; }
        public float cijena { get; set; }

        public Pretraga()
        {

        }
        public Pretraga(string naziv, float cijena)
        {
            this.naziv = naziv;
            this.cijena = cijena;
        }
    }
}

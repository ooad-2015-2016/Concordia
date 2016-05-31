using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
   public class Pacijent : PacijentA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacijentId { get; set; }
        
        public Pacijent() { }
        public Pacijent(string ime, string prezime, DateTime datumr, string jmbg) : base(ime,prezime,datumr,jmbg)
        { }


    }
}

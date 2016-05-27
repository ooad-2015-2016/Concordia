using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
   public class Racun
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RacunId { get; set; }
        public int pregledId { get; set; }
        public float cijena { get; set; }
        public string status { get; set; }
        public Racun() {
            status = "nije plaćeno";
        }
    }
}

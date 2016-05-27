using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
    public class Pregled
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PregledId { get; set; }
        public int pacijentId { get; set; }
        public int zdKartonId { get; set; }
        public DateTime termin { get; set; }
        public int odjelId { get; set; }
        public string status { get; set; }
        public ObservableCollection<Pretraga> pretrage { get; set; }

        public Pregled()
        {
            pretrage = new ObservableCollection<Pretraga>();
            this.status = "na čekanju";
        }

       
        public void unesiDijagnozu(ObservableCollection<Pretraga> pretrage)
        {
            this.pretrage = pretrage;
            this.status = "obavljen";
        }
    }
}

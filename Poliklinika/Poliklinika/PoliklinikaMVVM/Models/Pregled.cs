using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
    public class Pregled
    {
        public int idPregled { get; set; }
        public Pacijent pacijent { get; set; }
        public DateTime termin { get; set; }
        public string odjel { get; set; }
        public string status { get; set; }
        public ObservableCollection<Pretraga> pretrage { get; set; }

        public Pregled()
        {
            pretrage = new ObservableCollection<Pretraga>();
        }

        public Pregled(Pacijent pacijent, DateTime termin, string odjel)
        {
            this.idPregled = 1;// kako da se automatski generiše id?
            this.pacijent = pacijent;
            this.termin = termin;
            this.odjel = odjel;
            this.status = "na čekanju";
        }

        public void unesiDijagnozu(ObservableCollection<Pretraga> pretrage)
        {
            this.pretrage = pretrage;
            this.status = "obavljen";
        }
    }
}

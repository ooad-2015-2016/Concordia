using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
    public enum tipOdjela { porodicnaMedicina, dermatologija, internaMedicina, ginekologija, gastroenterologija }

    public class Odjel
    {
        public string naziv { get; set; }
        public List<Pretraga> pretrage { get; set; }
        public Raspored raspored { get; set; }
        public Doktor doktor { get; set; }

        public Odjel()
        {
            pretrage = new List<Pretraga>();
        }

        public void povuciPretrage()
        {
            if (naziv.Equals("dermatologija"))
            {

                Pretraga p1 = new Pretraga("Hemijski piling", 123);

                pretrage.Add(p1);

                Pretraga p2 = new Pretraga("Digitalna dermatoskopija", 123);

                pretrage.Add(p2);

                Pretraga p3 = new Pretraga("Dermatološki pregled", 123);

                pretrage.Add(p3);

            }
            else if (naziv.Equals("porodicna medicina"))
            {
                Pretraga p4 = new Pretraga("Konsultacije", 123);

                pretrage.Add(p4);
            }
        }



        public Odjel(string naziv, List<Pretraga> pretrage, Raspored raspored)
        {
            this.naziv = naziv;
            this.pretrage = pretrage;
            this.raspored = raspored;
        }

        public void ZaposliDoktora(Doktor d)
        {
            this.doktor = d;
        }

        public bool provjeriTermin(string nazivPacijenta)
        {
            foreach (Pregled p in raspored.zakazaniPregledi)
            {
                if (p.pacijent.dajNaziv().Equals(nazivPacijenta)) return true;
            }
            return false;
        }
    }
}

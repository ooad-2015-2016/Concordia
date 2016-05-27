using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.PoliklinikaMVVM.Models
{
   
    public class Odjel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OdjelId { get; set; }
        public string naziv { get; set; }
        

        public Odjel()
        {
           
        }

     /*   public void povuciPretrage()
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
        }*/



        public Odjel(string naziv)
        {
            this.naziv = naziv;
        }

      

       /* public bool provjeriTermin(string nazivPacijenta)
        {
            foreach (Pregled p in raspored.zakazaniPregledi)
            {
                if (p.pacijent.dajNaziv().Equals(nazivPacijenta)) return true;
            }
            return false;
        }*/
    }
}

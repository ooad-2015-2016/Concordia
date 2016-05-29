using Poliklinika.PoliklinikaBAZA.Models;
using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Poliklinika.PoliklinikaMVVM.ViewModels
{
   public class ZakazivanjePregledaViewModel
    {
        public INavigationService NavigationService { get; set; }
        public ICommand PrikaziTermine { get; set; }
        public ICommand ZakaziPregled { get; set; }

        public List<string> stavke { get; set; }
        public string odabrani { get; set; }

        public string ime { get; set; }
        public string prezime { get; set; }
        public string odjel { get; set; }

        public ZakazivanjePregledaViewModel()
        {
            NavigationService = new NavigationService();

            PrikaziTermine = new RelayCommand<object>(prikaziTermine, mozeLi);
            ZakaziPregled = new RelayCommand<object>(zakaziPregled, mozeLi);

            stavke = new List<string>();
            stavke.Add("proba");
            stavke.Add("proba2");
        }


        public bool mozeLi(object parametar) { return true; }
        public void prikaziTermine(object parametar)
        {
            //ništa
        }

        public void zakaziPregled(object parametar)
        {
            Pregled p = new Pregled();
            int id = 0;
            int oId = 0;

            using (var db = new PoliklinikaDbContext())
            {
                foreach(Pacijent k in db.Pacijenti)
                {
                    if (k.ime.Equals(ime) && k.prezime.Equals(prezime)) id = k.PacijentId;
                }
                /*foreach (RegistrovaniPacijent k in db.RegPacijenti)
                {
                    if (k.ime.Equals(ime) && k.prezime.Equals(prezime)) id = k.RegPacijentId;  
                }*/

                foreach(Odjel o in db.Odjeli)
                {
                    if (o.naziv.Equals(odjel)) oId = o.OdjelId;
                }
              

            }
            p.pacijentId = id;
            p.status = "na čekanju";
            p.termin = DateTime.Now; // da proradi samo hh
            p.odjelId = oId;

            using (var d = new PoliklinikaDbContext())
            {
                d.Pregledi.Add(p);
                d.SaveChanges();
            }
            /*
             * 
            //odabrani datum parse DateTime 
            Pregled p=new Pregled();
            p.pacijentId = 0; //naći u bazi po imenu i prezimenu
            p.status = "na čekanju";
            p.termin=odabraniiiiii
            
                */
            
        }
    }
}

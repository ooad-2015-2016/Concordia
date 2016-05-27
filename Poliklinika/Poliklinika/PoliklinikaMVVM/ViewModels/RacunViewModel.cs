
using Microsoft.Data.Entity;
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
   public class RacunViewModel
    {
        public NaplacivanjeViewModel Parent { get; set; }
        public List<string> stavke { get; set; }
        public float ukupnaCijena { get; set; }
        public ICommand ZatvoriRacun { get; set; }

        public RacunViewModel(NaplacivanjeViewModel parent, string ime, string prezime)
        {

            this.Parent = parent;
            //nađi u bazi pregled od tog pacijenta/zadnji koji nije plaćen
            //povuci pretrage i izračunati iznos
            Racun he=new Racun();

            stavke = new List<string>();
            ukupnaCijena = 0;

            int id=0;
            using (var db = new PoliklinikaDbContext())
            {

                foreach(Pacijent w in db.Pacijenti)
                {
                    if(w.ime.Equals(ime) && w.prezime.Equals(prezime))
                    {
                        id = w.PacijentId;
                    }
                }
                
                //provjeriti
                foreach (Racun r in db.Racuni)
                {
                    if(r.status=="nije placen")
                    {
                        foreach (Pregled p in db.Pregledi)
                        {
                            if (p.PregledId.Equals(r.pregledId) && p.pacijentId.Equals(id))
                            {
                                parent.idRacuna = r.RacunId;

                                foreach (Pretraga k in db.Pretrage)
                                {
                                    string s="";
                                    if (k.pregledId.Equals(p.PregledId))
                                    {
                                        s = k.naziv + "  -  " + k.cijena.ToString();
                                        ukupnaCijena += k.cijena;
                                        stavke.Add(s);
                                    }
                                    
                                }

                               he = db.Racuni.Where(s => s.RacunId == parent.idRacuna).FirstOrDefault<Racun>();
                               he.cijena = ukupnaCijena;
                            }
                        }

                        
                    }
                }


                using (var d = new PoliklinikaDbContext())
                {
                    d.Entry(he).State = EntityState.Modified;
                    d.SaveChanges();
                }

            }

            ZatvoriRacun = new RelayCommand<object>(zatvori, mozeLi);
          
        }

        public void zatvori(object parametar)
        {

            Parent.poruka = "Ukupna cijena je " + ukupnaCijena.ToString() + "KM";
            
            Parent.NavigationService.GoBack();
        }

        public bool mozeLi(object parametar)
        {
            return true;
        }
    }
}

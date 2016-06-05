using Poliklinika.PoliklinikaBAZA.Models;
using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.Models;
using Poliklinika.PoliklinikaMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Poliklinika.PoliklinikaMVVM.ViewModels
{
    class RasporedViewModel
    {
        public ICommand PregledKartona { get; set; }
        public INavigationService NavigationService { get; set; }
        public Pacijent odabrani { get; set; }
        public List<Pacijent> pacijenti { get; set; }

        public List<string> pregledi { get; set; }

        public RasporedViewModel()
        {

            NavigationService = new NavigationService();
            PregledKartona = new RelayCommand<object>(pregledKartona, mozeLi);

            // pročita iz tabele pregleda

            pregledi = new List<string>();
            using (var db = new PoliklinikaDbContext())
            {
                foreach (Pregled p in db.Pregledi)
                {
                    if (!(p.status.Equals("obavljen"))) {
                        string s;
                        s = p.termin.Date.ToString();
                        s = "10:00";

                        foreach (ZdravstveniKarton z in db.ZdravstveniKartoni)
                        {
                            if (p.zdKartonId.Equals(z.ZdravstveniKartonId)){
                                
                                        s += (" - " + z.imePacijenta + " " + z.prezimePacijenta);
                                    
                                
                            }

                        }

                        

                        foreach (Pacijent k in db.Pacijenti)
                        {
                            if (p.pacijentId.Equals(k.PacijentId))
                            {
                                s += (" - " + k.ime + " " + k.prezime);
                            }
                        }

                        
                        foreach (Odjel o in db.Odjeli)
                        {
                            if (o.OdjelId.Equals(p.odjelId))
                            {
                                s += (" - " + o.naziv);
                            }
                        }

                        pregledi.Add(s);
                    }
                }
            }

        }
        public bool mozeLi(object parametar) { return true; }


        public void pregledKartona(object parametar)
        {
            NavigationService.Navigate(typeof(ZdravstveniKartonView), new ZdravstveniKartonViewModel(this));
        }
    }
}

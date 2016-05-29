using Microsoft.Data.Entity;
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
using Windows.UI.Popups;

namespace Poliklinika.PoliklinikaMVVM.ViewModels
{
    public class PregledViewModel 
    {
        public Pregled Pregled { get; set; }
        public INavigationService NavigationService { get; set; }
        public ICommand DodavanjePretrage { get; set; }
        public ICommand PregledKartona { get; set; }

        public ICommand ZavrsenPregled { get; set; }
        public string pomoc { get; set; }
        public string pomoc2 { get; set; }
        public string pomoc3 { get; set; }
        public int prId { get; set; }

        public PregledViewModel()
        {
            Pregled = new Pregled();
            NavigationService = new NavigationService();

            DodavanjePretrage = new RelayCommand<object>(dodavanjePretrage, mozeLi);
            PregledKartona = new RelayCommand<object>(pregledKartona, mozeLi);
            ZavrsenPregled = new RelayCommand<object>(zavrsenPregled, mozeLi);
        }


        public bool mozeLi(object parametar) { return true; }
        public void dodavanjePretrage(object parametar)
        {
            Pregled he = new Pregled();
            int Pid = 0;
            prId = 0;
            using (var db = new PoliklinikaDbContext())
            {
                foreach (Pacijent p in db.Pacijenti)
                {
                    if (p.ime.Equals(pomoc) && p.prezime.Equals(pomoc2))
                    {
                        Pid = p.PacijentId;
                    }
                }

                foreach (Pregled k in db.Pregledi)
                {
                    if (k.pacijentId.Equals(Pid) && k.status.Equals("na čekanj"))
                    {
                        prId = k.PregledId;
                    }
                }
            }

            NavigationService.Navigate(typeof(UnosPretrageView), new PretragaViewModel(this));
        }

        public void pregledKartona(object parametar)
        {
            NavigationService.Navigate(typeof(ZdravstveniKartonView), new ZdravstveniKartonViewModel(this));
        }

        public void zavrsenPregled(object parametar)
        {
            Pregled he = new Pregled();
           
                

            using (var dx = new PoliklinikaDbContext())
            {
                he = dx.Pregledi.Where(s => s.PregledId== prId).FirstOrDefault<Pregled>();
                he.status = "obavljen";
            }

            using (var d = new PoliklinikaDbContext())
            {
                d.Entry(he).State = EntityState.Modified;
                d.SaveChanges();
            }
            


        }

    }
}

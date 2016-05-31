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
        public ICommand Izlaz { get; set; }

        public ICommand ZavrsenPregled { get; set; }
        public string pomoc { get; set; }
        public string pomoc2 { get; set; }
        public string pomoc3 { get; set; }
        public int prId { get; set; }
        public int pId { get; set; }
        public int ZKId { get; set; }

        public PregledViewModel()
        {
            Pregled = new Pregled();
            NavigationService = new NavigationService();

            DodavanjePretrage = new RelayCommand<object>(dodavanjePretrage, mozeLi);
            PregledKartona = new RelayCommand<object>(pregledKartona, mozeLi);
            ZavrsenPregled = new RelayCommand<object>(zavrsenPregled, mozeLi);
            Izlaz = new RelayCommand<object>(izlaz, mozeLi);


        }


        public bool mozeLi(object parametar) { return true; }

   

        public async void dodavanjePretrage(object parametar)
        {
            bool nemaZakazan = true;
            

            using (var db = new PoliklinikaDbContext())
            {
                foreach (Pacijent p in db.Pacijenti)
                {
                    if (p.ime.Equals(pomoc) && p.prezime.Equals(pomoc2))
                    {
                        pId = p.PacijentId;
                    }
                }
                foreach (RegistrovaniPacijent p in db.RegistrovaniPacijenti)
                {
                    if (p.ime.Equals(pomoc) && p.prezime.Equals(pomoc2))
                    {
                        ZKId = p.RegistrovaniPacijentId;
                    }
                }

                foreach(Pregled p in db.Pregledi)
                {
                    if (p.pacijentId.Equals(pId) && !(p.status.Equals("obavljen"))) nemaZakazan = false;
                    if(p.zdKartonId.Equals(ZKId) && !(p.status.Equals("obavljen"))) nemaZakazan = false;
                }
            }

                if (pomoc == "" || pomoc2 == "" || pomoc3=="" || OkOdjel(pomoc3) == false)
                {
                    var dialog3 = new MessageDialog("Nisu validni podaci!", "Poliklinika Concordia");

                    await dialog3.ShowAsync();
                }
                else if (nemaZakazan)
                {
                    var dialog3 = new MessageDialog("Navedeni pacijent nema zakazan termin!", "Poliklinika Concordia");

                    await dialog3.ShowAsync();
                }
                else
                {
                    Pregled he = new Pregled();
                    pId = 0;
                    ZKId = 0;
                    prId = 0;
                    using (var db = new PoliklinikaDbContext())
                    {
                        foreach (Pacijent p in db.Pacijenti)
                        {
                            if (p.ime.Equals(pomoc) && p.prezime.Equals(pomoc2))
                            {
                                pId = p.PacijentId;
                            }
                        }
                        foreach (RegistrovaniPacijent p in db.RegistrovaniPacijenti)
                        {
                            if (p.ime.Equals(pomoc) && p.prezime.Equals(pomoc2))
                            {
                                ZKId = p.RegistrovaniPacijentId;
                            }
                        }

                        foreach (Pregled k in db.Pregledi)
                        {
                            if (k.pacijentId.Equals(pId) && !(k.status.Equals("obavljen")))
                            {
                                prId = k.PregledId;
                            }
                            // ako je u pitanju reg pacijent
                        if (k.zdKartonId.Equals(ZKId) && !(k.status.Equals("obavljen")))
                        {
                            prId = k.PregledId;
                        }

                    }
                    }

                    NavigationService.Navigate(typeof(UnosPretrageView), new PretragaViewModel(this));
                }
        }

        public void pregledKartona(object parametar)
        {
           using (var db = new PoliklinikaDbContext())
            {
                foreach (Pacijent p in db.Pacijenti)
                {
                    if (p.ime.Equals(pomoc) && p.prezime.Equals(pomoc2))
                    {
                        pId = p.PacijentId;
                    }
                }
                foreach (RegistrovaniPacijent p in db.RegistrovaniPacijenti)
                {
                    if (p.ime.Equals(pomoc) && p.prezime.Equals(pomoc2))
                    {
                        ZKId = p.RegistrovaniPacijentId;
                    }
                }
            }
                NavigationService.Navigate(typeof(ZdravstveniKartonView), new ZdravstveniKartonViewModel(this));
        }

        public async void zavrsenPregled(object parametar)
        {
            Pregled he = new Pregled();
            Racun r = new Racun();
            r.pregledId = prId;
            r.status="nije placen";
            


            using (var dx = new PoliklinikaDbContext())
            {
                dx.Racuni.Add(r);
                dx.SaveChanges();
                he = dx.Pregledi.Where(s => s.PregledId == prId).FirstOrDefault<Pregled>();
                he.status = "obavljen";
            }

            using (var d = new PoliklinikaDbContext())
            {
                d.Entry(he).State = EntityState.Modified;
                d.SaveChanges();
            }

            var dialog3 = new MessageDialog("Završen pregled!", "Poliklinika Concordia");

            await dialog3.ShowAsync();

            NavigationService.Navigate(typeof(DoktorMenu));


        }

        public async void izlaz(object parametar)
        {
            NavigationService.Navigate(typeof(DoktorMenu));
        }

            bool OkOdjel(string odjel)
        {
            if (odjel == null) return false;
            if (odjel.Equals("dermatologija")) return true;
            else if (odjel.Equals("ginekologija")) return true;
            else if (odjel.Equals("gastroenterologija")) return true;
            else if (odjel.Equals("porodicna medicina")) return true;
            else if (odjel.Equals("interna medicina")) return true;
            return false;
        }

    }
}

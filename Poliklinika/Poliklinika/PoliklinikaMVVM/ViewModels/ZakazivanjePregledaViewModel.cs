using Poliklinika.PoliklinikaBAZA.Models;
using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.Models;
using Poliklinika.PoliklinikaMVVM.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace Poliklinika.PoliklinikaMVVM.ViewModels
{
   public class ZakazivanjePregledaViewModel
    {
        public INavigationService NavigationService { get; set; }
        public ICommand ProvjeriTermin { get; set; }
        public ICommand ZakaziPregled { get; set; }

        public List<string> stavke { get; set; }
        public string odabrani { get; set; }

        public string ime { get; set; }
        public string prezime { get; set; }
        public string odjel { get; set; }
        public DateTime datum { get; set; }
        public DateTime vrijeme { get; set; }
        public string termin { get; set; }

        public ZakazivanjePregledaViewModel()
        {
            NavigationService = new NavigationService();

            ProvjeriTermin = new RelayCommand<object>(provjeriTermin, mozeLi);
            ZakaziPregled = new RelayCommand<object>(zakaziPregled, mozeLi);
            datum = new DateTime();

            stavke = new List<string>();
            stavke.Add("proba");
            stavke.Add("proba2");
        }


        public bool mozeLi(object parametar) { return true; }
        public async void provjeriTermin(object parametar)
        {
            bool provjera = true;

            var hours = Int32.Parse(termin.Split(':')[0]);
            var minutes = Int32.Parse(termin.Split(':')[1]);

            var ts = new TimeSpan(hours, minutes, 0);

            DateTime ZTermin = datum.Date + ts;

            using (var db=new PoliklinikaDbContext())
            {
                foreach(Pregled p in db.Pregledi)
                {
                    if (p.status.Equals("neobavljen") && p.termin.Equals(ZTermin)) provjera = false;
                }
            }

            if (provjera)
            {
                var dialog3 = new MessageDialog("Termin je slobodan!", "Poliklinika Concordia");

                await dialog3.ShowAsync();
            }
            else
            {
                var dialog3 = new MessageDialog("Termin nije slobodan!", "Poliklinika Concordia");

                await dialog3.ShowAsync();
            }
        }

        public async void zakaziPregled(object parametar)
        {
            if (OkFormatTermina(termin)==false || ime == "" || prezime == "" || OkOdjel(odjel)==false)
            {
                var dialog1 = new MessageDialog("Nisu uneseni svi podaci!", "Poliklinika Concordia");

                await dialog1.ShowAsync();
            }
            else if (!OkFormatTermina(termin))
            {
                var dialog2 = new MessageDialog("Termin mora biti format hh:mm!", "Poliklinika Concordia");

                await dialog2.ShowAsync();
            }
            else if (!OkOdjel(odjel))
            {
                var dialog3 = new MessageDialog("Unijeli ste odjel koji ne postoji na našoj poliklinici!", "Poliklinika Concordia");

                await dialog3.ShowAsync();
            }
            else
            {
                Pregled p = new Pregled();
                int id = 0;
                int ZKid = 0;
                int oId = 0;

                using (var db = new PoliklinikaDbContext())
                {
                    foreach (ZdravstveniKarton k in db.ZdravstveniKartoni)
                    {
                        if (k.imePacijenta.Equals(ime) && k.prezimePacijenta.Equals(prezime)) ZKid = k.ZdravstveniKartonId;
                    }

                    foreach (Odjel o in db.Odjeli)
                    {
                        if (o.naziv.Equals(odjel)) oId = o.OdjelId;
                    }


                }
                if (id == 0)
                {
                    Pacijent novi = new Pacijent();
                    novi.ime = ime;
                    novi.prezime = prezime;
                    using(var d=new PoliklinikaDbContext())
                    {
                        d.Pacijenti.Add(novi);
                        d.SaveChanges();

                        foreach(Pacijent k in d.Pacijenti)
                        {
                            if (k.ime.Equals(ime) && k.prezime.Equals(prezime)) id = k.PacijentId;
                        }
                    }
                    
                }

                if (ZKid == 0 && id != 0) p.pacijentId = id;
                else  p.zdKartonId = ZKid;

                p.status = "neobavljen";

                var hours = Int32.Parse(termin.Split(':')[0]);
                var minutes = Int32.Parse(termin.Split(':')[1]);

                var ts = new TimeSpan(hours, minutes, 0);

                p.termin = datum.Date + ts;


                p.odjelId = oId;

                using (var d = new PoliklinikaDbContext())
                {
                    d.Pregledi.Add(p);
                    d.SaveChanges();
                }

                var dialog3 = new MessageDialog("Uspješno zakazan pregled!", "Poliklinika Concordia");

                await dialog3.ShowAsync();
                
                NavigationService.Navigate(typeof(RecepcionistMenu));

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

        bool OkFormatTermina(string termin)
        {
            if (termin[2] != ':') return false;
            if (!(termin[0] >= '0' && termin[0] <= '9')) return false;
            if (!(termin[1] >= '0' && termin[1] <= '9')) return false;
            if (!(termin[3] >= '0' && termin[3] <= '9')) return false;
            if (!(termin[4] >= '0' && termin[4] <= '9')) return false;


            return true;
        }

        bool OkOdjel(string odjel)
        {
            if (odjel.Equals("dermatologija")) return true;
            else if (odjel.Equals("ginekologija")) return true;
            else if (odjel.Equals("gastroenterologija")) return true;
            else if (odjel.Equals("porodicna medicina")) return true;
            else if (odjel.Equals("interna medicina")) return true;
            return false;
        }
    }
}

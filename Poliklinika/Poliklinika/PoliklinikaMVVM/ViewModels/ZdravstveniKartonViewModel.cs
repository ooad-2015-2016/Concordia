using Poliklinika.PoliklinikaBAZA.Models;
using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace Poliklinika.PoliklinikaMVVM.ViewModels
{
    class ZdravstveniKartonViewModel
    {
        public PregledViewModel Parent { get; set; }
        public ListaPacijenataViewModel Parent2 { get; set; }
        public RasporedViewModel Parent3 { get; set; }
        public ZdravstveniKarton Karton { get; set; }
        public RegistrovaniPacijent Pacijent { get; set; }

        public List<String> historijaPretraga { get; set; }
        public string naziv { get; set; }
        public ICommand zatvori { get; set; }


        public ZdravstveniKartonViewModel(PregledViewModel parent)
        {
            this.Parent = parent;
            zatvori = new RelayCommand<object>(close, mozeLi);
            Karton = new ZdravstveniKarton();
            historijaPretraga = new List<string>();

            naziv = parent.pomoc + " " + parent.pomoc2;

            bool pronadjen = false;

            using (var db = new PoliklinikaDbContext())
            {
                foreach (ZdravstveniKarton z in db.ZdravstveniKartoni)
                {
                    if (z.imePacijenta.Equals(parent.pomoc) && z.prezimePacijenta.Equals(parent.pomoc2))
                    {
                        Karton = z;
                        pronadjen = true;
                    }
                }

                if (pronadjen == false)
                {
                    naziv = "Nema kreiran karton!";
                }
                else
                {

                    foreach (Pretraga pr in db.Pretrage)
                    {
                        foreach (Pregled a in db.Pregledi)
                        {
                            if (pr.pregledId == a.PregledId && a.pacijentId == parent.pId) historijaPretraga.Add(pr.naziv);

                            if (pr.pregledId == a.PregledId && a.zdKartonId == parent.ZKId) historijaPretraga.Add(pr.naziv);

                        }
                    }


                    foreach (RegistrovaniPacijent p in db.RegistrovaniPacijenti)
                    {
                        if (p.ime.Equals(parent.pomoc) && p.prezime.Equals(parent.pomoc2)) Pacijent = p;
                    }
                }
            }

        }

        public ZdravstveniKartonViewModel(ListaPacijenataViewModel parent)
        {
            this.Parent2 = parent;
            Karton = new ZdravstveniKarton();
            zatvori = new RelayCommand<object>(close2, mozeLi);
            historijaPretraga = new List<string>();
            
            naziv = parent.odabrani.ime +" "+ parent.odabrani.prezime;

            bool pronadjen = false;
            using (var db = new PoliklinikaDbContext())
            {
                foreach(ZdravstveniKarton z in db.ZdravstveniKartoni)
                {
                    if(z.imePacijenta.Equals(parent.odabrani.ime) && z.prezimePacijenta.Equals(parent.odabrani.prezime))
                    {
                       Karton = z;
                        pronadjen = true;
                    }

                }

                if (pronadjen == false)
                {
                    naziv = "Nema kreiran karton!";
                }
                else
                {
                    int pId = 0;

                    foreach (RegistrovaniPacijent r in db.RegistrovaniPacijenti)
                    {
                        if (r.ime.Equals(parent.odabrani.ime) && r.prezime.Equals(parent.odabrani.prezime))
                        {
                            pId = r.RegistrovaniPacijentId;
                            Pacijent = r;
                        }
                    }

                    foreach (Pretraga pr in db.Pretrage)
                    {
                        foreach (Pregled a in db.Pregledi)
                        {
                            if (pr.pregledId == a.PregledId && a.pacijentId == pId) historijaPretraga.Add(pr.naziv);
                        }
                    }



                }
            }
        }

        public ZdravstveniKartonViewModel(RasporedViewModel parent)
        {
            this.Parent3 = parent;
            Karton = new ZdravstveniKarton();
            zatvori = new RelayCommand<object>(close2, mozeLi);
            naziv = parent.odabrani.ime + parent.odabrani.prezime;
           
        }

        public void close(object parametar)
        {
            Parent.NavigationService.GoBack();
        }
        
    public void close2(object parametar)
    {
        Parent2.NavigationService.GoBack();
    }
    
        public bool mozeLi(object parametar)
        {
            return true;
        }
    }
}

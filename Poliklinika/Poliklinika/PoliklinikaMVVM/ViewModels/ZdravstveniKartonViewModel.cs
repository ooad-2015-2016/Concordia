using Poliklinika.PoliklinikaBAZA.Models;
using Poliklinika.PoliklinikaMVVM.Helper;
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
        public string naziv { get; set; }
        public ICommand zatvori { get; set; }

        public ZdravstveniKartonViewModel(PregledViewModel parent)
        {
            this.Parent = parent;
            zatvori = new RelayCommand<object>(close, mozeLi);
            Karton = new ZdravstveniKarton();

            naziv = parent.pomoc + " " + parent.pomoc2;

           
            using (var db = new PoliklinikaDbContext())
            {
                foreach (ZdravstveniKarton z in db.ZdravstveniKartoni)
                {
                    if (z.imePacijenta.Equals(parent.pomoc) && z.prezimePacijenta.Equals(parent.pomoc2)) Karton = z;
                }
                //Karton = db.ZdravstveniKartoni.First(a => a.imePacijenta.Equals(parent.pomoc) && a.prezimePacijenta.Equals(parent.pomoc2));
                if (Karton.imePacijenta == null) naziv = "Nema kreiran karton!";
            }

        }

        public ZdravstveniKartonViewModel(ListaPacijenataViewModel parent)
        {
            this.Parent2 = parent;
            Karton = new ZdravstveniKarton();
            zatvori = new RelayCommand<object>(close2, mozeLi);

            naziv = parent.odabrani.ime + parent.odabrani.prezime;


            using (var db = new PoliklinikaDbContext())
            {
                foreach(ZdravstveniKarton z in db.ZdravstveniKartoni)
                {
                    if(z.imePacijenta.Equals(parent.odabrani.ime) && z.prezimePacijenta.Equals(parent.odabrani.prezime))
                    {
                       Karton = z;
                    }

                }
                if (Karton.imePacijenta == null) naziv = "Nema kreiran karton!";

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

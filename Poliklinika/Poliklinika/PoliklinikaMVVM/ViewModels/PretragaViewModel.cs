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
    class PretragaViewModel
    {
        // private Type type;
        //private PregledViewModel pregledViewModel;
        
        public PregledViewModel Parent { get; set; }
        public Odjel Odjel { get; set; }
        public Pretraga Stavka { get; set; }//za trenutni odabir u combobox
        public ICommand Dodaj { get; set; }

        public List<Pretraga> pretrage { get; set; }

        public int pr { get; set; }
        public PretragaViewModel(PregledViewModel parent)
        {

            this.Parent = parent;
            Odjel = new Odjel();
            Odjel.naziv = parent.pomoc3;

            pretrage = new List<Pretraga>();

            //prema nazivu odjela povuci iz bazee sve pretrage

            pretrage.Add(new Pretraga("hemijski piling",123));
            pretrage.Add(new Pretraga("ciscenje lica",11));

            Dodaj = new RelayCommand<object>(dodaj, mozeLiDodati);
            //odabrana stavka sa default komponentom, combobox ce da mjenja Stavka.Komponenta
            Stavka = new Pretraga();
            Stavka = pretrage[0];

            pr = parent.prId;
        }

        public void dodaj(object parametar)
        {
            Parent.Pregled.pretrage.Add(Stavka);
            Stavka.pregledId = pr;

            using (var db = new PoliklinikaDbContext())
            {
                db.Pretrage.Add(Stavka);
                db.SaveChanges();
            }
            Parent.NavigationService.GoBack();
        }

        public bool mozeLiDodati(object parametar)
        {
            return true;
        }
    }
}


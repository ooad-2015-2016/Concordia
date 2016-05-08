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
        public PretragaViewModel(PregledViewModel parent)
        {

            this.Parent = parent;
            Odjel = new Odjel();
            Odjel.naziv = parent.pomoc3;
            Odjel.povuciPretrage();
            Dodaj = new RelayCommand<object>(dodaj, mozeLiDodati);
            //odabrana stavka sa default komponentom, combobox ce da mjenja Stavka.Komponenta
            Stavka = new Pretraga();
            Stavka = Odjel.pretrage[0];

        }

        public void dodaj(object parametar)
        {
            Parent.Pregled.pretrage.Add(Stavka);
            Parent.NavigationService.GoBack();
        }

        public bool mozeLiDodati(object parametar)
        {
            return true;
        }
    }
}


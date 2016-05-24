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
        public Pregled Pregled { get; set; }
        public ICommand ZatvoriRacun { get; set; }

        public RacunViewModel(NaplacivanjeViewModel parent)
        {

            this.Parent = parent;
            Pregled = new Pregled();//nađi u bazi pregled od tog pacijenta/zadnji koji nije plaćen
           //povuci pretrage i izračunati iznos
            ZatvoriRacun = new RelayCommand<object>(zatvori, mozeLi);
          
        }

        public void zatvori(object parametar)
        {
            //textblock upiši vrijednost koju mora platiti
            Parent.NavigationService.GoBack();
        }

        public bool mozeLi(object parametar)
        {
            return true;
        }
    }
}

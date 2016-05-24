using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Poliklinika.PoliklinikaMVVM.ViewModels
{
   public class NaplacivanjeViewModel
    {
        //public Racun Racun { get; set; }
        public INavigationService NavigationService { get; set; }
        public ICommand PregledRacuna { get; set; }
        public ICommand PlacenRacun { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }

        public NaplacivanjeViewModel()
        {
          //  Racun = new Racun();
            NavigationService = new NavigationService();
            PregledRacuna = new RelayCommand<object>(pregledRacuna, mozeLi);
            PlacenRacun = new RelayCommand<object>(placenRacun, mozeLi);

        }


        public bool mozeLi(object parametar) { return true; }
        public void pregledRacuna(object parametar)
        {

            NavigationService.Navigate(typeof(RacunView), new RacunViewModel(this));
        }

        public void placenRacun(object parametar)
        {
            //označi u bazi kao plaćeno 
            NavigationService.Navigate(typeof(BlagajnikMenu));
        }
    }
}

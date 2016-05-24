using Poliklinika.PoliklinikaMVVM.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Poliklinika.PoliklinikaMVVM.ViewModels
{
    class DnevniRasporedViewModel
    {
        public ZakazaniPregledi parent1 { get; set; }
     //   public ZakazaniPreglediBlagajnik parent2 { get; set; }
     //   public ZakazaniPreglediRecepcionista parent3 { get; set; }
        public INavigationService NavigationService { get; set; }
        public ICommand Zatvori { get; set; }


        public DnevniRasporedViewModel(ZakazaniPregledi parent)
        {

            NavigationService = new NavigationService();
            Zatvori = new RelayCommand<object>(zatvoriRaspored, mozeLi);
            this.parent1 = parent;

        }

        public DnevniRasporedViewModel()
        {
            NavigationService = new NavigationService();
            Zatvori = new RelayCommand<object>(zatvoriRaspored, mozeLi);
        }

        /* public DnevniRasporedViewModel(ZakazaniPreglediBlagajnik parent)
         {

             NavigationService = new NavigationService();
             Zatvori = new RelayCommand<object>(zatvoriRaspored, mozeLi);
             this.parent2 = parent;

         }

         public DnevniRasporedViewModel(ZakazaniPreglediRecepcionista parent)
         {

             NavigationService = new NavigationService();
             Zatvori = new RelayCommand<object>(zatvoriRaspored, mozeLi);
             this.parent3 = parent;

         }*/
        public void zatvoriRaspored(object parametar)
        {
            parent1.NavigationService.GoBack();
        }
        public bool mozeLi(object parametar)
        {
            return true;
        }
    }
}

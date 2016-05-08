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

namespace Poliklinika.PoliklinikaMVVM.ViewModels
{
    public class PregledViewModel 
    {
        public Pregled Pregled { get; set; }
        public INavigationService NavigationService { get; set; }
        public ICommand DodavanjePretrage { get; set; }
        public ICommand PregledKartona { get; set; }
        public string pomoc { get; set; }
        public string pomoc2 { get; set; }
        public string pomoc3 { get; set; }

        public PregledViewModel()
        {
            Pregled = new Pregled();
            NavigationService = new NavigationService();
            DodavanjePretrage = new RelayCommand<object>(dodavanjePretrage, mozeLi);
            PregledKartona = new RelayCommand<object>(pregledKartona, mozeLi);

        }


        public bool mozeLi(object parametar) { return true; }
        public void dodavanjePretrage(object parametar)
        {

            NavigationService.Navigate(typeof(UnosPretrageView), new PretragaViewModel(this));
        }

        public void pregledKartona(object parametar)
        {
            NavigationService.Navigate(typeof(ZdravstveniKartonView), new ZdravstveniKartonViewModel(this));
        }

    }
}

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
    class RasporedViewModel
    {
        public ICommand PregledKartona { get; set; }
        public INavigationService NavigationService { get; set; }
        public Pacijent odabrani { get; set; }
        public List<Pacijent> pacijenti { get; set; }

        public RasporedViewModel()
        {

            NavigationService = new NavigationService();
            PregledKartona = new RelayCommand<object>(pregledKartona, mozeLi);

            // pročita iz tabele pregleda koja još nije kreirana
            pacijenti = new List<Pacijent>();
            pacijenti.Add(new Pacijent("Proba1", "Proba2", DateTime.Now, "jfs"));
            pacijenti.Add(new Pacijent("Proba3", "Proba4", DateTime.Now, "jfs"));
            pacijenti.Add(new Pacijent("Niko", "Nikic", DateTime.Now, "jfs"));


        }
        public bool mozeLi(object parametar) { return true; }


        public void pregledKartona(object parametar)
        {
            NavigationService.Navigate(typeof(ZdravstveniKartonView), new ZdravstveniKartonViewModel(this));
        }
    }
}

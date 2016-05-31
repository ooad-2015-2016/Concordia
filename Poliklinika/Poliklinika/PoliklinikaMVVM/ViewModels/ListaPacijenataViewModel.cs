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
    class ListaPacijenataViewModel
    {
        public ICommand PregledKartona { get; set; }
        public INavigationService NavigationService { get; set; }
        public RegistrovaniPacijent odabrani { get; set; }
        public List<RegistrovaniPacijent> pacijenti { get; set; }

        public ListaPacijenataViewModel()
        {

            NavigationService = new NavigationService();
            PregledKartona = new RelayCommand<object>(pregledKartona, mozeLi);
            pacijenti = new List<RegistrovaniPacijent>();

            using (var db = new PoliklinikaDbContext())
            {
                foreach(RegistrovaniPacijent z in db.RegistrovaniPacijenti)
                {
                    pacijenti.Add(z);
                }
            }


        }
        public bool mozeLi(object parametar) { return true; }


        public void pregledKartona(object parametar)
        {
            NavigationService.Navigate(typeof(ZdravstveniKartonView), new ZdravstveniKartonViewModel(this));
        }
    }
}

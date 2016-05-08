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
        public Pacijent odabrani { get; set; }
        public List<Pacijent> pacijenti { get; set; }

        public ListaPacijenataViewModel()
        {

            NavigationService = new NavigationService();
            PregledKartona = new RelayCommand<object>(pregledKartona, mozeLi);
            pacijenti = new List<Pacijent>();

            using (var db = new PoliklinikaDbContext())
            {
                foreach(ZdravstveniKarton z in db.ZdravstveniKartoni)
                {
                    pacijenti.Add(new Pacijent(z.imePacijenta, z.prezimePacijenta, DateTime.Now, "randomjmbg"));
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

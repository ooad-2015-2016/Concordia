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
   public class ZakazivanjePregledaViewModel
    {
        public INavigationService NavigationService { get; set; }
        public ICommand PrikaziTermine { get; set; }
        public ICommand ZakaziPregled { get; set; }

        public List<string> stavke { get; set; }
        public string odabrani { get; set; }

        public string ime { get; set; }
        public string prezime { get; set; }

        public ZakazivanjePregledaViewModel()
        {
            NavigationService = new NavigationService();

            PrikaziTermine = new RelayCommand<object>(prikaziTermine, mozeLi);
            ZakaziPregled = new RelayCommand<object>(zakaziPregled, mozeLi);

            stavke = new List<string>();
            stavke.Add("proba");
            stavke.Add("proba2");
        }


        public bool mozeLi(object parametar) { return true; }
        public void prikaziTermine(object parametar)
        {
            //ništa
        }

        public void zakaziPregled(object parametar)
        {

            /*
             * 
            //odabrani datum parse DateTime 
            Pregled p=new Pregled();
            p.pacijentId = 0; //naći u bazi po imenu i prezimenu
            p.status = "na čekanju";
            p.termin=odabraniiiiii
            
                */
            
        }
    }
}

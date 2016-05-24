using Poliklinika.PoliklinikaMVVM.Models;
using Poliklinika.PoliklinikaMVVM.ViewModels;
using Poliklinika.PoliklinikaMVVM.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Poliklinika
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Korisnik korisnik = null;
            string pom="";
            //Dobavljanje korisnika iz parametra budući da je isti sa logina poslan kao parametar
            if (e.Parameter != null)
            {
                korisnik = (Korisnik)e.Parameter;
            }
            //Stavke menija koje će se prikazati
            
            //dobavljanje svih meni stavki za koje prijavljeni korisnik ima pravo pristupa
            if (korisnik != null && korisnik.UlogaKorisnika != null)
            {
                
                var stavke = new List<MeniStavkeViewModel>();
                var ulogeKorisnika = korisnik.UlogaKorisnika.ToList();
                foreach (var uloga in ulogeKorisnika)
                {
                    foreach (var ulogaMeniStavka in uloga.Uloga.UlogaMeniStavke)
                    {
                        if (ulogaMeniStavka.Uloga.Naziv == "Administrator") pom = "a";
                        else if (ulogaMeniStavka.Uloga.Naziv == "Blagajnik") pom = "b";
                        else if (ulogaMeniStavka.Uloga.Naziv == "Recepcionist") pom = "r";
                        else if (ulogaMeniStavka.Uloga.Naziv == "Doktor") pom = "d";

                        stavke.Add(MeniStavkeViewModel.SaMeniStavke(ulogaMeniStavka.MeniStavka));
                    }
                }
                //pridruzivanje odabranih stavki menija, listview-u koji prikazuje meni
               
            }

            
            if (pom=="a")
            {
                sadrzajPodstranice.Navigate(typeof(AdministratorMenu), null);
            }
            else if(pom=="b")
            {
                sadrzajPodstranice.Navigate(typeof(BlagajnikMenu), null);
            }
            else if (pom == "r")
            {
                sadrzajPodstranice.Navigate(typeof(RecepcionistMenu), null);
            }
            else if (pom == "d")
            {
                sadrzajPodstranice.Navigate(typeof(DoktorMenu), null);
            }
        }
        //show-hide funkcionalnost menija
       
        //Metoda koja na osnovu odabranog menija, poziva podstranicu koja je definisana u meniju
       
    }
}

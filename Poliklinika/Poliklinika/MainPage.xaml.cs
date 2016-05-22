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
            //Dobavljanje korisnika iz parametra budući da je isti sa logina poslan kao parametar
            if (e.Parameter != null)
            {
                korisnik = (Korisnik)e.Parameter;
            }
            //Stavke menija koje će se prikazati
            //dobavljanje svih meni stavki za koje prijavljeni korisnik ima pravo pristupa
            if (korisnik != null && korisnik.UlogaKorisnika != null)
            {
                this.Frame.Navigate(typeof(AdministratorMenu));

            }
        }
        //show-hide funkcionalnost menija
       
    }
}

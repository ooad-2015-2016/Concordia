using Poliklinika.PoliklinikaBAZA.Models;
using Poliklinika.PoliklinikaMVVM.DataSource;
using Poliklinika.PoliklinikaMVVM.Models;
using Poliklinika.PoliklinikaMVVM.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Poliklinika
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
            var inicijalizacija = new DataSourceMenuMD();
        }
        //asinhrona metoda za provjeru prijave korisnika
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            /*var korisnickoIme = txtUsername.Text;
            var sifra = txtPassword.Password;
            var korisnik = DataSourceMenuMD.ProvjeraKorisnika(korisnickoIme, sifra);
            if (korisnik != null && korisnik.KorisnikId > 0)
            {
                this.Frame.Navigate(typeof(MainPage), korisnik);
            }
            else
            {
                var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");

                await dialog.ShowAsync();
            }*/
            string pom = "n";

            using (var db = new PoliklinikaDbContext())
            {
                foreach(Doktor d in db.Doktori)
                {
                    if(d.Username.Equals(txtUsername.Text) && d.Password.Equals(txtPassword.Password))
                    {
                        pom = "d";
                    }
                }

                bool pronadjen = false;
                foreach (OstaloOsoblje o in db.Zaposlenici)
                {
                    if(o.Username.Equals(txtUsername.Text)) pronadjen = true;

                    if (o.Username.Equals(txtUsername.Text) && o.Password.Equals(txtPassword.Password))
                    {
                        
                        if (o.tip.Equals("administrator")) pom = "a";
                        else if (o.tip.Equals("blagajnik")) pom = "b";
                        else if (o.tip.Equals("recepcionist")) pom = "r";

                    }
                  
                }

                if (pronadjen == true && pom=="n")
                {
                    var dialog = new MessageDialog("Pogrešna šifra!", "Neuspješna prijava");

                    await dialog.ShowAsync();
                }
                else if(pronadjen==false && pom=="n")
                {
                    var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");

                    await dialog.ShowAsync();
                }


            }

            if (pom == "a")
            {
                Frame.Navigate(typeof(AdministratorMenu), null);
            }
            else if (pom == "b")
            {
                Frame.Navigate(typeof(BlagajnikMenu), null);
            }
            else if (pom == "r")
            {
                Frame.Navigate(typeof(RecepcionistMenu), null);
            }
            else if (pom == "d")
            {
                Frame.Navigate(typeof(DoktorMenu), null);
            }
        }
    }
    
    }

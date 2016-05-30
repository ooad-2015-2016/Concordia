using Poliklinika.PoliklinikaBAZA.Models;
using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Poliklinika.PoliklinikaMVVM.Views
{
    public sealed partial class RegistracijaNovogZaposlenika : Page
    {
        public INavigationService NavigationService { get; set; }

        public RegistracijaNovogZaposlenika()
        {
            this.InitializeComponent();
        }

       

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //var currentView = SystemNavigationManager.GetForCurrentView();
            //currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed

            NavigationService = new NavigationService();
            NavigationService.Navigate(typeof(AdministratorMenu));

            var currentView2 = SystemNavigationManager.GetForCurrentView();
            currentView2.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

           currentView2.BackRequested += backButton_Tapped;
        }

      private void backButton_Tapped(object sender, BackRequestedEventArgs e)
        {
            Frame.Navigate(typeof(AdministratorMenu));
        }

        

        private async void dodavanjeZaposlenika(object sender, RoutedEventArgs e)
        {

            string odabrano = odjelCBZ.SelectedValue.ToString();

            if(odabrano.Equals("blagajnik") || odabrano.Equals("recepcionist") || odabrano.Equals("administrator"))
            {
                OstaloOsoblje zap = new OstaloOsoblje();
                zap.Ime = imeTBZ.Text;
                zap.Prezime = prezimeTBZ.Text;
                zap.Plata = float.Parse(plataTBZ.Text);
                zap.DatumRodjenja = datumRodjenjaPickerZ.Date.Date;
                zap.DatumZaposlenja = datumRegistracijePickerZ.Date.Date;
                zap.Username = usernameTBZ.Text;
                zap.tip = odabrano;

                using (var db = new PoliklinikaDbContext())
                {
                    db.Zaposlenici.Add(zap);
                    db.SaveChanges();
                }

                var dlg = new MessageDialog("Uspješno registrovan doktor!" + "\n" + "Username: " + odabrano + "\n" + "Password: " + zap.Password
              );
                dlg.Commands.Add(new UICommand("Ok", null, "OK"));
                var op = await dlg.ShowAsync();

            }

            else
            {
                Doktor zap = new Doktor();
                zap.Ime = imeTBZ.Text;
                zap.Prezime = prezimeTBZ.Text;
                zap.Plata = float.Parse(plataTBZ.Text);
                zap.Username = usernameTBZ.Text;

                int id;

                using (var db = new PoliklinikaDbContext())
                {
                    var binky = db.Odjeli.Where(u => u.naziv == odabrano).FirstOrDefault();
                    id = binky.OdjelId;
                }

            
                zap.odjelId = id;

                using (var db = new PoliklinikaDbContext())
                {
                    db.Doktori.Add(zap);
                    db.SaveChanges();
                }

                var dlg = new MessageDialog("Uspješno registrovan doktor!" + "\n" + "Username: " + odabrano + "\n" + "Password: " + zap.Password
               );
                dlg.Commands.Add(new UICommand("Ok", null, "OK"));
                var op = await dlg.ShowAsync();
            }

            

            


           
            /*
            using (var db = new PoliklinikaDbContext())
            {
                db.Zaposlenici.Add(zap);
                db.SaveChanges();
            }*/


        }
    }
}

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

            Osoblje zap = new Osoblje();
            zap.Ime = imeTBZ.Text;
            zap.Prezime = prezimeTBZ.Text;
            zap.Plata = float.Parse(plataTBZ.Text);
            zap.Username = usernameTBZ.Text;
            var dlg = new MessageDialog("Uspješno registrovan zaposlenik!" + "\n" + "Username: " + zap.Username + "\n" + "Password: " + zap.Password
               );

            dlg.Commands.Add(new UICommand("Ok", null, "OK"));
            var op = await dlg.ShowAsync();
            /*
            using (var db = new PoliklinikaDbContext())
            {
                db.Zaposlenici.Add(zap);
                db.SaveChanges();
            }*/


        }
    }
}

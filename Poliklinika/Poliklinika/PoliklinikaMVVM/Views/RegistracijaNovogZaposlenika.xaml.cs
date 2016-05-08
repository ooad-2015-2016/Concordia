using Poliklinika.PoliklinikaBAZA.Models;
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
        public RegistracijaNovogZaposlenika()
        {
            this.InitializeComponent();
          

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private async void dodavanjeZaposlenika(object sender, RoutedEventArgs e)
        {
            Osoblje zap = new Osoblje();
            zap.Ime = textBox.Text;
            zap.Prezime = textBox1.Text;
            zap.Plata = double.Parse(textBox4.Text);
            zap.Username = textBox5.Text;
            var dlg = new MessageDialog("Uspješno registrovan zaposlenik!" + "\n" + "Username: " + zap.Username + "\n" + "Password: " + zap.Password
               );

            dlg.Commands.Add(new UICommand("Ok", null, "OK"));
            var op = await dlg.ShowAsync();


            using (var db = new PoliklinikaDbContext())
            {
                db.Zaposlenici.Add(zap);
                db.SaveChanges();
            }


        }
    }
}

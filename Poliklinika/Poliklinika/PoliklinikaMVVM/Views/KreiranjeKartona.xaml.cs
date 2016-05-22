using Poliklinika.PoliklinikaBAZA.Models;
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

namespace Poliklinika.PoliklinikaMVVM.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KreiranjeKartona : Page
    {
        public KreiranjeKartona()
        {
            this.InitializeComponent();
        }

        private async void kreirajClick(object sender, RoutedEventArgs e)
        {
            ZdravstveniKarton zk = new ZdravstveniKarton();
            zk.imePacijenta = imeTB.Text;
            zk.prezimePacijenta = prezimeTB.Text;
            zk.KrvnaGrupa = krvnaGrupaCB.SelectionBoxItem.ToString();

            using (var db = new PoliklinikaDbContext())
            {
               db.ZdravstveniKartoni.Add(zk);
               db.SaveChanges();
            }

            //za brisanje kartona
          /*  var tk = db.ZdravstveniKartoni.First(c => c.ZdravstveniKartonId == 3);
            db.Remove(tk);
            db.SaveChanges();*/


            var dlg = new MessageDialog("Kreiran karton!");
            dlg.Commands.Add(new UICommand("Ok", null, "OK"));
            var op = await dlg.ShowAsync();
            if ((string)op.Id == "OK")
            {
                //nesto
            }
        }
    }
}


using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.ViewModels;
using Poliklinika.PoliklinikaMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Poliklinika
{
    public sealed partial class ZakazaniPregledi : Page
    {
        public INavigationService NavigationService { get; set; }
        public ZakazaniPregledi()
        {
            this.InitializeComponent();
            DataContext = new DnevniRasporedViewModel();

            // NavigationService = new NavigationService();
            //NavigationService.Navigate(typeof(DnevniRaspored), new DnevniRasporedViewModel(this));
        }
    }
}

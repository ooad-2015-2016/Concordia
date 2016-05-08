using Poliklinika.PoliklinikaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Poliklinika.PoliklinikaMVVM.Views
{
    public sealed partial class DnevniRaspored : Page
    {
        public DnevniRaspored()
        {
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = (DnevniRasporedViewModel)e.Parameter;
        }


        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }


    }
}

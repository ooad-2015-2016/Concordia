using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.Models;
using Poliklinika.PoliklinikaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class PregledView : Page
    {
        public INavigationService NavigationService { get; set; }
        public PregledView()
        {
            this.InitializeComponent();
            DataContext = new PregledViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;

        }
        /* protected override void OnNavigatedTo(NavigationEventArgs e)
         {
             var currentView = SystemNavigationManager.GetForCurrentView(); //bilo Collapsed
             currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
         }*/

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigationService = new NavigationService();
            NavigationService.Navigate(typeof(DoktorMenu));

            var currentView2 = SystemNavigationManager.GetForCurrentView();
            currentView2.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

        }

        private async void zavrsenPregledButton(object sender, RoutedEventArgs e)
        {

            
            var dlg = new MessageDialog("Podaci o pregledu su uneseni u bazu!");
            dlg.Commands.Add(new UICommand("Ok", null, "OK"));
            var op = await dlg.ShowAsync();

            imeTB.Text = String.Empty;
            prezimeTB.Text = String.Empty;
            odjelTB.Text = String.Empty;
            PretrageListView.ItemsSource = null;
            PretrageListView.Items.Clear();
            Frame.Navigate(typeof(DoktorMenu));
        }

    }
}


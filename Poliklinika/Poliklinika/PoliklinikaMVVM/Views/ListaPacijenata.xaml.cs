using Poliklinika.PoliklinikaMVVM.Helper;
using Poliklinika.PoliklinikaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class ListaPacijenata : Page
    {
        public INavigationService NavigationService { get; set; }
        public ListaPacijenata()
        {
            this.InitializeComponent();
            DataContext = new ListaPacijenataViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //var currentView = SystemNavigationManager.GetForCurrentView();
            //currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed

            NavigationService = new NavigationService();
            NavigationService.Navigate(typeof(RecepcionistMenu));

            var currentView2 = SystemNavigationManager.GetForCurrentView();
            currentView2.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            currentView2.BackRequested += backButton_Tapped;
        }

        private void backButton_Tapped(object sender, BackRequestedEventArgs e)
        {
            Frame.Navigate(typeof(RecepcionistMenu));
        }


        /*protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }*/
    }
}

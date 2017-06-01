using EstimoteBeacons.Interfaces;
using EstimoteBeacons.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EstimoteBeacons.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        // We maken gebruik van NavigationService, PageDialogService en onze eigen RestService
        // met Dependency Injection via de constructor
        private INavigationService navigationService;
        private IPageDialogService dialogService;
        private IRestService restService;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IRestService restService)
        {
            Routes = new ObservableCollection<Route>();

            //Methode LoadAndDisplayRoutes wordt uitgevoerd wanneer er op de refresh-knop gedrukt wordt
            RefreshCommand = new DelegateCommand(async () => await LoadAndDisplayRoutes());

            //Methode LoadAboutPage wordt uitgevoerd wanneer we op de "over"-knop drukken in het submenu
            AboutCommand = new DelegateCommand(() => LoadAboutPage());
          
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.restService = restService;
        }

        // Commands voor knoppen
        public ICommand RefreshCommand { get; private set; }
        public ICommand AboutCommand { get; private set; }

        // Binding Properties
        private ObservableCollection<Route> routes;
        public ObservableCollection<Route> Routes
        {
            get { return routes; }
            set { SetProperty(ref routes, value); }
        }

        private Route selectedRoute;
        public Route SelectedRoute
        {
            get { return selectedRoute; }
            set
            {
                if (SetProperty(ref selectedRoute, value) && selectedRoute != null)
                {
                    // Wanneer er een route geselecteerd wordt navigeren we naar de RouteInfoPage 
                    // en geven we deze route mee met de navigatie parameters
                    var navParams = new NavigationParameters();
                    navParams.Add("selectedRoute", selectedRoute);
                    Navigate("RouteInfoPage", navParams);
                    SelectedRoute = null;
                }
            }
        }
        // --------

        private async void Navigate(string page, NavigationParameters navParams)
        {
            await navigationService.NavigateAsync(page, navParams);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            // Routes inladen en tonen wanneer er naar deze pagina genavigeerd wordt
            await LoadAndDisplayRoutes();
        }

        private async void LoadAboutPage()
        {
            // Methode om naar de "over"-pagina te navigeren
            await navigationService.NavigateAsync("AboutPage");
        }

        private async Task LoadAndDisplayRoutes()
        {
            try
            {
                // Routes ophalen via de restService
                ObservableCollection<Route> routes = await restService.GetRoutesAsync();

                if (routes != Routes)
                {
                    // Als de routes die ingeladen werden verschillend zijn van degenen die weergegeven worden refreshen we het lijstje, anders niet.
                    Routes.Clear();
                    foreach (Route r in routes)
                    {
                        Routes.Add(r);
                    }
                }
            }
            // Errors weergeven wanneer er geen internetverbinding is of wanneer er iets anders mis loopt.
            catch (HttpRequestException)
            {
                await dialogService.DisplayAlertAsync("Geen internetverbinding.", "Sluit de app volledig af en zorg voor een werkende internetverbinding.", "OK");
            }
            catch (WebException)
            {
                await dialogService.DisplayAlertAsync("Geen internetverbinding.", "Sluit de app volledig af en zorg voor een werkende internetverbinding.", "OK");
            }
            catch (Exception e)
            {
                await dialogService.DisplayAlertAsync("Error", e.Message, "OK");
            }
        }
    }
}

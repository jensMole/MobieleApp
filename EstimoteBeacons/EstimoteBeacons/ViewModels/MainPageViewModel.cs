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
        private INavigationService navigationService;
        private IPageDialogService dialogService;
        private IRestService restService;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IRestService restService)
        {
            Routes = new ObservableCollection<Route>();

            //Methode LoadAndDisplayRoutes wordt uitgevoerd wanneer er op de refresh-knop gedrukt wordt
            RefreshCommand = new DelegateCommand(async () => await LoadAndDisplayRoutes());

            AboutCommand = new DelegateCommand(() => LoadAboutPage());
          
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.restService = restService;
        }

        public ICommand RefreshCommand { get; private set; }
        public ICommand AboutCommand { get; private set; }
        public ICommand AboutButton { get; private set; }
        public ObservableCollection<Route> Routes { get; private set; }

        private Route selectedRoute;
        public Route SelectedRoute
        {
            // vervangen door event ItemSelected & checken of SelectedItem = null 
            //(itemselected wordt 2x uitgevoerd: bij indrukken en bij loslaten
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
            await LoadAndDisplayRoutes();
        }

        private async void LoadAboutPage()
        {
            await navigationService.NavigateAsync("AboutPage");
        }

        private async Task LoadAndDisplayRoutes()
        {
            try
            {
                // Routes ophalen via de restService
                ObservableCollection<Route> routes = await restService.GetRoutesAsync();

                //if (routes != Routes)
                //{
                    // Als de routes die ingeladen werden verschillend zijn van degenen die weergegeven worden refreshen we het lijstje, anders niet.
                    Routes.Clear();
                    foreach (Route r in routes)
                    {
                        Routes.Add(r);
                    }
                //}
            }
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

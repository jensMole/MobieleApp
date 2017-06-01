using EstimoteBeacons.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Windows.Input;

namespace EstimoteBeacons.ViewModels
{
    public class RouteInfoPageViewModel : BindableBase, INavigationAware
    {
        // Variabele om de huidige route bij te houden
        private Route currentRoute;

        // We maken gebruik van NavigationService en PageDialogService
        // met Dependency Injection via de constructor
        private IPageDialogService dialogService;
        private INavigationService navigationService;
        
        public RouteInfoPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;

            // Als er op de start knop gedrukt wordt wordt de methode StartRoute() uitgevoerd
            StartCommand = new DelegateCommand(()=>StartRoute());
        }
        
        // Command voor start-knop
        public ICommand StartCommand { get; private set; }

        // Binding Properties
        private string route_info;
        public string Route_Info
        {
            get { return route_info; }
            set { SetProperty(ref route_info, value); }
        }

        private int route_id;
        public int Route_Id
        {
            get { return route_id; }
            set { SetProperty(ref route_id, value); }
        }               
        // -------

        private async void StartRoute()
        {
            // Als de route gestart wordt geven we de huidige route mee met de navigatieparameters
            // en navigeren we naar de BeaconsPage waar er naar de beacons gezocht zal worden.
            NavigationParameters navParams = new NavigationParameters();
            navParams.Add("selectedRoute", currentRoute);
            await navigationService.NavigateAsync("BeaconsPage", navParams);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
               
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            try
            {
                // Geselecteerde route uit de navigatie parameters ophalen
                if (parameters.ContainsKey("selectedRoute")) currentRoute = (Route)parameters["selectedRoute"];

                if (currentRoute != null)
                {
                    // Info over deze route weergeven
                    Route_Id = currentRoute.Route_Id;
                    Route_Info = currentRoute.Name_Ln;
                }
            }
            // Error weergeven indien er iets mis loopt
            catch (Exception e)
            {
                await dialogService.DisplayAlertAsync("Error", e.Message, "OK");
            }
        }
        
    }
}

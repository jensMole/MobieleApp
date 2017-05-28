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
        private IPageDialogService dialogService;
        private INavigationService navigationService;
        private Route currentRoute;
        public RouteInfoPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            StartCommand = new DelegateCommand(()=>StartRoute());
        }
        
        public ICommand StartCommand { get; private set; }

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

        private async void StartRoute()
        {
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
                if (parameters.ContainsKey("selectedRoute"))
                {
                    currentRoute = (Route)parameters["selectedRoute"];
                }

                if (currentRoute != null)
                {
                    // Info over deze route weergeven
                    Route_Id = currentRoute.Route_Id;
                    Route_Info = currentRoute.Name_Ln;
                }
            }
            catch (Exception e)
            {
                await dialogService.DisplayAlertAsync("Error", e.Message, "OK");
            }
        }
        
    }
}

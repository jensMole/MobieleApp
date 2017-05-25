using Android.Bluetooth;
using EstimoteBeacons.Interfaces;
using EstimoteBeacons.Models;
using Estimotes;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EstimoteBeacons.ViewModels
{
    public class BeaconsPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService navigationService;
        private IPageDialogService dialogService;
        private IRestService restService;
        private Route currentRoute = null;
        private ObservableCollection<Beacon> beaconsInCurrentRoute = null;

        public BeaconsPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IRestService restService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.restService = restService;
            NextBeaconCommand = new DelegateCommand(() => NextBeacon());
        }

        private void NextBeacon()
        {
            Beacons = "";
            if (App.currentSequenceNumber < beaconsInCurrentRoute.Count - 1)
            {
                App.currentSequenceNumber++;
                Beacons = "Looking for beacon: " + beaconsInCurrentRoute[App.currentSequenceNumber].Beacon_Id;
            }
            else
            {
                Beacons = "last beacon reached";
            }
            
        }

        public ICommand NextBeaconCommand { get; private set; }

        private string beacons;
        public string Beacons
        {
            get { return beacons; }
            set { SetProperty(ref beacons, value); }
        }

        private bool loading;
        public bool Loading
        {
            get { return loading; }
            set { SetProperty(ref loading, value); }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            EstimoteManager.Instance.Ranged -= OnRanged;
            EstimoteManager.Instance.StopAllRanging();
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            try
            {
                // Geselecteerde route ophalen uit navigatieparameters
                if (parameters.ContainsKey("selectedRoute"))
                {
                    currentRoute = (Route)parameters["selectedRoute"];
                }

                if (currentRoute != null)
                {
                    // Beacons die bij de geselecteerde route horen ophalen via de restService
                    beaconsInCurrentRoute = await restService.GetBeaconsInRouteAsync(currentRoute.Route_Id);
                }

                // Android permissions check
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await dialogService.DisplayAlertAsync("Need location", "This app needs location services", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
                    status = results[Permission.Location];
                }
                
                // Checken of de gebruiker toestemming heeft gegeven
                if (status == PermissionStatus.Granted)
                {
                    var status2 = await EstimoteManager.Instance.Initialize();
                    
                    // Checken of bluetooth aan staat (android)
                    if (BluetoothAdapter.DefaultAdapter.IsEnabled)
                    {
                        if (status2 != BeaconInitStatus.Success)
                        {
                            return;
                        }
                        Beacons = "";
                        Beacons = "Looking for beacon: " + beaconsInCurrentRoute[App.currentSequenceNumber].Beacon_Id;
                        // Als bluetooth aan staat beginnen we met scannen naar beacons
                        EstimoteManager.Instance.Ranged += OnRanged;
                        EstimoteManager.Instance.StartRanging(new BeaconRegion("estimote", "B9407F30-F5F8-466E-AFF9-25556B57FE6D"));
                    }else
                    {
                        // Als bluetooth uit staat krijgt de gebruiker hier een melding van en wordt er terug genavigeerd
                        await dialogService.DisplayAlertAsync("Geen Bluetooth", "Bluetooth moet ingeschakeld zijn om een route te starten.", "OK");
                        await navigationService.GoBackAsync();
                    }
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await dialogService.DisplayAlertAsync("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                Beacons = "Error: " + ex;
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            App.currentSequenceNumber = 0;
            Loading = true;    
        }

        private void OnRanged(object sender, IEnumerable<IBeacon> foundBeacons)
        {
            foreach (var foundBeacon in foundBeacons)
            {
                if (beaconsInCurrentRoute[App.currentSequenceNumber].Beacon_Id == foundBeacon.Major)
                {
                    var navParams = new NavigationParameters();
                    navParams.Add("route_id", currentRoute.Route_Id);
                    navParams.Add("beacon_id", beaconsInCurrentRoute[App.currentSequenceNumber].Beacon_Id);
                    navParams.Add("max_beacons", (beaconsInCurrentRoute.Count - 1));
                    navigationService.NavigateAsync("BeaconContentPage", navParams);
                }
            }
        }
    }
}
using EstimoteBeacons.Interfaces;
using EstimoteBeacons.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace EstimoteBeacons.ViewModels
{
    public class BeaconContentPageViewModel : BindableBase, INavigationAware
    {
        private int max_beacons = 0;
        private IRestService _restService;
        public BeaconContentPageViewModel(IRestService restService)
        {
            _restService = restService;
        }

        private string sourceUrl;
        public string SourceUrl
        {
            get { return sourceUrl; }
            set { SetProperty(ref sourceUrl, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            if (App.currentSequenceNumber < max_beacons)
            {
                App.currentSequenceNumber++;
            }
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            int route_id = -1;
            int beacon_id = -1;
            if (parameters.ContainsKey("route_id")) route_id = (int)parameters["route_id"];
            if (parameters.ContainsKey("beacon_id")) beacon_id = (int)parameters["beacon_id"];
            if (parameters.ContainsKey("max_beacons")) max_beacons = (int)parameters["max_beacons"];

            ObservableCollection<Content> content = await _restService.GetContentForBeaconInRoute(route_id, beacon_id);
            
            SourceUrl = content[0].Content_Txt;
        }
    }
}

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
        private int route_id = -1;
        private int beacon_id = -1;
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

        private bool webViewVisible;
        public bool WebViewVisible
        {
            get { return webViewVisible; }
            set { SetProperty(ref webViewVisible, value); }
        }

        private bool imageVisible;
        public bool ImageVisible
        {
            get { return imageVisible; }
            set { SetProperty(ref imageVisible, value); }
        }

        private string imageSource;
        public string ImageSource
        {
            get { return imageSource; }
            set { SetProperty(ref imageSource, value); }
        }

        private string htmlSource;
        public string HTMLSource
        {
            get { return htmlSource; }
            set { SetProperty(ref htmlSource, value); }
        }

        private bool htmlWebViewVisible;
        public bool HTMLWebViewVisible
        {
            get { return htmlWebViewVisible; }
            set { SetProperty(ref htmlWebViewVisible, value); }
        }
        
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            if (App.currentSequenceNumber < max_beacons)
            {
                App.currentSequenceNumber++;
            }
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            ObservableCollection<Content> contentCollection = await _restService.GetContentForBeaconInRoute(route_id, beacon_id);
            Content content = contentCollection[0];

            if (content.Metatype_Sn == "link" || content.Metatype_Sn == "audio" || content.Metatype_Sn == "video")
            {
                WebViewVisible = true;
                SourceUrl = content.Content_Txt;
            }
            else if (content.Metatype_Sn == "image")
            {
                ImageVisible = true;
                ImageSource = content.Content_Txt;
            }
            else if (content.Metatype_Sn == "html")
            {
                HTMLWebViewVisible = true;
                HTMLSource = content.Content_Txt;
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            WebViewVisible = false;
            ImageVisible = false;
            HTMLWebViewVisible = false;

            if (parameters.ContainsKey("route_id")) route_id = (int)parameters["route_id"];
            if (parameters.ContainsKey("beacon_id")) beacon_id = (int)parameters["beacon_id"];
            if (parameters.ContainsKey("max_beacons")) max_beacons = (int)parameters["max_beacons"];
        }
    }
}

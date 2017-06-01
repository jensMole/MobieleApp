using EstimoteBeacons.Interfaces;
using EstimoteBeacons.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EstimoteBeacons.Data
{
    // Rest service om data op te halen uit de iBeacons API
    public class RestService : IRestService
    {
        // De API url waarvan we voor elke request vertrekken
        private static string restBaseUrl = "http://api.beacons.ucll.be/v1";
        private HttpClient client;

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<ObservableCollection<Beacon>> GetBeaconsInRouteAsync(int route_id)
        {
            // Url opbouwen voor request beacons in route
            // Voorbeeld request: http://api.beacons.ucll.be/v1/route/1/beacon
            var uri = new Uri(restBaseUrl + "/route/" + route_id + "/beacon");

            // Variabele waar we het resultaat van deze request in gaan zetten
            ObservableCollection<Beacon> beaconsInRoute = null;

            // Request uitvoeren via de HttpClient
            var response = await client.GetAsync(uri);

            // Als de request gelukt is
            if (response.IsSuccessStatusCode)
            {
                // Response uitlezen als string
                var content = await response.Content.ReadAsStringAsync();
                
                // Json die we ontvangen hebben omzetten naar een ObservableCollection van Models.Beacon
                beaconsInRoute = JsonConvert.DeserializeObject<ObservableCollection<Beacon>>(content);
            }
            return beaconsInRoute;
        }

        public async Task<ObservableCollection<Route>> GetRoutesAsync()
        {
            // Url opbouwen voor request van routes
            // Voorbeeld request: http://api.beacons.ucll.be/v1/route
            var uri = new Uri(restBaseUrl + "/route");

            // Variabele waar we het resultaat van deze request in gaan zetten
            ObservableCollection<Route> routes = null;

            // Request uitvoeren via de HttpClient
            var response = await client.GetAsync(uri);

            // Als de request gelukt is
            if (response.IsSuccessStatusCode)
            {
                // Response uitlezen als string
                var content = await response.Content.ReadAsStringAsync();

                // Json die we ontvangen hebben omzetten naar een ObservableCollection van Models.Route
                routes = JsonConvert.DeserializeObject<ObservableCollection<Route>>(content);
            }
            return routes;
        }


        public async Task<ObservableCollection<Content>> GetContentForBeaconInRoute(int route_id, int beacon_id)
        {
            // Url opbouwen voor request van content voor een beacon in een route
            // Voorbeeld request: http://api.beacons.ucll.be/v1/beacon/4/route/1/dynamicData
            var uri = new Uri(restBaseUrl + "/beacon/" + beacon_id.ToString() + "/route/" + route_id.ToString() + "/dynamicData");

            // Variabele waar we het resultaat van deze request in gaan zetten
            ObservableCollection<Content> content = null;

            // Request uitvoeren via de HttpClient
            var response = await client.GetAsync(uri);

            // Als de request gelukt is
            if (response.IsSuccessStatusCode)
            {
                // Response uitlezen als string
                var responseContent = await response.Content.ReadAsStringAsync();

                // Json die we ontvangen hebben omzetten naar een ObservableCollection van Models.Content
                content = JsonConvert.DeserializeObject<ObservableCollection<Content>>(responseContent);
            }
            return content;
        }
    }
}

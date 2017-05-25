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
    public class RestService : IRestService
    {
        private static string restBaseUrl = "http://api.beacons.ucll.be/v1";
        private HttpClient client;
        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<ObservableCollection<Beacon>> GetBeaconsInRouteAsync(int route_id)
        {
            var uri = new Uri(restBaseUrl + "/route/" + route_id + "/beacon");
            ObservableCollection<Beacon> beaconsInRoute = null;
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                beaconsInRoute = JsonConvert.DeserializeObject<ObservableCollection<Beacon>>(content);
            }
            return beaconsInRoute;
        }

        public async Task<ObservableCollection<Route>> GetRoutesAsync()
        {
            var uri = new Uri(restBaseUrl + "/route");
            ObservableCollection<Route> routes = null;
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                routes = JsonConvert.DeserializeObject<ObservableCollection<Route>>(content);
            }
            return routes;
        }


        public async Task<ObservableCollection<Content>> GetContentForBeaconInRoute(int route_id, int beacon_id)
        {
            // Voorbeeld request: http://api.beacons.ucll.be/v1/beacon/4/route/1/dynamicData
            var uri = new Uri(restBaseUrl + "/beacon/" + beacon_id.ToString() + "/route/" + route_id.ToString() + "/dynamicData");
            ObservableCollection<Content> content = null;
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<Content>>(responseContent);
            }
            return content;
        }
    }
}

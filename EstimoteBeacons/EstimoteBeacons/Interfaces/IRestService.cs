using EstimoteBeacons.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimoteBeacons.Interfaces
{
    public interface IRestService
    {
        Task<ObservableCollection<Route>> GetRoutesAsync();
        Task<ObservableCollection<Beacon>> GetBeaconsInRouteAsync(int route_id);
        Task<ObservableCollection<Content>> GetContentForBeaconInRoute(int route_id, int beacon_id);
    }
}

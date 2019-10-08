using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Data;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class LocationsDataProvider : ILocationsDataProvider
    {
        public LocationsDataProvider()
        {
        }

        public IEnumerable<LocationData> GetLocationsList(string prefix)
        {
            throw new NotImplementedException();
        }
    }
}

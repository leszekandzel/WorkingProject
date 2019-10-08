using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Data;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class GoogleLocationsDataProvider : ILocationsDataProvider
    {
        private readonly ILocationsQueryProvider googleLocationsQueryProvider;
        public GoogleLocationsDataProvider(ILocationsQueryProvider googleLocationsQueryProvider)
        {
            this.googleLocationsQueryProvider = googleLocationsQueryProvider;
        }

        public IEnumerable<LocationData> GetLocationsList(string prefix)
        {
            var queryString = this.googleLocationsQueryProvider.GetLocationsQuery(prefix);
            return null;
        }
    }
}

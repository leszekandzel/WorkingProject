using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsRouteLocator.Data
{
    public class RouteCalculationRequestData
    {
        public LocationData RouteFrom { get; set; }
        public LocationData RouteTo { get; set; }
        public IEnumerable<LocationData> ViaStops { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Data;

namespace MapsRouteLocator.Interfaces
{
    /// <summary>
    /// Simple interface to fetch the routes from data source (google maps)
    /// </summary>
    public interface IRoutesQueryProvider
    {
        string GetRoutesQuery(RouteCalculationRequestData routeCalculationRequestData);
    }
}

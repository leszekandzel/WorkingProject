using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Data;

namespace MapsRouteLocator.Interfaces
{
    public interface ILocationsDataProvider
    {
        IEnumerable<LocationData> GetLocationsList(string prefix);
    }
}

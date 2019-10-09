using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Data;

namespace MapsRouteLocator.Interfaces
{
    /// <summary>
    /// Interface calling a data source (google) to receive list of locations with given prefix
    /// </summary>
    public interface ILocationsDataProvider
    {
         Task<IEnumerable<LocationData>> GetLocationsListAsync(string prefix);
    }
}

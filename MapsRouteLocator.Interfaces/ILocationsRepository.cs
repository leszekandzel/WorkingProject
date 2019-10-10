using System.Collections.Generic;

namespace MapsRouteLocator.Interfaces
{
    public interface ILocationsRepository
    {
        SortedSet<string> GetLocations();
        bool MemorizeLocations(string [] locations);
    }
}
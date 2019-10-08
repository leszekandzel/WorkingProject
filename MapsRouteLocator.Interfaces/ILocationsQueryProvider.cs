namespace MapsRouteLocator.Interfaces
{
    public interface ILocationsQueryProvider
    {
        string GetLocationsQuery(string prefix);
    }
}
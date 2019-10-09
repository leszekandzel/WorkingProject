namespace MapsRouteLocator.Interfaces
{
    /// <summary>
    /// Simple interface to build a query in order to fetch locations list
    /// </summary>
    public interface ILocationsQueryProvider
    {
        string GetLocationsQuery(string prefix);
    }
}
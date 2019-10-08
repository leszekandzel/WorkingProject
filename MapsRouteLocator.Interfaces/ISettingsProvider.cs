using MapsRouteLocator.Data;

namespace MapsRouteLocator.Interfaces
{
    public interface ISettingsProvider
    {
        Settings Settings { get; }

        void UpdateGeoLocation(string latitude, string longitude);
    }
}
using MapsRouteLocator.Data;

namespace MapsRouteLocator.Interfaces
{
    /// <summary>
    /// Interface to populate app settings. Initially I had also an idea to determine the current location of workstation and pass it to the map during initial startup, but I have not implemented it.
    /// </summary>
    public interface ISettingsProvider
    {
        Settings Settings { get; }
    }
}
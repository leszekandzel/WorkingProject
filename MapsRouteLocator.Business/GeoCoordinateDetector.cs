using System;
using System.Device.Location;

namespace MapsRouteLocator.Business
{
    public class GeoCoordinateDetector
    {
        public void GetCoordinates()
        {
            var geoCoordinateWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            geoCoordinateWatcher.MovementThreshold = 1.0;
            geoCoordinateWatcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

            CivicAddressResolver resolver = new CivicAddressResolver();

            if (geoCoordinateWatcher.Position.Location.IsUnknown == false)
            {
                CivicAddress address = resolver.ResolveAddress(geoCoordinateWatcher.Position.Location);

                if (!address.IsUnknown)
                {
                    Console.WriteLine("Country: {0}, Zip: {1}",
                        address.CountryRegion,
                        address.PostalCode);
                }
                else
                {
                    Console.WriteLine("Address unknown.");
                }
            }

        }
    }
}
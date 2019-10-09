using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsRouteLocator.Data
{
    public class LocationData
    {
        public string Name { get; set; }

        // This field is currently not used. The initial idea was to fetch from google not only the name, but also latitude and longitude and bind it to the auto-populating dropdown
        public string Latitude { get; set; }

        // This field is currently not used. The initial idea was to fetch from google not only the name, but also latitude and longitude and bind it to the auto-populating dropdown
        public string Longitude { get; set; }
    }
}

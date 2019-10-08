using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class GoogleLocationsQueryProvider : ILocationsQueryProvider
    {
        private ISettingsProvider settingsProvider;

        public GoogleLocationsQueryProvider(ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
        }

        public string GetLocationsQuery(string prefix)
        {
            var locationsQuery = string.Format(settingsProvider.Settings.LocationsQueryString, prefix,
                settingsProvider.Settings.LanguageCode, settingsProvider.Settings.GoogleKey);

            return locationsQuery;
        }
    }
}

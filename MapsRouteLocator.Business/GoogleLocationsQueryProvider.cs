using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Interfaces;
using System.Web;

namespace MapsRouteLocator.Business
{
    public class GoogleLocationsQueryProvider : ILocationsQueryProvider
    {
        private readonly ISettingsProvider settingsProvider;

        public GoogleLocationsQueryProvider(ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
        }

        public string GetLocationsQuery(string prefix)
        {
            var locationsQuery = string.Format(settingsProvider.Settings.LocationsTemplateUrl, HttpUtility.UrlEncode(prefix),
                settingsProvider.Settings.LanguageCode, settingsProvider.Settings.GoogleKey);

            return locationsQuery;
        }
    }
}

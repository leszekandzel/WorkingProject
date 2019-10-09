using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MapsRouteLocator.Data;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class GoogleRoutesQueryProvider : IRoutesQueryProvider
    {
        private readonly ISettingsProvider settingsProvider;
        public GoogleRoutesQueryProvider(ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
        }

        public string GetRoutesQuery(RouteCalculationRequestData routeCalculationRequestData)
        {
            var waypoints = string.Empty;
            if (routeCalculationRequestData.ViaStops != null && routeCalculationRequestData.ViaStops.Any())
            {
                waypoints = string.Join(",", routeCalculationRequestData.ViaStops.Select(x => HttpUtility.UrlEncode(x.Name)).ToArray());
            }

            var retUrl = string.Format(this.settingsProvider.Settings.DirectionsTemplateUrl,
                HttpUtility.UrlEncode (routeCalculationRequestData.RouteFrom.Name), 
                HttpUtility.UrlEncode(routeCalculationRequestData.RouteTo.Name),
                this.settingsProvider.Settings.GoogleKey,
                waypoints);

            return retUrl;
        }
    }
}

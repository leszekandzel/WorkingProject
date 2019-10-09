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
        private ISettingsProvider settingsProvider;
        public GoogleRoutesQueryProvider(ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
        }

        public string GetRoutesQuery(RouteCalculationRequestData routeCalculationRequestData)
        {
            var retUrl = String.Format(this.settingsProvider.Settings.DirectionsTemplateUrl,
                HttpUtility.UrlEncode (routeCalculationRequestData.RouteFrom.Name), 
                HttpUtility.UrlEncode(routeCalculationRequestData.RouteTo.Name),
                this.settingsProvider.Settings.GoogleKey);

            return retUrl;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Data;
using MapsRouteLocator.Events;
using MapsRouteLocator.Interfaces;
using Prism.Events;
using Prism.Mvvm;

namespace MapsRouteLocator.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        IEventAggregator eventAggregator;
        private IRoutesQueryProvider routesQueryProvider;
        public MainWindowViewModel(IEventAggregator eventAggregator, IRoutesQueryProvider routesQueryProvider)
        {
            this.eventAggregator = eventAggregator;
            this.routesQueryProvider = routesQueryProvider;
            this.eventAggregator.GetEvent<RouteCalculationRequestEvent>().Subscribe(this.CalculateRoute);
        }

        private void CalculateRoute(object o)
        {
            var routeCalculationRequestData = o as RouteCalculationRequestData;

            var requestUrl = this.routesQueryProvider.GetRoutesQuery(routeCalculationRequestData);
            this.MapUrl = requestUrl;
        }

        // I left it as possible option - here the map does not show overlays, but still it is ugly :(
        //private string mapUrl = "https://maps.googleapis.com/maps/api/staticmap?center=Switzerland&size=5000x400&zoom=7&maptype=roadmap&key=AIzaSyDp4756MODkmIKp0R4AqIYADNWKv-qbYNE";

        // This should be done also as the other parameters are done (app.config), but let's do it in next version.
        private string mapUrl = "https://www.google.com/maps/@?api=1&map_action=map&key=AIzaSyDp4756MODkmIKp0R4AqIYADNWKv-qbYNE";
        public string MapUrl
        {
            get => this.mapUrl;
            set
            {
                this.mapUrl = value;
                this.RaisePropertyChanged("MapUrl");
            }
        }
    }
}

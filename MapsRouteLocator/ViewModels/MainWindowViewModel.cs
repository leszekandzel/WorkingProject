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

        private string mapUrl = "https://www.google.com/maps/@?api=1&map_action=map&key=AIzaSyDp4756MODkmIKp0R4AqIYADNWKv-qbYNE";
        public string MapUrl
        {
            get { return this.mapUrl; }
            set
            {
                this.mapUrl = value;
                this.RaisePropertyChanged("MapUrl");
            }
        }
    }
}

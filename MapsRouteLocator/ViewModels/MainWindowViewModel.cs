using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Data;
using MapsRouteLocator.Events;
using Prism.Events;
using Prism.Mvvm;

namespace MapsRouteLocator.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        IEventAggregator eventAggregator;
        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<RouteCalculationRequestEvent>().Subscribe(this.CalculateRoute);
        }

        public string Title
        {
            get { return "This is a title"; }
        }

        private void CalculateRoute(object o)
        {
            var routeCalculationRequestData = o as RouteCalculationRequestData;
        }

        public string MapUrl
        {
            get
            {
                return "https://www.google.com/maps/@?api=1&map_action=map&key=AIzaSyDp4756MODkmIKp0R4AqIYADNWKv-qbYNE";
            }
        }
    }
}

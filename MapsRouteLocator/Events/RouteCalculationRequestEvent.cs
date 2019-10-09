using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Data;
using Prism.Events;

namespace MapsRouteLocator.Events
{
    public class RouteCalculationRequestEvent : PubSubEvent<RouteCalculationRequestData>
    {
    }
}

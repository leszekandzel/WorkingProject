using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class CultureInfoProvider : ICultureInfoProvider
    {
        public CultureInfo GetCultureInfo()
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            return culture;
        }
    }
}

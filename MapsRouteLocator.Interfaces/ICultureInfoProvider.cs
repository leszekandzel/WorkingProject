using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsRouteLocator.Interfaces
{
    /// <summary>
    /// Interface to detect current culture (used further on to pass the language as optional parameter to google)
    /// </summary>
    public interface ICultureInfoProvider
    {
        CultureInfo GetCultureInfo();
    }
}

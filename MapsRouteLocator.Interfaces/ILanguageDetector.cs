using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Data;

namespace MapsRouteLocator.Interfaces
{
    /// <summary>
    /// Interface defining a language detector. It is used to pass further on the language as optional parameter to google
    /// </summary>
    public interface ILanguageDetector
    {
        GoogleLanguage GetGoogleLanguage();
    }
}

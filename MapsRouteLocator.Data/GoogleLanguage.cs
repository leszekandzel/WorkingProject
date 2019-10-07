using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsRouteLocator.Data
{
    /// <summary>
    /// Language to pass to Google service in order to receive data in selected language.
    /// </summary>
    public class GoogleLanguage
    {
        public GoogleLanguage(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        /// <summary>
        /// Code to pass to Google service in order to receive data in selected language.
        /// </summary>
        public string  Code { get; private set; }

        /// <summary>
        /// Name just for better way do understand which language it is.
        /// </summary>
        public string Name { get; private set; }
    }
}

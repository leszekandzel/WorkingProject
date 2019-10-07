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
        private string code;
        private string name;

        public GoogleLanguage(string code, string name)
        {
            this.code = code;
            this.name = name;
        }

        /// <summary>
        /// Code to pass to Google service in order to receive data in selected language.
        /// </summary>
        public string  Code { get;  }

        /// <summary>
        /// Name just for better way do understand which language it is.
        /// </summary>
        public string Name { get;  }
    }
}

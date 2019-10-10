using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class SearchHistoryWriter : ISearchHistoryWriter
    {
        private ISettingsProvider settingsProvider;
        public SearchHistoryWriter(ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
        }

        public void Write(IEnumerable<string> list)
        {
            if (string.IsNullOrEmpty(this.settingsProvider.Settings.SearchHistoryLocationString))
            {
                throw new ArgumentException("History location could not be found");
            }

            System.IO.File.WriteAllLines(this.settingsProvider.Settings.SearchHistoryLocationString, list);
        }
    }
}

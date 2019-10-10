using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class SearchHistoryReader : ISearchHistoryReader
    {
        private ISettingsProvider settingsProvider;
        public SearchHistoryReader(ISettingsProvider settingsProvider)
        {
            this.settingsProvider = settingsProvider;
        }

        public IEnumerable<string> Read()
        {
            if (string.IsNullOrEmpty(this.settingsProvider.Settings.SearchHistoryLocationString))
            {
                throw new ArgumentException("History location could not be found");
            }

            if (!File.Exists(this.settingsProvider.Settings.SearchHistoryLocationString))
            {
                return new string[]{};
            }

           
            string[] searchedStrings = File.ReadAllLines(this.settingsProvider.Settings.SearchHistoryLocationString);
            return searchedStrings;
        }
    }
}

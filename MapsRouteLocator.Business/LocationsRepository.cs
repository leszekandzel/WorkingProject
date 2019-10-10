using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly ISearchHistoryReader searchHistoryReader;
        private readonly ISearchHistoryWriter searchHistoryWriter;
        private bool isInitialized;
        static SortedSet<string> locationsSet;
        private static SortedSet<string> LocationsSet {
            get
            {
                if (locationsSet == null)
                {
                    locationsSet = new SortedSet<string>();
                }

                return locationsSet;
            }

            set { locationsSet = value; }
        }

        public LocationsRepository(ISearchHistoryReader searchHistoryReader, ISearchHistoryWriter searchHistoryWriter)
        {
            this.searchHistoryReader = searchHistoryReader;
            this.searchHistoryWriter = searchHistoryWriter;
        }

        

        public SortedSet<string> GetLocations()
        {
            if (!this.isInitialized)
            {

                var locations = this.searchHistoryReader.Read();
                if (locations.Any())
                {
                    LocationsSet = new SortedSet<string>(locations);
                }

                this.isInitialized = true;
            }

            return LocationsSet;
        }

        public bool MemorizeLocations(string[] locations)
        {
            bool addedNewEntry = false;
            foreach (var location in locations)
            {
                if (LocationsSet.Add(location))
                {
                    addedNewEntry = true;
                }
            }

            if(addedNewEntry)
                this.searchHistoryWriter.Write(LocationsSet);

            return addedNewEntry;
        }
    }
}

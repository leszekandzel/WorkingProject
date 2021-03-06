﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsRouteLocator.Data
{
    public class Settings
    {
        public string LocationsTemplateUrl { get; set; }

        public string DirectionsTemplateUrl { get; set; }

        public string DirectionsCheckTemplateUrl { get; set; }

        public string LanguageCode { get; set; }

        public string GoogleKey { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int MinimumSearchStringLength { get; set; }

        public string SearchHistoryLocationString { get; set; }

        public bool UseLocalSearchRepository { get; set; }
        
    }
}

using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using MapsRouteLocator.Data;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class SettingsProvider : ISettingsProvider
    {
        private readonly IGoogleLanguageDetector googleLanguageDetector;
        public SettingsProvider(IGoogleLanguageDetector googleLanguageDetector)
        {
            this.googleLanguageDetector = googleLanguageDetector;
        }

        private static Settings settings;

        public  Settings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = new Settings();

                    settings.GoogleKey = System.Configuration.ConfigurationManager.AppSettings["GoogleKey"];
                    settings.LanguageCode = googleLanguageDetector.GetGoogleLanguage().Code;
                    settings.Latitude = System.Configuration.ConfigurationManager.AppSettings["Latitude"];
                    settings.Longitude = System.Configuration.ConfigurationManager.AppSettings["Longitude"];
                    settings.LocationsQueryString = System.Configuration.ConfigurationManager.AppSettings["LocationsQueryString"];

                    settings.MinimumSearchStringLength = Consts.MinimumSearchStringLength;

                    int minimumSearchStringLength;
                    if (int.TryParse(System.Configuration.ConfigurationManager.AppSettings["MinimumSearchStringLength"],
                        out minimumSearchStringLength))
                        settings.MinimumSearchStringLength = minimumSearchStringLength;
                }

                return settings;
            }
        }

        public void UpdateGeoLocation(string latitude, string longitude)
        {
            this.Settings.Latitude = latitude;
            this.Settings.Longitude = longitude;
        }
    }
}
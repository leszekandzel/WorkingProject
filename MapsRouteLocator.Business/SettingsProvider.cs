using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using MapsRouteLocator.Data;
using MapsRouteLocator.Interfaces;

namespace MapsRouteLocator.Business
{
    public class SettingsProvider : ISettingsProvider
    {
        private readonly ILanguageDetector googleLanguageDetector;
        public SettingsProvider(ILanguageDetector googleLanguageDetector)
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
                    settings.LocationsTemplateUrl = System.Configuration.ConfigurationManager.AppSettings["LocationsTemplateUrl"];
                    settings.DirectionsTemplateUrl = System.Configuration.ConfigurationManager.AppSettings["DirectionsTemplateUrl"];

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
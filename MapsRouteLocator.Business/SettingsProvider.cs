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
                    settings = new Settings
                    {
                        GoogleKey = System.Configuration.ConfigurationManager.AppSettings["GoogleKey"],
                        LanguageCode = googleLanguageDetector.GetGoogleLanguage().Code,
                        Latitude = System.Configuration.ConfigurationManager.AppSettings["Latitude"],
                        Longitude = System.Configuration.ConfigurationManager.AppSettings["Longitude"],
                        LocationsTemplateUrl = System.Configuration.ConfigurationManager.AppSettings["LocationsTemplateUrl"],
                        DirectionsTemplateUrl = System.Configuration.ConfigurationManager.AppSettings["DirectionsTemplateUrl"],
                        MinimumSearchStringLength = Consts.MinimumSearchStringLength
                    };



                    int minimumSearchStringLength;
                    if (int.TryParse(System.Configuration.ConfigurationManager.AppSettings["MinimumSearchStringLength"],
                        out minimumSearchStringLength))
                        settings.MinimumSearchStringLength = minimumSearchStringLength;
                }

                return settings;
            }
        }
    }
}
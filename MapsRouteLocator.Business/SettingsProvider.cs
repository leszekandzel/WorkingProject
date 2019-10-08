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

        private  Settings settings;

        public  Settings Settings
        {
            get
            {
                if (this.settings == null)
                {
                    this.settings = new Settings();
                    this.settings.GoogleKey = System.Configuration.ConfigurationManager.AppSettings["GoogleKey"];
                    this.settings.LanguageCode = googleLanguageDetector.GetGoogleLanguage().Code;
                    this.settings.Latitude = System.Configuration.ConfigurationManager.AppSettings["Latitude"];
                    this.settings.Longitude = System.Configuration.ConfigurationManager.AppSettings["Longitude"];
                }

                return this.settings;
            }
        }

        public void UpdateGeoLocation(string latitude, string longitude)
        {
            this.Settings.Latitude = latitude;
            this.Settings.Longitude = longitude;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using MapsRouteLocator.Interfaces;
using MapsRouteLocator.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace MapsRouteLocator.ViewModels
{
    public class LocationInputViewModel : BindableBase
    {
        private readonly ILocationsDataProvider locationsDataProvider;
        private readonly ISettingsProvider settingsProvider;
        public ObservableCollection<string> ComboItems { get; set; }

        public LocationInputViewModel(ILocationsDataProvider locationsDataProvider, ISettingsProvider settingsProvider)
        {
            this.ComboItems = new ObservableCollection<string>();
            this.locationsDataProvider = locationsDataProvider;
            this.settingsProvider = settingsProvider;
        }

        private string comboBoxText;
        public string ComboText
        {
            get { return this.comboBoxText; }
            set
            {
                this.comboBoxText = value;
                this.FetchLocations(value);
            }
        }

        private async Task FetchLocations(string prefix)
        {
            if (prefix.Length > this.settingsProvider.Settings.MinimumSearchStringLength)
            {
                if (ComboItems.Any(x => x == prefix))
                {
                    return;
                }

                var result = await locationsDataProvider.GetLocationsListAsync(prefix.ToLower());
                ComboItems.Clear();
                foreach (var location in result)
                {
                    ComboItems.Add(location.Name);
                }
            }
        }
    }
}

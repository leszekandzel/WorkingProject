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
using MapsRouteLocator.Events;
using MapsRouteLocator.Interfaces;
using MapsRouteLocator.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace MapsRouteLocator.ViewModels
{
    public class LocationInputViewModel : BindableBase
    {
        private readonly ILocationsDataProvider locationsDataProvider;
        private readonly ISettingsProvider settingsProvider;
        private readonly IEventAggregator eventAggregator;
        private readonly ILocationsRepository locationsRepository;
        public ObservableCollection<string> ComboItems { get; set; }

        public LocationInputViewModel(ILocationsDataProvider locationsDataProvider, ISettingsProvider settingsProvider, IEventAggregator eventAggregator, ILocationsRepository locationsRepository)
        {
            this.ComboItems = new ObservableCollection<string>();
            this.locationsDataProvider = locationsDataProvider;
            this.settingsProvider = settingsProvider;
            this.eventAggregator = eventAggregator;
            this.locationsRepository = locationsRepository;
            if (this.settingsProvider.Settings.UseLocalSearchRepository)
            {
                this.eventAggregator.GetEvent<LocationsSetChangedEvent>().Subscribe(this.RepopulateLocationsSet);
                this.RepopulateLocationsSet(this.locationsRepository.GetLocations());
            }
        }

        private string comboBoxText;
        public string ComboText
        {
            get { return this.comboBoxText; }
            set
            {
                this.comboBoxText = value;
                if (!this.settingsProvider.Settings.UseLocalSearchRepository)
                    this.FetchLocations(value);
            }
        }

        private void RepopulateLocationsSet(IEnumerable<string> locationsSet)
        {
            ComboItems.Clear();
            foreach (var location in locationsSet)
            {
                ComboItems.Add(location);
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

                if (result == null)
                {
                    return;
                }

                foreach (var location in result)
                {
                    ComboItems.Add(location.Name);
                }
            }
        }
    }
}

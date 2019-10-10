using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MapsRouteLocator.Data;
using MapsRouteLocator.Events;
using MapsRouteLocator.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity;
using Prism.Mvvm;

namespace MapsRouteLocator.ViewModels
{
    public class NavigationPanelViewModel : BindableBase
    {
        private ObservableCollection<LocationData> viaStops;
        public ICommand AddNewRouteCommand { get; }
        public ICommand CalculateCommand { get; }
        public ICommand RemoveViaLocationCommand { get; }

        public string RouteFrom { get; set; }
        public string RouteTo { get; set; }
        private readonly IEventAggregator eventAggregator;
        private readonly ISettingsProvider settingsProvider;
        private readonly ILocationsRepository locationsRepository;

        public NavigationPanelViewModel(IEventAggregator eventAggregator, ISettingsProvider settingsProvider, ILocationsRepository locationsRepository)
        {
            this.eventAggregator = eventAggregator;
            this.settingsProvider = settingsProvider;
            this.locationsRepository = locationsRepository;

            this.viaStops = new ObservableCollection<LocationData>();
            this.AddNewRouteCommand = new DelegateCommand(this.AddNewViewRoute);
            this.CalculateCommand = new DelegateCommand(this.Calculate);
   
            this.RemoveViaLocationCommand = new DelegateCommand<object>(this.RemoveViaLocation);
        }

        private void AddNewViewRoute()
        {
            this.viaStops.Add(new LocationData());
        }

        private void Calculate()
        {
            if (!this.ValidateCalculationRequest())
            {
                return;
            }

            var routeCalculationRequestData = new RouteCalculationRequestData();
            routeCalculationRequestData.RouteFrom = new LocationData(){Name = this.RouteFrom}; 
            routeCalculationRequestData.RouteTo = new LocationData(){Name = this.RouteTo};
            routeCalculationRequestData.ViaStops = this.viaStops.Where(x => !string.IsNullOrEmpty(x.Name)).ToArray();

            this.eventAggregator.GetEvent<RouteCalculationRequestEvent>().Publish(routeCalculationRequestData);
            if (this.settingsProvider.Settings.UseLocalSearchRepository)
            {
                var locationsToInsertToRepository =
                    this.GetLocationsFromCalculationRequestData(routeCalculationRequestData);

                if (this.locationsRepository.MemorizeLocations(locationsToInsertToRepository))
                {
                    this.eventAggregator.GetEvent<LocationsSetChangedEvent>().Publish(locationsRepository.GetLocations());
                }
            } 
        }

        private string[] GetLocationsFromCalculationRequestData(RouteCalculationRequestData routeCalculationRequestData)
        {
            List<string> list = new List<string>();
            list.Add(routeCalculationRequestData.RouteFrom.Name);
            list.Add(routeCalculationRequestData.RouteTo.Name);
            foreach (var viaStrop in routeCalculationRequestData.ViaStops)
            {
                list.Add(viaStrop.Name);
            }

            return list.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        }

        private bool ValidateCalculationRequest()
        {
            if (string.IsNullOrEmpty(this.RouteFrom) ||
                string.IsNullOrEmpty(this.RouteTo))
            {
                this.IsErrorMessageVisible = true;

                // Of course strings should be in resources, localizable.
                this.ErrorMessage = "Werte von und nach sollen nicht leer sein.";
                return false;
            }
            this.IsErrorMessageVisible = false;
            this.ErrorMessage = string.Empty;
            return true;
        }


        private bool isErrorMessageVisible;
        public bool IsErrorMessageVisible
        {
            get => this.isErrorMessageVisible;
            private set
            {
                this.isErrorMessageVisible = value;
                this.RaisePropertyChanged("IsErrorMessageVisible");
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get => this.errorMessage;
            private set
            {
                this.errorMessage = value;
                this.RaisePropertyChanged("ErrorMessage");
            }
        }

        public ObservableCollection<LocationData> ViaStops
        {
            get
            {
                return viaStops;
            }
        }

        public void RemoveViaLocation(object parameter)
        {
            var locationData = parameter as LocationData;
            this.viaStops.Remove(locationData);
        }
    }
}

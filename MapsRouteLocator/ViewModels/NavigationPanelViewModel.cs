using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MapsRouteLocator.Data;
using MapsRouteLocator.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace MapsRouteLocator.ViewModels
{
    public class NavigationPanelViewModel : BindableBase
    {
        private ObservableCollection<LocationData> routes;
        public ICommand AddNewRouteCommand { get; }
        public ICommand CalculateCommand { get; }
        public ICommand RemoveButtonClickedCommand { get; }

        public string RouteFrom { get; set; }
        public string RouteTo { get; set; }
        private IEventAggregator eventAggregator;

        public NavigationPanelViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.routes = new ObservableCollection<LocationData>();
            this.AddNewRouteCommand = new DelegateCommand(this.AddNewViewRoute);
            this.CalculateCommand = new DelegateCommand(this.Calculate);
            this.RemoveButtonClickedCommand = new DelegateCommand(this.RemoveButtonClicked);
        }

        private void AddNewViewRoute()
        {
            this.routes.Add(new LocationData());
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

            this.eventAggregator.GetEvent<RouteCalculationRequestEvent>().Publish(routeCalculationRequestData);
        }

        private bool ValidateCalculationRequest()
        {
            if (string.IsNullOrEmpty(this.RouteFrom) ||
                string.IsNullOrEmpty(this.RouteTo))
            {
                this.IsErrorMessageVisible = true;
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

        public ObservableCollection<LocationData> ViaRoutes
        {
            get
            {
                return routes;
            }
        }

        public void RemoveButtonClicked()
        {
            
        }
    }
}

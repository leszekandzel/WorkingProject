using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MapsRouteLocator.Data;
using Prism.Commands;
using Prism.Mvvm;

namespace MapsRouteLocator.ViewModels
{
    public class NavigationPanelViewModel : BindableBase
    {
        private ObservableCollection<LocationData> routes;
        public ICommand AddNewRouteCommand { get; }
        public ICommand CalculateCommand { get; }
        public ICommand RemoveButtonClickedCommand { get; }

        public LocationData RouteFrom { get; set; }
        public LocationData RouteTo { get; set; }

        public NavigationPanelViewModel()
        {
            this.routes = new ObservableCollection<LocationData>();
            this.routes.Add(new LocationData());
            this.routes.Add(new LocationData());
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace MapsRouteLocator.ViewModels
{
    public class NavigationPanelViewModel : BindableBase
    {
        private ObservableCollection<int> routes;
        public ICommand AddNewRouteCommand { get; }
        public ICommand CalculateCommand { get; }
        public ICommand RemoveButtonClickedCommand { get; }

        public NavigationPanelViewModel()
        {
            this.routes = new ObservableCollection<int>();
            this.routes.Add(1);
            this.routes.Add(2);
            this.AddNewRouteCommand = new DelegateCommand(this.AddNewViewRoute);
            this.CalculateCommand = new DelegateCommand(this.Calculate);
            this.RemoveButtonClickedCommand = new DelegateCommand(this.RemoveButtonClicked);
        }

        private void AddNewViewRoute()
        {
            this.routes.Add(0);
        }

        private void Calculate()
        {
        }


        public ObservableCollection<int> ViaRoutes
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

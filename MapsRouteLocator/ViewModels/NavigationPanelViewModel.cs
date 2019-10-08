using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace MapsRouteLocator.ViewModels
{
    public class NavigationPanelViewModel : BindableBase
    {
        private ObservableCollection<int> routes;
        public ICommand AddNewRouteCommand { get; }
        public NavigationPanelViewModel()
        {
            this.routes = new ObservableCollection<int>();
            this.routes.Add(1);
            this.routes.Add(2);
            this.AddNewRouteCommand = new DelegateCommand(this.AddNewViewRoute);
        }

        private void AddNewViewRoute()
        {
            this.routes.Add(0);
        }


        public ObservableCollection<int> ViaRoutes
        {
            get
            {
                return routes;
            }
        }

    }
}

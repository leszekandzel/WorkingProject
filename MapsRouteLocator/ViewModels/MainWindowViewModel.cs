using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace MapsRouteLocator.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public string Title
        {
            get { return "This is a title"; }
        }

        public string MapUrl
        {
            get
            {
                return "https://www.google.com/maps/@?api=1&map_action=map&key=AIzaSyDp4756MODkmIKp0R4AqIYADNWKv-qbYNE";
            }
        }
    }
}

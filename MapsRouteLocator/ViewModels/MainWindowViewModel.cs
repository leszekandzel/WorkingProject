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
    }
}

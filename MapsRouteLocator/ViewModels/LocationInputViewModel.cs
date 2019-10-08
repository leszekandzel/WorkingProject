using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using MapsRouteLocator.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace MapsRouteLocator.ViewModels
{
    public class LocationInputViewModel : BindableBase
    {
        public LocationInputViewModel()
        {
            var myItems = new[] { "Apple", "Orange", "Cherry", "Banana" };
            ComboItems = CollectionViewSource.GetDefaultView(myItems);
        }

        public ICollectionView ComboItems { get; set; }

        public string ComboText
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                ComboItems.Filter = item => item.ToString().ToLower().Contains(value.ToLower());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Device.Location;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MapsRouteLocator.Business;
using MapsRouteLocator.Interfaces;
using MapsRouteLocator.ViewModels;
using MapsRouteLocator.Views;
using Prism.Mvvm;
using Unity;
using Unity.Lifetime;


namespace MapsRouteLocator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {

            
            UnityContainer unityContainer;

            base.OnStartup(e);
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<ICultureInfoProvider, ICultureInfoProvider>();
            unityContainer.RegisterType<MapsRouteLocator.Interfaces.ISettingsProvider, MapsRouteLocator.Business.SettingsProvider>();
            unityContainer.RegisterType<IGoogleLanguageDetector, GoogleLanguageDetector>();
            unityContainer.RegisterType<ILocationsDataProvider, LocationsDataProvider>();
            ViewModelLocationProvider.SetDefaultViewModelFactory(type => unityContainer.Resolve(type));
            var window = unityContainer.Resolve<MainWindow>();
            window.ShowDialog();
        }
    }
}

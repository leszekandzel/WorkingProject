using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Device.Location;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MapsRouteLocator.Views;
using Unity;

namespace MapsRouteLocator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private UnityContainer unityContainer;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.unityContainer = new UnityContainer();

            var window = new MainWindow();
            window.ShowDialog();
        }
    }
}

using Microsoft.Extensions.Hosting;
using Prediction.IocContainer;
using Prediction.Views.Abstraction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Prediction
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.ConfigureServices();
            }).Build();

            IocControl.ConfigureServiceProvider(_host.Services);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
        }
    }
}

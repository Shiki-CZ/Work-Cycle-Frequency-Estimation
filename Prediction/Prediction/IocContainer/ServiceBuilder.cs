using Microsoft.Extensions.DependencyInjection;
using Prediction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoppeliaSim;
using Prediction.Core;
using Prediction.Core.Computing;
using Prediction.Core.Computing.Abstraction;
using Prediction.DataProvider;
using Prediction.Tools;

namespace Prediction.IocContainer
{
    public static class ServiceBuilder
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            //Register your configuration extensions here
            services.ConfigureViewModels();
            services.ConfigurePredictionCore();
            services.ConfigureTools();
            services.AddDbLayer();
            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<PeriodGraphViewModel>();
            services.AddSingleton<ExtremeGraphViewModel>();
            services.AddSingleton<ConsoleViewModel>();
            return services;
        }

        public static IServiceCollection ConfigureTools(this IServiceCollection services)
        {
            services.AddSingleton<IConsole, DebugConsole>();
            services.AddSingleton<ICommandFactory, CommandFactory>();
            services.AddSingleton<SettingsProvider>();
            services.AddSingleton<DbFeeder>();
            services.AddSingleton<ICoppeliaSimBase, SimBase>();
            services.AddSingleton<IDataFeeder, CoppeliaFeeder>();
            return services;
        }
    }
}

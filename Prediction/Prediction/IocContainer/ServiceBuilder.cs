using Microsoft.Extensions.DependencyInjection;
using Prediction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core;
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
            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<TabTestViewModel>();
            services.AddSingleton<GraphViewModel>();
            services.AddSingleton<ConsoleViewModel>();
            return services;
        }

        public static IServiceCollection ConfigureTools(this IServiceCollection services)
        {
            services.AddSingleton<IConsole, DebugConsole>();
            services.AddSingleton<ICommandFactory, CommandFactory>();
            return services;
        }
    }
}

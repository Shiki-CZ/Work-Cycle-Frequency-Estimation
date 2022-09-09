using CoppeliaSim;
using Microsoft.Extensions.DependencyInjection;
using Prediction.Core.Computing;
using Prediction.Core.Computing.Abstraction;
using Prediction.Core.Curve;
using Prediction.Core.Curve.Abstraction;
using Prediction.Core.Curve.Extremes;
using Prediction.Core.Curve.Extremes.Abstraction;
using Prediction.Core.Filtrations;
using Prediction.Core.Filtrations.Abstraction;
using Prediction.Core.Grouping;
using Prediction.Core.Grouping.Abstraction;

namespace Prediction.Core
{
    public static class Initializer
    {
        public static IServiceCollection ConfigurePredictionCore(this IServiceCollection services)
        {
            services.ConfigureCurve();
            services.ConfigureFilters();
            services.ConfigureDataFeed();
            return services;
        }

        private static IServiceCollection ConfigureCurve(this IServiceCollection services)
        {
            services.AddSingleton<IDataSmoother, SavGol>();
            services.AddSingleton<IExtremesFinder, ExtremesFinder>();
            return services;
        }
        private static IServiceCollection ConfigureFilters(this IServiceCollection services)
        {
            services.AddSingleton<IComputer, Computer>();
            return services;
        }

        private static IServiceCollection ConfigureDataFeed(this IServiceCollection services)
        {
            services.AddSingleton<ICoppeliaSimBase, SimBase>();
            return services;
        }
    }
}
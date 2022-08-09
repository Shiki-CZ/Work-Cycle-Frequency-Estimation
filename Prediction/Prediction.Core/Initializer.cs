using Microsoft.Extensions.DependencyInjection;
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
            return services;
        }

        private static IServiceCollection ConfigureCurve(this IServiceCollection services)
        {
            services.AddSingleton<IDataSmoother, SavGol>();
            services.AddSingleton<IExtremes, Extremes>();
            return services;
        }
        private static IServiceCollection ConfigureFilters(this IServiceCollection services)
        {
            services.AddSingleton<IMerger, ExtremeMerger>();
            services.AddSingleton<IToFrequency, ToFrequency>();

            return services;
        }
    }
}
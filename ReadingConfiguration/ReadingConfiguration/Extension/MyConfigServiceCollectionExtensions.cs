using Microsoft.Extensions.Configuration;
using ReadingConfiguration.Model;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TradingConfiguration>(
                configuration.GetSection("Trading")
                );
            services.Configure<CarConfiguration>(
                configuration.GetSection("Car")
                );
            return services;
        }
    }
}

using Microsoft.Extensions.Configuration;
using ReadingConfiguration.Model;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            #region This will read the configuration from appsettings.json
            services.Configure<TradingConfiguration>(
                configuration.GetSection("Trading")
                );
            services.Configure<CarConfiguration>(
                configuration.GetSection("Car")
                );
            #endregion
            // This will read the configuration azure app configuration
            
            return services;
        }
    }
}

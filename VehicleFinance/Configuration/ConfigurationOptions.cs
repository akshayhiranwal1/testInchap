using VehicleFinanceAPI.Api.Configuration.Settings;
using VehicleFinanceAPI.Api.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleFinanceAPI.Data;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace VehicleFinanceAPI.Api.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigurationOptions
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<ConnectionSettings>(configuration.GetSection(Constants.ConnectionStrings));

            var serviceProvider = services.BuildServiceProvider();
            var ConnectionOptions = serviceProvider.GetService<IOptions<ConnectionSettings>>(); services.AddDbContext<VehicleFinanceContext>(
                 option =>
                 option.UseSqlServer(ConnectionOptions.Value.DefaultConnection), ServiceLifetime.Transient);
        }
    }
}
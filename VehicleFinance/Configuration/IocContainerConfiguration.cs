using VehicleFinanceAPI.Api.Data.Management;
using VehicleFinanceAPI.Api.Repository;
using VehicleFinanceAPI.Api.Services;
using VehicleFinanceAPI.Api.Services.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleFinanceAPI.Data.ViewModel;
using VehicleFinanceAPI.Api.Services.Interfaces;

namespace VehicleFinanceAPI.Api.Configuration
{
    /// <summary>
    /// IOC contaner start-up configuration
    /// </summary>
    public static class IocContainerConfiguration
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IDataBaseManager, DataBaseManager>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            services.AddScoped(typeof(IGenericService<FinanceRateRangeViewModel>), typeof(FinanceRateRangeService<FinanceRateRangeViewModel>));
            
            services.AddScoped(typeof(IGenericService<FinanceTypeViewModel>), typeof(FinanceTypeService<FinanceTypeViewModel>));

            services.AddScoped(typeof(IGenericService<VehicleFinanceRateMappingViewModel>), typeof(VehicleFinanceRateMappingService<VehicleFinanceRateMappingViewModel>));
            
            services.AddScoped(typeof(IGenericService<VehicleTypeViewModel>), typeof(VehicleTypeService<VehicleTypeViewModel>));

            services.AddScoped(typeof(IGenericService<VehicleViewModel>), typeof(VehicleService<VehicleViewModel>));

            services.AddScoped(typeof(IGenericService<MakeViewModel>), typeof(MakeService<MakeViewModel>));

            services.AddScoped(typeof(IVehicleFinanceRateMapping<VehicleFinanceRateMappingViewModel>), typeof(VehicleFinanceRateMappingService<VehicleFinanceRateMappingViewModel>));
        }
    }
}
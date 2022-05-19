using AutoMapper;
using VehicleFinanceAPI.Api.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using VehicleFinanceAPI.Api.Configuration.Settings;
using Microsoft.Extensions.Options;

namespace VehicleFinanceAPI.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }


        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigurationOptions.ConfigureService(services, Configuration);

            services.AddMvc();

            services.AddAutoMapper(typeof(Startup));
            services.AddCors();

            SwaggerConfiguration.ConfigureService(services);

            IocContainerConfiguration.ConfigureService(services);
            services.AddMvc().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            SwaggerConfiguration.Configure(app);
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
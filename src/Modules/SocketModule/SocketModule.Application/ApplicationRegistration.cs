using SocketModule.Application.Services;
using SocketModule.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace SocketModule.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddSocketApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationRegistration).Assembly));
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ApplicationRegistration).Assembly));

            services.AddScoped<ISocketServices, SocketServices>();

            return services;
        }
    }
}

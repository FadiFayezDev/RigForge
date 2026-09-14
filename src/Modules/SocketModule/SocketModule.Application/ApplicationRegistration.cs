using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocketModule.Application.Behaviors;
using SocketModule.Application.Services;
using SocketModule.Contracts.Services;

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

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

            return services;
        }
    }
}

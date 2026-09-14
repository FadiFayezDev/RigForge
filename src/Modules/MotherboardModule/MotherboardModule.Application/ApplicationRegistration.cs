using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MotherboardModule.Application.Behaviors;
using MotherboardModule.Application.Services;
using MotherboardModule.Contracts.Services;

namespace MotherboardModule.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddMotherboardApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationRegistration).Assembly));
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ApplicationRegistration).Assembly));

            services.AddScoped<IMotherboardServices, MotherboardServices>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

            return services;
        }
    }
}

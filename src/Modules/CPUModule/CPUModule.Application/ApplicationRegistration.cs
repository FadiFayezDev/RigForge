using Catalog.Application.Behaviors;
using CPUModule.Application.Behaviors;
using CPUModule.Application.Services;
using CPUModule.Contracts.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CPUModule.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddCpuApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationRegistration).Assembly));
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ApplicationRegistration).Assembly));
           
            services.AddScoped<ICpuServices, CpuServices>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

            return services;
        }
    }
}

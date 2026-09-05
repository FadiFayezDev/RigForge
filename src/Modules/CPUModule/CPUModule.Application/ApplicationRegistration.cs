using CPUModule.Application.Services;
using CPUModule.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CPUModule.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddCpuApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationRegistration).Assembly));
           
            services.AddScoped<ICpuServices, CpuServices>();
            
            return services;
        }
    }
}

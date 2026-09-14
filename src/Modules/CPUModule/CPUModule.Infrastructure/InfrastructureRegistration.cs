using BuildingBlocks.Application.Common.Interfaces;
using CPUModule.Application;
using CPUModule.Application.Common.Interfaces;
using CPUModule.Infrastructure.Contexts;
using CPUModule.Infrastructure.Repositories.Commands.Bases;
using CPUModule.Infrastructure.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace CPUModule.Infrastructure
{
    public static class InfrastructureRegistration 
    {
        public static IServiceCollection AddCpuModuleInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");


            services.AddDbContext<CpuDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            #region Dapper registration for IDbConnection
            services.AddTransient<IDbConnection>(sp =>
                new SqlConnection(connectionString)
            );
            #endregion

            #region Application Services Registrations
            services.AddCpuApplicationServices();
            #endregion

            #region Repository Registrations
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<CPUModule.Application.Repositories.Commands.ICPUProfileRepository, CPUModule.Infrastructure.Repositories.Commands.CPUProfileRepository>();
            services.AddScoped<CPUModule.Application.Repositories.Commands.ICPUArchitectureRepository, CPUModule.Infrastructure.Repositories.Commands.CPUArchitectureRepository>();
            #endregion

            #region Query Repository Registrations
            services.AddScoped<CPUModule.Application.Repositories.Queries.ICPUProfileQueryRepository, CPUModule.Infrastructure.Repositories.Queries.CPUProfileQueryRepository>();
            services.AddScoped<CPUModule.Application.Repositories.Queries.ICPUArchitectureQueryRepository, CPUModule.Infrastructure.Repositories.Queries.CPUArchitectureQueryRepository>();
            #endregion

            #region Service Registrations
            services.AddScoped<ICpuUnitOfWork, UnitOfWork>();
            #endregion

            return services;
        }

    }
}

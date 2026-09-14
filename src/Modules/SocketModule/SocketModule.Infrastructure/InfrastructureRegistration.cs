using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocketModule.Application;
using SocketModule.Infrastructure.Contexts;
using SocketModule.Infrastructure.Repositories.Commands.Bases;
using System.Data;

namespace SocketModule.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddSocketInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");


            services.AddDbContext<SocketDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            #region Dapper registration for IDbConnection
            services.AddTransient<IDbConnection>(sp =>
                new SqlConnection(connectionString)
            );
            #endregion

            #region Application Services Registrations
            services.AddSocketApplicationServices();
            #endregion

            #region Repository Registrations
            services.AddScoped<SocketModule.Application.Repositories.Commands.ISocketProfileRepository, SocketModule.Infrastructure.Repositories.Commands.SocketProfileRepository>();
            #endregion

            #region Query Repository Registrations
            services.AddScoped<SocketModule.Application.Repositories.Queries.ISocketProfileQueryRepository, SocketModule.Infrastructure.Repositories.Queries.SocketProfileQueryRepository>();
            #endregion

            #region Service Registrations
            // NOTE: intentionally NOT registered as the shared BuildingBlocks IUnitOfWork.
            // The shared IUnitOfWork is already claimed by the CPU Module; registering it here
            // again would override the CPU registration (last-registration-wins). The Socket
            // UnitOfWork is exposed through its own ISocketUnitOfWork contract instead.
            services.AddScoped<SocketModule.Application.Common.Interfaces.ISocketUnitOfWork, SocketModule.Infrastructure.Services.UnitOfWork>();
            #endregion

            // Add your infrastructure services here
            return services;
        }

    }
}

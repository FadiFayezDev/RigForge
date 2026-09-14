using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotherboardModule.Application;
using MotherboardModule.Infrastructure.Contexts;
using MotherboardModule.Infrastructure.Repositories.Commands.Bases;
using System.Data;

namespace MotherboardModule.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddMotherboardInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");


            services.AddDbContext<MotherboardDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            #region Dapper registration for IDbConnection
            services.AddTransient<IDbConnection>(sp =>
                new SqlConnection(connectionString)
            );
            #endregion

            #region Application Services Registrations
            services.AddMotherboardApplicationServices();
            #endregion

            #region Repository Registrations
            services.AddScoped<MotherboardModule.Application.Repositories.Commands.IMotherboardProfileRepository, MotherboardModule.Infrastructure.Repositories.Commands.MotherboardProfileRepository>();
            services.AddScoped<MotherboardModule.Application.Repositories.Commands.IChipsetProfileRepository, MotherboardModule.Infrastructure.Repositories.Commands.ChipsetProfileRepository>();
            #endregion

            #region Query Repository Registrations
            services.AddScoped<MotherboardModule.Application.Repositories.Queries.IMotherboardProfileQueryRepository, MotherboardModule.Infrastructure.Repositories.Queries.MotherboardProfileQueryRepository>();
            services.AddScoped<MotherboardModule.Application.Repositories.Queries.IChipsetProfileQueryRepository, MotherboardModule.Infrastructure.Repositories.Queries.ChipsetProfileQueryRepository>();
            #endregion

            #region Service Registrations
            // NOTE: intentionally NOT registered as the shared BuildingBlocks IUnitOfWork.
            // That contract is never registered by any module; registering it here would
            // make other modules' pipelines resolve to this module's DbContext
            // (last-registration-wins). The Motherboard UnitOfWork is exposed through
            // its own IMotherboardUnitOfWork contract instead.
            services.AddScoped<MotherboardModule.Application.Common.Interfaces.IMotherboardUnitOfWork, MotherboardModule.Infrastructure.Services.UnitOfWork>();
            #endregion

            // Add your infrastructure services here
            return services;
        }

    }
}

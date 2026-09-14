using CPUModule.Application.Repositories.Queries;
using CPUModule.Application.Repositories.Queries.Bases;
using CPUModule.Contracts.DTOs.CPU;
using CPUModule.Domain.Primitives.Identifiers;
using Dapper;
using System.Data;
using System.Text;

namespace CPUModule.Infrastructure.Repositories.Queries
{
    internal class CPUProfileQueryRepository : QueryRepository, ICPUProfileQueryRepository
    {

        public CPUProfileQueryRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<CPUMiniProfileDto>> GetAllCpuMinimalProfilesAsync()
        {
            var query = "SELECT " +
                        "Id, " +
                        "Name, " +
                        "(PerformanceCores + EfficiencyCores) AS Cores, " +
                        "Threads, " +
                        "BaseClockGHz, " +
                        "BoostClockGHz, " +
                        "Price, " +
                        "TDPWatts AS TDP " +
                       $"FROM {TableCPUProfiles}";

            var result = await _connection.QueryAsync<CPUMiniProfileDto>(query);
            return result;
        }

        public async Task<IEnumerable<CPUProfileDto>> GetAllCpuProfilesAsync()
        {
            var query = $"SELECT * FROM {TableCPUProfiles}";

            var result = await _connection.QueryAsync<CPUProfileDto>(query);
            return result;
        }

        public async Task<IEnumerable<CPUMiniProfileDto>> GetCpuMinimalProfileByFilterAsync(string? name, int? cores, int? threads, decimal? baseClockGHz, decimal? boostClockGHz, decimal? price)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder = new StringBuilder(
                        "SELECT " +
                        "Id, " +
                        "Name, " +
                        "(PerformanceCores + EfficiencyCores) AS Cores, " +
                        "Threads, " +
                        "BaseClockGHz, " +
                        "BoostClockGHz, " +
                        "Price, " +
                        "TDPWatts AS TDP " +
                       $"FROM {TableCPUProfiles} WHERE 1=1");

            if (name is not null)
                queryBuilder.Append(" AND Name = @Name");

            if (cores is not null)
                queryBuilder.Append(" AND Cores = @Cores");

            if (threads is not null)
                queryBuilder.Append(" AND Threads = @Threads");

            if (baseClockGHz is not null)
                queryBuilder.Append(" AND BaseClockGHz = @BaseClockGHz");

            if (boostClockGHz is not null)
                queryBuilder.Append(" AND BoostClockGHz = @BoostClockGHz");

            if (price is not null)
                queryBuilder.Append(" AND Price = @Price");


            var query = queryBuilder.ToString();
            var parameters = new
            {
                Name = name,
                Cores = cores,
                Threads = threads,
                BaseClockGHz = baseClockGHz,
                BoostClockGHz = boostClockGHz,
                Price = price
            };

            return await _connection.QueryAsync<CPUMiniProfileDto>(query, parameters);
        }

        public async Task<CPUProfileDto?> GetCpuProfileByIdAsync(CPUProfileId id)
        {
            var query = $"SELECT * FROM {TableCPUProfiles} WHERE Id = @Id";
            var parameters = new { Id = id.Value };
            return await _connection.QuerySingleOrDefaultAsync<CPUProfileDto?>(query, parameters);
        }

        public async Task<CPUProfileDto?> GetCpuProfileByNameAsync(string name)
        {
            var query = $"SELECT * FROM {TableCPUProfiles} WHERE Name = @Name";
            var parameters = new { Name = name };
            return await _connection.QuerySingleOrDefaultAsync<CPUProfileDto?>(query, parameters);
        }

        public async Task<IEnumerable<CPUProfileDto>> GetCpuProfilesByGuidsAsync(params CPUProfileId[] ids)
        {
            var query = $"SELECT * FROM {TableCPUProfiles} WHERE Id IN @Ids";
            var parameters = new { Ids = ids.Select(id => id.Value) };
            return await _connection.QueryAsync<CPUProfileDto>(query, parameters);
        }
    }
}
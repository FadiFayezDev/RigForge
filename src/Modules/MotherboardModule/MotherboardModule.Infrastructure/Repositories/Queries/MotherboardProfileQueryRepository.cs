using MotherboardModule.Application.Repositories.Queries;
using MotherboardModule.Application.Repositories.Queries.Bases;
using MotherboardModule.Contracts.DTOs;
using MotherboardModule.Domain.Primitives.Identifiers;
using Dapper;
using System.Data;

namespace MotherboardModule.Infrastructure.Repositories.Queries
{
    internal class MotherboardProfileQueryRepository : QueryRepository, IMotherboardProfileQueryRepository
    {
        public MotherboardProfileQueryRepository(IDbConnection connection) : base(connection)
        {
        }

        private string BaseSelectColumns =>
            "M.Id, " +
            "M.Name, " +
            "M.Manufacturer, " +
            "M.SocketId, " +
            "M.RamSlots, " +
            "M.RamType, " +
            "M.MaxRamCapacityGB, " +
            "M.PcieVersion, " +
            "M.M2Slots, " +
            "M.SataPorts, " +
            "S.Name AS Socket ";

        private string BaseJoin =>
            $"FROM {TableMotherboardProfiles} M" +
            $"JOIN {TableSockets} S " +
            $"ON M.SocketId = S.Id ";

        public async Task<IEnumerable<MotherboardProfileDto>> GetAllMotherboardProfilesAsync()
        {
            var query = $"SELECT {BaseSelectColumns}{BaseJoin}";
            return await _connection.QueryAsync<MotherboardProfileDto>(query);
        }

        public async Task<MotherboardProfileDto?> GetMotherboardProfileByIdAsync(MotherboardProfileId id)
        {
            var query = $"SELECT {BaseSelectColumns}{BaseJoin}" +
                        $"WHERE {TableMotherboardProfiles}.Id = @Id";
            var parameters = new { Id = id.Value };
            return await _connection.QuerySingleOrDefaultAsync<MotherboardProfileDto?>(query, parameters);
        }

        public async Task<MotherboardProfileDto?> GetMotherboardProfileByNameAsync(string name)
        {
            var query = $"SELECT {BaseSelectColumns}{BaseJoin}" +
                        $"WHERE {TableMotherboardProfiles}.Name = @Name";
            var parameters = new { Name = name };
            return await _connection.QuerySingleOrDefaultAsync<MotherboardProfileDto?>(query, parameters);
        }
    }
}

using MotherboardModule.Application.Repositories.Queries;
using MotherboardModule.Application.Repositories.Queries.Bases;
using MotherboardModule.Contracts.DTOs;
using MotherboardModule.Domain.Primitives.Identifiers;
using Dapper;
using System.Data;

namespace MotherboardModule.Infrastructure.Repositories.Queries
{
    internal class ChipsetProfileQueryRepository : QueryRepository, IChipsetProfileQueryRepository
    {
        public ChipsetProfileQueryRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<ChipsetProfileDto>> GetAllChipsetProfilesAsync()
        {
            var query = $"SELECT Id, Name, Manufacturer, SocketId FROM {TableChipsetProfiles}";
            return await _connection.QueryAsync<ChipsetProfileDto>(query);
        }

        public async Task<ChipsetProfileDto?> GetChipsetProfileByIdAsync(ChipsetProfileId id)
        {
            var query = $"SELECT Id, Name, Manufacturer, SocketId FROM {TableChipsetProfiles} WHERE Id = @Id";
            var parameters = new { Id = id.Value };
            return await _connection.QuerySingleOrDefaultAsync<ChipsetProfileDto?>(query, parameters);
        }

        public async Task<ChipsetProfileDto?> GetChipsetProfileByNameAsync(string name)
        {
            var query = $"SELECT Id, Name, Manufacturer, SocketId FROM {TableChipsetProfiles} WHERE Name = @Name";
            var parameters = new { Name = name };
            return await _connection.QuerySingleOrDefaultAsync<ChipsetProfileDto?>(query, parameters);
        }
    }
}

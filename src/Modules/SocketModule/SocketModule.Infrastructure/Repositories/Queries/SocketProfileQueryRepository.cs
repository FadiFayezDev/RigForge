using SocketModule.Application.Repositories.Queries;
using SocketModule.Application.Repositories.Queries.Bases;
using SocketModule.Contracts.DTOs;
using SocketModule.Domain.Primitives.Identifiers;
using Dapper;
using System.Data;

namespace SocketModule.Infrastructure.Repositories.Queries
{
    internal class SocketProfileQueryRepository : QueryRepository, ISocketProfileQueryRepository
    {
        public SocketProfileQueryRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<SocketProfileDto>> GetAllSocketProfilesAsync()
        {
            var query = $"SELECT Id, Name, Manufacturer FROM {TableSocketProfiles}";
            return await _connection.QueryAsync<SocketProfileDto>(query);
        }

        public async Task<SocketProfileDto?> GetSocketProfileByIdAsync(SocketProfileId id)
        {
            var query = $"SELECT Id, Name, Manufacturer FROM {TableSocketProfiles} WHERE Id = @Id";
            var parameters = new { Id = id.Value };
            return await _connection.QuerySingleOrDefaultAsync<SocketProfileDto?>(query, parameters);
        }

        public async Task<SocketProfileDto?> GetSocketProfileByNameAsync(string name)
        {
            var query = $"SELECT Id, Name, Manufacturer FROM {TableSocketProfiles} WHERE Name = @Name";
            var parameters = new { Name = name };
            return await _connection.QuerySingleOrDefaultAsync<SocketProfileDto?>(query, parameters);
        }

        public async Task<IEnumerable<SocketProfileDto>> GetSocketProfilesByGuidsAsync(params SocketProfileId[] ids)
        {
            var query = $"SELECT Id, Name, Manufacturer FROM {TableSocketProfiles} WHERE Id IN @Ids";
            var parameters = new { Ids = ids.Select(id => id.Value) };
            return await _connection.QueryAsync<SocketProfileDto>(query, parameters);
        }
    }
}

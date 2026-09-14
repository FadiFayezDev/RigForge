using CPUModule.Application.Repositories.Queries;
using CPUModule.Application.Repositories.Queries.Bases;
using CPUModule.Contracts.DTOs.CPUArchitectures;
using CPUModule.Domain.Primitives.Identifiers;
using Dapper;
using System.Data;

namespace CPUModule.Infrastructure.Repositories.Queries;

internal class CPUArchitectureQueryRepository : QueryRepository, ICPUArchitectureQueryRepository
{
    public CPUArchitectureQueryRepository(IDbConnection connection) : base(connection)
    {
    }

    public async Task<IEnumerable<CPUArchitectureDto>> GetAllCpuArchitecturesAsync()
    {
        var query = $"SELECT Id, Name, ProcessNodeNM, Description FROM {TableCPUArchitectures}";
        return await _connection.QueryAsync<CPUArchitectureDto>(query);
    }

    public async Task<CPUArchitectureDto?> GetCpuArchitectureByIdAsync(CPUArchitectureId id)
    {
        var query = $"SELECT Id, Name, ProcessNodeNM, Description FROM {TableCPUArchitectures} WHERE Id = @Id";
        var parameters = new { Id = id.Value };
        return await _connection.QuerySingleOrDefaultAsync<CPUArchitectureDto?>(query, parameters);
    }
}

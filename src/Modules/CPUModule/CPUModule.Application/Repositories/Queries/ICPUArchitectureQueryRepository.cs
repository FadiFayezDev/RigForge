using CPUModule.Contracts.DTOs.CPUArchitectures;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Application.Repositories.Queries;

public interface ICPUArchitectureQueryRepository
{
    Task<IEnumerable<CPUArchitectureDto>> GetAllCpuArchitecturesAsync();
    Task<CPUArchitectureDto?> GetCpuArchitectureByIdAsync(CPUArchitectureId id);
}

using CPUModule.Contracts.DTOs.CPU;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Application.Repositories.Queries;

public interface ICPUProfileQueryRepository
{
    public Task<IEnumerable<CPUMiniProfileDto>> GetAllCpuMinimalProfilesAsync();
    public Task<IEnumerable<CPUProfileDto>> GetAllCpuProfilesAsync();
    public Task<CPUProfileDto?> GetCpuProfileByIdAsync(CPUProfileId id);
    public Task<CPUProfileDto?> GetCpuProfileByNameAsync(string name);
    public Task<IEnumerable<CPUProfileDto>> GetCpuProfilesByGuidsAsync(params CPUProfileId[] ids);

    public Task<IEnumerable<CPUMiniProfileDto>> GetCpuMinimalProfileByFilterAsync(string? name, int? cores, int? threads, decimal? baseClockGHz, decimal? boostClockGHz, decimal? price);
}

using MotherboardModule.Contracts.DTOs;
using MotherboardModule.Domain.Primitives.Identifiers;

namespace MotherboardModule.Application.Repositories.Queries;

public interface IMotherboardProfileQueryRepository
{
    public Task<IEnumerable<MotherboardProfileDto>> GetAllMotherboardProfilesAsync();
    public Task<MotherboardProfileDto?> GetMotherboardProfileByIdAsync(MotherboardProfileId id);
    public Task<MotherboardProfileDto?> GetMotherboardProfileByNameAsync(string name);
}

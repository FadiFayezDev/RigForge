using MotherboardModule.Contracts.DTOs;
using MotherboardModule.Domain.Primitives.Identifiers;

namespace MotherboardModule.Application.Repositories.Queries;

public interface IChipsetProfileQueryRepository
{
    public Task<IEnumerable<ChipsetProfileDto>> GetAllChipsetProfilesAsync();
    public Task<ChipsetProfileDto?> GetChipsetProfileByIdAsync(ChipsetProfileId id);
    public Task<ChipsetProfileDto?> GetChipsetProfileByNameAsync(string name);
}

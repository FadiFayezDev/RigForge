using SocketModule.Contracts.DTOs;
using SocketModule.Domain.Primitives.Identifiers;

namespace SocketModule.Application.Repositories.Queries;

public interface ISocketProfileQueryRepository
{
    Task<IEnumerable<SocketProfileDto>> GetAllSocketProfilesAsync();
    Task<SocketProfileDto?> GetSocketProfileByIdAsync(SocketProfileId id);
    Task<SocketProfileDto?> GetSocketProfileByNameAsync(string name);
    Task<IEnumerable<SocketProfileDto>> GetSocketProfilesByGuidsAsync(params SocketProfileId[] ids);
}

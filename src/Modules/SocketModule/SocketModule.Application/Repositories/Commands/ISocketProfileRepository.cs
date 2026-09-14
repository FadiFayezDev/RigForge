using BuildingBlocks.Application.Common.Interfaces;
using SocketModule.Domain.Entities;
using SocketModule.Domain.Primitives.Identifiers;

namespace SocketModule.Application.Repositories.Commands
{
    public interface ISocketProfileRepository : IRepository<SocketProfile, SocketProfileId>
    {
    }
}

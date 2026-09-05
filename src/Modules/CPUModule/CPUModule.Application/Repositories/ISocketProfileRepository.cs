using BuildingBlocks.Application.Common.Interfaces;
using CPUModule.Domain.Primitives.Identifiers;
using Domain.Entities.Socket;

namespace CPUModule.Application.Repositories
{
    public interface ISocketProfileRepository : IRepository<SocketProfile, SocketProfileId>
    {
    }
}

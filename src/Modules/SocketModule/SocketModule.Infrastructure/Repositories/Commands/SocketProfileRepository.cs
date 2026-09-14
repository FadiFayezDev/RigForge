using SocketModule.Application.Repositories.Commands;
using SocketModule.Domain.Entities;
using SocketModule.Domain.Primitives.Identifiers;
using SocketModule.Infrastructure.Repositories.Commands.Bases;

namespace SocketModule.Infrastructure.Repositories.Commands
{
    internal class SocketProfileRepository : Repository<SocketProfile, SocketProfileId>, ISocketProfileRepository
    {
        public SocketProfileRepository(Contexts.SocketDbContext context) : base(context)
        {
        }
    }
}

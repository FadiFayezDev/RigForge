using BuildingBlocks.Application.Common.Interfaces;

namespace SocketModule.Application.Common.Interfaces
{
    /// <summary>
    /// Unit of work bound to the Socket Module's isolated persistence.
    /// Kept separate from the shared <see cref="IUnitOfWork"/> (claimed by the
    /// CPU Module) so module registrations never override each other.
    /// </summary>
    public interface ISocketUnitOfWork : IUnitOfWork
    {
    }
}

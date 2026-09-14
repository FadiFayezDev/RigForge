using BuildingBlocks.Application.Common.Interfaces;

namespace MotherboardModule.Application.Common.Interfaces
{
    /// <summary>
    /// Unit of work bound to the Motherboard Module's isolated persistence.
    /// Kept separate from the shared <see cref="IUnitOfWork"/> so module
    /// registrations never override each other.
    /// </summary>
    public interface IMotherboardUnitOfWork : IUnitOfWork
    {
    }
}

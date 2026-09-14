using BuildingBlocks.Application.Common.Interfaces;
using MotherboardModule.Domain.Entities;
using MotherboardModule.Domain.Primitives.Identifiers;

namespace MotherboardModule.Application.Repositories.Commands
{
    public interface IMotherboardProfileRepository : IRepository<MotherboardProfile, MotherboardProfileId>
    {
    }
}

using BuildingBlocks.Application.Common.Interfaces;
using CPUModule.Domain.Entities;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Application.Repositories.Commands
{
    public interface ICPUProfileRepository : IRepository<CPUProfile, CPUProfileId>
    {
    }
}

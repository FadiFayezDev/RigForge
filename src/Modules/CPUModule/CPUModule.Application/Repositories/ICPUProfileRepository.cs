using BuildingBlocks.Application.Common.Interfaces;
using CPUModule.Domain.Entities;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Application.Repositories
{
    public interface ICPUProfileRepository : IRepository<CPUProfile, CPUProfileId>
    {
    }
}

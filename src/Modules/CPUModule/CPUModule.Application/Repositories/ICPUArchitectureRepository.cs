using BuildingBlocks.Application.Common.Interfaces;
using CPUModule.Domain.Primitives.Identifiers;
using Domain.Entities.CPU;

namespace CPUModule.Application.Repositories
{
    public interface ICPUArchitectureRepository : IRepository<CPUArchitecture, CPUArchitectureId>
    {
    }
}

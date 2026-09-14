using BuildingBlocks.Application.Common.Interfaces;
using CPUModule.Domain.Primitives.Identifiers;
using Domain.Entities.CPU;

namespace CPUModule.Application.Repositories.Commands
{
    public interface ICPUArchitectureRepository : IRepository<CPUArchitecture, CPUArchitectureId>
    {
    }
}

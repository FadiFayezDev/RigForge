using CPUModule.Application.Repositories.Commands;
using CPUModule.Domain.Primitives.Identifiers;
using CPUModule.Infrastructure.Contexts;
using CPUModule.Infrastructure.Repositories.Commands.Bases;
using Domain.Entities.CPU;

namespace CPUModule.Infrastructure.Repositories.Commands
{
    internal class CPUArchitectureRepository : Repository<CPUArchitecture, CPUArchitectureId>, ICPUArchitectureRepository
    {
        public CPUArchitectureRepository(CpuDbContext context) : base(context)
        {
        }
    }
}

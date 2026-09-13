using CPUModule.Application.Repositories.Commands;
using CPUModule.Domain.Entities;
using CPUModule.Domain.Primitives.Identifiers;
using CPUModule.Infrastructure.Contexts;
using CPUModule.Infrastructure.Repositories.Commands.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPUModule.Infrastructure.Repositories.Commands
{
    internal class CPUProfileRepository : Repository<CPUProfile, CPUProfileId>, ICPUProfileRepository
    {
        public CPUProfileRepository(CpuDbContext context) : base(context)
        {
        }
    }
}

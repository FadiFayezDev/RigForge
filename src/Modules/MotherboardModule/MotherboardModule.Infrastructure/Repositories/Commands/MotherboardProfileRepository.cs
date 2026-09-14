using MotherboardModule.Application.Repositories.Commands;
using MotherboardModule.Domain.Entities;
using MotherboardModule.Domain.Primitives.Identifiers;
using MotherboardModule.Infrastructure.Contexts;
using MotherboardModule.Infrastructure.Repositories.Commands.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotherboardModule.Infrastructure.Repositories.Commands
{
    internal class MotherboardProfileRepository : Repository<MotherboardProfile, MotherboardProfileId>, IMotherboardProfileRepository
    {
        public MotherboardProfileRepository(MotherboardDbContext context) : base(context)
        {
        }
    }
}

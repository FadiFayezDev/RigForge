using CPUModule.Contracts.DTOs.CPU;
using CPUModule.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPUModule.Application.Services
{
    internal class CpuServices : ICpuServices
    {
        public Task<IEnumerable<CPUMiniProfileDto>> GetAllCpuMinimalProfilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CPUMiniProfileDto> GetCpuMinimalProfileByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CPUProfileDto> RegisterNewCpuAsync(RegisterCpuDto registerCpu)
        {
            throw new NotImplementedException();
        }
    }
}

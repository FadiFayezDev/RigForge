using CPUModule.Contracts.DTOs.CPU;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPUModule.Contracts.Services
{
    public interface ICpuServices
    {
        Task<CPUProfileDto> RegisterNewCpuAsync(RegisterCpuDto registerCpu);

        Task<CPUMiniProfileDto> GetCpuMinimalProfileByIdAsync(Guid id);
        Task<IEnumerable<CPUMiniProfileDto>> GetAllCpuMinimalProfilesAsync();
    }
}

using AutoMapper;
using CPUModule.Application.UseCases.CPUs;
using CPUModule.Application.UseCases.CPUArchitectures;
using CPUModule.Contracts.DTOs.CPU;
using CPUModule.Contracts.DTOs.CPUArchitectures;
using CPUModule.Contracts.Services;
using CPUModule.Domain.Enums;
using CPUModule.Domain.Primitives.Identifiers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPUModule.Application.Services
{
    internal class CpuServices : ICpuServices
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CpuServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        #endregion

        #region CPU Profile Retrieval 
        public Task<IEnumerable<CPUMiniProfileDto>> GetAllCpuMinimalProfilesAsync()
        {
            var query = new GetAllCpuMinimalProfilesQuery();
            return _mediator.Send(query);
        }

        public Task<IEnumerable<CPUProfileDto>> GetAllCpuProfilesAsync()
        {
            var query = new GetAllCpuProfilesQuery();
            return _mediator.Send(query);
        }

        public async Task<CPUProfileDto?> GetCpuProfileByIdAsync(Guid id)
        {
            var cpuId = CPUProfileId.FromGuid(id);
            var query = new GetCpuProfileByIdQuery(cpuId);
            return await _mediator.Send(query);
        }

        public async Task<CPUProfileDto?> GetCpuProfileByNameAsync(string name)
        {
            var query = new GetCpuProfileByNameQuery(name);
            return await _mediator.Send(query);
        }
        #endregion

        #region CPU Profile Management
        public async Task<Guid> RegisterNewCpuAsync(RegisterCpuDto registerCpu)
        {
            var command = _mapper.Map<RegisterNewCpuCommand>(registerCpu);
            var id = await _mediator.Send(command);
            return id.Value;
        }

        public async Task<bool> UpdateCpuProfileAsync(UpdateCpuDto updateCpu)
        {
            var command = _mapper.Map<UpdateCpuCommand>(updateCpu);
            await _mediator.Send(command);
            return true;
        }

        public Task<bool> DeleteCpuProfileAsync(Guid id)
        {
            var command = new DeleteCpuCommand(id);
            return _mediator.Send(command);
        }
        #endregion

        #region CPU Architecture Retrieval
        public Task<IEnumerable<CPUArchitectureDto>> GetAllCpuArchitecturesAsync()
        {
            var query = new GetAllCpuArchitecturesQuery();
            return _mediator.Send(query);
        }

        public async Task<CPUArchitectureDto?> GetCpuArchitectureByIdAsync(Guid id)
        {
            var query = new GetCpuArchitectureByIdQuery(id);
            return await _mediator.Send(query);
        }
        #endregion

        #region CPU Architecture Management
        public async Task<Guid> RegisterNewCpuArchitectureAsync(RegisterCpuArchitectureDto registerCpuArchitecture)
        {
            var command = _mapper.Map<RegisterNewCpuArchitectureCommand>(registerCpuArchitecture);
            var id = await _mediator.Send(command);
            return id.Value;
        }

        public async Task<bool> UpdateCpuArchitectureAsync(UpdateCpuArchitectureDto updateCpuArchitecture)
        {
            var command = _mapper.Map<UpdateCpuArchitectureCommand>(updateCpuArchitecture);
            await _mediator.Send(command);
            return true;
        }

        public Task<bool> DeleteCpuArchitectureAsync(Guid id)
        {
            var command = new DeleteCpuArchitectureCommand(id);
            return _mediator.Send(command);
        }
        #endregion

        #region Enums
        public async Task<IEnumerable<string>> GetCpuManufacturerNamesAsync()
            => Enum.GetNames<Manufacturer>();
        public async Task<IEnumerable<string>> GetCpuFamilyTypeNamesAsync()
            => Enum.GetNames<CPUFamily>();
        public async Task<IEnumerable<string>> GetCoolerTypeNamesAsync()
            => Enum.GetNames<CoolerType>();
        public async Task<IEnumerable<string>> GetPciExpressVersionNamesAsync()
            => Enum.GetNames<PCIeVersion>();
        public async Task<IEnumerable<string>> GetRamTypeNamesAsync()
            => Enum.GetNames<RamType>();
        #endregion
    }
}

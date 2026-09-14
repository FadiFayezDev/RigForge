using AutoMapper;
using MotherboardModule.Application.UseCases.Chipsets;
using MotherboardModule.Application.UseCases.Motherboards;
using MotherboardModule.Contracts.DTOs;
using MotherboardModule.Contracts.Services;
using MotherboardModule.Domain.Enums;
using MotherboardModule.Domain.Primitives.Identifiers;
using MediatR;
using System;
using System.Collections.Generic;

namespace MotherboardModule.Application.Services
{
    internal class MotherboardServices : IMotherboardServices
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public MotherboardServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        #endregion

        #region Motherboard Profile Retrieval
        public Task<IEnumerable<MotherboardProfileDto>> GetAllMotherboardProfilesAsync()
        {
            var query = new GetAllMotherboardProfilesQuery();
            return _mediator.Send(query);
        }

        public async Task<MotherboardProfileDto?> GetMotherboardProfileByIdAsync(Guid id)
        {
            var motherboardId = MotherboardProfileId.FromGuid(id);
            var query = new GetMotherboardProfileByIdQuery(motherboardId);
            return await _mediator.Send(query);
        }

        public async Task<MotherboardProfileDto?> GetMotherboardProfileByNameAsync(string name)
        {
            var query = new GetMotherboardProfileByNameQuery(name);
            return await _mediator.Send(query);
        }
        #endregion

        #region Motherboard Profile Management
        public async Task<Guid> RegisterNewMotherboardAsync(RegisterMotherboardDto registerMotherboard)
        {
            var command = _mapper.Map<RegisterNewMotherboardCommand>(registerMotherboard);
            var id = await _mediator.Send(command);
            return id.Value;
        }
        #endregion

        #region Enums
        public async Task<IEnumerable<string>> GetMotherboardManufacturerNamesAsync()
            => Enum.GetNames<Manufacturer>();
        public async Task<IEnumerable<string>> GetChipsetManufacturerNamesAsync()
            => Enum.GetNames<ChipsetManufacturer>();
        #endregion

        #region Chipset Profile Retrieval
        public Task<IEnumerable<ChipsetProfileDto>> GetAllChipsetProfilesAsync()
        {
            var query = new GetAllChipsetProfilesQuery();
            return _mediator.Send(query);
        }

        public async Task<ChipsetProfileDto?> GetChipsetProfileByIdAsync(Guid id)
        {
            var chipsetId = ChipsetProfileId.FromGuid(id);
            var query = new GetChipsetProfileByIdQuery(chipsetId);
            return await _mediator.Send(query);
        }

        public async Task<ChipsetProfileDto?> GetChipsetProfileByNameAsync(string name)
        {
            var query = new GetChipsetProfileByNameQuery(name);
            return await _mediator.Send(query);
        }
        #endregion

        #region Chipset Profile Management
        public async Task<Guid> RegisterNewChipsetAsync(RegisterChipsetDto registerChipset)
        {
            var command = _mapper.Map<RegisterNewChipsetCommand>(registerChipset);
            var id = await _mediator.Send(command);
            return id.Value;
        }

        public async Task<bool> UpdateChipsetProfileAsync(UpdateChipsetDto updateChipset)
        {
            var command = _mapper.Map<UpdateChipsetCommand>(updateChipset);
            await _mediator.Send(command);
            return true;
        }

        public Task<bool> DeleteChipsetProfileAsync(Guid id)
        {
            var command = new DeleteChipsetCommand(id);
            return _mediator.Send(command);
        }
        #endregion
    }
}

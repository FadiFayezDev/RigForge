using AutoMapper;
using SocketModule.Application.UseCases.Sockets;
using SocketModule.Contracts.DTOs;
using SocketModule.Contracts.Services;
using SocketModule.Domain.Enums;
using SocketModule.Domain.Primitives.Identifiers;
using MediatR;
using System;
using System.Collections.Generic;

namespace SocketModule.Application.Services
{
    internal class SocketServices : ISocketServices
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public SocketServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        #endregion

        #region Socket Profile Retrieval
        public Task<IEnumerable<SocketProfileDto>> GetAllSocketProfilesAsync()
        {
            var query = new GetAllSocketProfilesQuery();
            return _mediator.Send(query);
        }

        public async Task<SocketProfileDto?> GetSocketProfileByIdAsync(Guid id)
        {
            var socketId = SocketProfileId.FromGuid(id);
            var query = new GetSocketProfileByIdQuery(socketId);
            return await _mediator.Send(query);
        }

        public async Task<SocketProfileDto?> GetSocketProfileByNameAsync(string name)
        {
            var query = new GetSocketProfileByNameQuery(name);
            return await _mediator.Send(query);
        }
        #endregion

        #region Socket Profile Management
        public async Task<Guid> RegisterNewSocketAsync(RegisterSocketDto registerSocket)
        {
            var command = _mapper.Map<RegisterNewSocketCommand>(registerSocket);
            var id = await _mediator.Send(command);
            return id.Value;
        }

        public async Task<bool> UpdateSocketProfileAsync(UpdateSocketDto updateSocket)
        {
            var command = _mapper.Map<UpdateSocketCommand>(updateSocket);
            await _mediator.Send(command);
            return true;
        }

        public Task<bool> DeleteSocketProfileAsync(Guid id)
        {
            var command = new DeleteSocketCommand(id);
            return _mediator.Send(command);
        }
        #endregion

        #region Cross-Module Integration
        public async Task<bool> SocketExistsAsync(Guid id)
        {
            var socket = await GetSocketProfileByIdAsync(id);
            return socket is not null;
        }
        #endregion

        #region Enums
        public async Task<IEnumerable<string>> GetSocketManufacturerNamesAsync()
            => Enum.GetNames<Manufacturer>();
        #endregion
    }
}

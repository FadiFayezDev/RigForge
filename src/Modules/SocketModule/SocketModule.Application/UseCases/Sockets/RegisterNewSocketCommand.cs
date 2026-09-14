using SocketModule.Application.Abstractions;
using SocketModule.Application.Repositories.Commands;
using SocketModule.Domain.Entities;
using SocketModule.Domain.Enums;
using SocketModule.Domain.Primitives.Identifiers;
using MediatR;

namespace SocketModule.Application.UseCases.Sockets
{
    /// <summary>
    /// Command to register a new socket profile in the system.
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Manufacturer"></param>
    /// <returns><see cref="SocketProfileId">Socket Profile Id</see></returns>
    public sealed record RegisterNewSocketCommand(
        string Name,
        Manufacturer Manufacturer
    ) : ICommand<SocketProfileId>;

    public sealed class RegisterNewSocketCommandHandler : IRequestHandler<RegisterNewSocketCommand, SocketProfileId>
    {
        private readonly ISocketProfileRepository _socketProfileRepository;
        public RegisterNewSocketCommandHandler(ISocketProfileRepository socketProfileRepository)
        {
            _socketProfileRepository = socketProfileRepository;
        }
        public async Task<SocketProfileId> Handle(RegisterNewSocketCommand command, CancellationToken cancellationToken)
        {
            var socketProfile = SocketProfile.Create(
                command.Name,
                command.Manufacturer
            );
            await _socketProfileRepository.AddAsync(socketProfile);

            return socketProfile.Id;
        }
    }
}

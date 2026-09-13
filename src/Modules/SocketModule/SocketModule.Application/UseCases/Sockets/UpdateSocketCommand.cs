using SocketModule.Application.Abstractions;
using SocketModule.Application.Repositories.Commands;
using SocketModule.Domain.Enums;
using SocketModule.Domain.Primitives.Identifiers;
using MediatR;

namespace SocketModule.Application.UseCases.Sockets
{
    /// <summary>
    /// Command to update an existing socket profile.
    /// Only properties that have explicit domain update behaviors will be modified.
    /// </summary>
    public sealed record UpdateSocketCommand(
        SocketProfileId Id,
        string Name,
        Manufacturer Manufacturer
    ) : ICommand<Unit>;

    public sealed class UpdateSocketCommandHandler : IRequestHandler<UpdateSocketCommand, Unit>
    {
        private readonly ISocketProfileRepository _socketProfileRepository;

        public UpdateSocketCommandHandler(ISocketProfileRepository socketProfileRepository)
        {
            _socketProfileRepository = socketProfileRepository;
        }

        public async Task<Unit> Handle(UpdateSocketCommand command, CancellationToken cancellationToken)
        {
            var socket = await _socketProfileRepository.GetByIdAsync(command.Id);
            if (socket is null)
                throw new ArgumentException($"Socket profile with id {command.Id} was not found.");

            // Apply domain behaviors (they validate invariants)
            socket.UpdateName(command.Name);
            socket.UpdateManufacturer(command.Manufacturer);

            await _socketProfileRepository.UpdateAsync(socket);

            return Unit.Value;
        }
    }
}

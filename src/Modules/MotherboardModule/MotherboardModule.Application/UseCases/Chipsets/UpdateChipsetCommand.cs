using MotherboardModule.Application.Abstractions;
using MotherboardModule.Application.Repositories.Commands;
using MotherboardModule.Domain.Enums;
using MotherboardModule.Domain.Primitives.Identifiers;
using MediatR;
using SocketModule.Contracts.Services;

namespace MotherboardModule.Application.UseCases.Chipsets
{
    /// <summary>
    /// Command to update an existing chipset profile.
    /// Only properties that have explicit domain update behaviors will be modified.
    /// </summary>
    public sealed record UpdateChipsetCommand(
        ChipsetProfileId Id,
        string Name,
        ChipsetManufacturer Manufacturer,
        Guid SocketId
    ) : ICommand<Unit>;

    public sealed class UpdateChipsetCommandHandler : IRequestHandler<UpdateChipsetCommand, Unit>
    {
        private readonly IChipsetProfileRepository _chipsetProfileRepository;
        private readonly ISocketServices _socketServices;

        public UpdateChipsetCommandHandler(IChipsetProfileRepository chipsetProfileRepository, ISocketServices socketServices)
        {
            _chipsetProfileRepository = chipsetProfileRepository;
            _socketServices = socketServices;
        }

        public async Task<Unit> Handle(UpdateChipsetCommand command, CancellationToken cancellationToken)
        {
            var chipset = await _chipsetProfileRepository.GetByIdAsync(command.Id);
            if (chipset is null)
                throw new ArgumentException($"Chipset profile with id {command.Id} was not found.");

            // Validate the socket reference through Socket.Contracts only.
            if (!await _socketServices.SocketExistsAsync(command.SocketId))
                throw new ArgumentException($"Socket profile with id {command.SocketId} was not found.", nameof(command.SocketId));

            // Apply domain behaviors (they validate invariants)
            chipset.UpdateName(command.Name);
            chipset.UpdateManufacturer(command.Manufacturer);
            chipset.UpdateSocket(command.SocketId);

            await _chipsetProfileRepository.UpdateAsync(chipset);

            return Unit.Value;
        }
    }
}

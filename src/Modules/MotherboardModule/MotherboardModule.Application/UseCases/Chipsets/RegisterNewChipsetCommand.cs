using MediatR;
using MotherboardModule.Application.Abstractions;
using MotherboardModule.Application.Repositories.Commands;
using MotherboardModule.Domain.Entities;
using MotherboardModule.Domain.Enums;
using MotherboardModule.Domain.Primitives.Identifiers;
using SocketModule.Contracts.Services;

namespace MotherboardModule.Application.UseCases.Chipsets
{
    /// <summary>
    /// Command to register a new chipset profile in the system.
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Manufacturer"></param>
    /// <param name="SocketId"></param>
    /// <returns><see cref="ChipsetProfileId">Chipset Profile Id</see></returns>
    public sealed record RegisterNewChipsetCommand(
        string Name,
        ChipsetManufacturer Manufacturer,
        Guid SocketId
    ) : ICommand<ChipsetProfileId>;

    public sealed class RegisterNewChipsetCommandHandler : IRequestHandler<RegisterNewChipsetCommand, ChipsetProfileId>
    {
        private readonly IChipsetProfileRepository _chipsetProfileRepository;
        private readonly ISocketServices _socketServices;
        public RegisterNewChipsetCommandHandler(IChipsetProfileRepository chipsetProfileRepository, ISocketServices socketServices)
        {
            _chipsetProfileRepository = chipsetProfileRepository;
            _socketServices = socketServices;
        }
        public async Task<ChipsetProfileId> Handle(RegisterNewChipsetCommand command, CancellationToken cancellationToken)
        {
            // Validate the socket reference through Socket.Contracts only.
            // The Motherboard Module never touches Socket Domain/Infrastructure types.
            if (!await _socketServices.SocketExistsAsync(command.SocketId))
                throw new ArgumentException($"Socket profile with id {command.SocketId} was not found.", nameof(command.SocketId));

            var chipsetProfile = ChipsetProfile.Create(
                command.Name,
                command.Manufacturer,
                command.SocketId
            );
            await _chipsetProfileRepository.AddAsync(chipsetProfile);
            return chipsetProfile.Id;
        }
    }
}

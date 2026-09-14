using MediatR;
using MotherboardModule.Application.Abstractions;
using MotherboardModule.Application.Repositories.Commands;
using MotherboardModule.Domain.Entities;
using MotherboardModule.Domain.Enums;
using MotherboardModule.Domain.Primitives.Identifiers;
using SocketModule.Contracts.Services;

namespace MotherboardModule.Application.UseCases.Motherboards
{
    /// <summary>
    /// Command to register a new motherboard profile in the system.
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Manufacturer"></param>
    /// <param name="SocketId"></param>
    /// <param name="RamSlots"></param>
    /// <param name="RamType"></param>
    /// <param name="MaxRamCapacityGB"></param>
    /// <param name="PcieVersion"></param>
    /// <param name="M2Slots"></param>
    /// <param name="SataPorts"></param>
    /// <returns><see cref="MotherboardProfileId">Motherboard Profile Id</see></returns>
    public sealed record RegisterNewMotherboardCommand(
        string Name,
        Manufacturer Manufacturer,
        Guid SocketId,
        int RamSlots,
        RamType RamType,
        int MaxRamCapacityGB,
        PCIeVersion PcieVersion,
        int M2Slots,
        int SataPorts
    ) : ICommand<MotherboardProfileId>;

    public sealed class RegisterNewMotherboardCommandHandler : IRequestHandler<RegisterNewMotherboardCommand, MotherboardProfileId>
    {
        private readonly IMotherboardProfileRepository _motherboardProfileRepository;
        private readonly ISocketServices _socketServices;
        public RegisterNewMotherboardCommandHandler(IMotherboardProfileRepository motherboardProfileRepository, ISocketServices socketServices)
        {
            _motherboardProfileRepository = motherboardProfileRepository;
            _socketServices = socketServices;
        }
        public async Task<MotherboardProfileId> Handle(RegisterNewMotherboardCommand command, CancellationToken cancellationToken)
        {
            // Validate the socket reference through Socket.Contracts only.
            // The Motherboard Module never touches Socket Domain/Infrastructure types.
            if (!await _socketServices.SocketExistsAsync(command.SocketId))
                throw new ArgumentException($"Socket profile with id {command.SocketId} was not found.", nameof(command.SocketId));

            var motherboardProfile = MotherboardProfile.Create(
                command.Name,
                command.Manufacturer,
                command.SocketId,
                command.RamSlots,
                command.RamType,
                command.MaxRamCapacityGB,
                command.PcieVersion,
                command.M2Slots,
                command.SataPorts
            );
            await _motherboardProfileRepository.AddAsync(motherboardProfile);
            return motherboardProfile.Id;
        }
    }
}

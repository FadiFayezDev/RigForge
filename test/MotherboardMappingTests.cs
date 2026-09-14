using AutoMapper;
using MotherboardModule.Application.UseCases.Chipsets;
using MotherboardModule.Application.UseCases.Motherboards;
using MotherboardModule.Contracts.DTOs;
using MotherboardModule.Domain.Entities;
using MotherboardModule.Domain.Enums;

namespace test
{
    public class MotherboardMappingTests
    {
        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(MotherboardModule.Application.ApplicationRegistration).Assembly),
                Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance);
            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }

        [Fact]
        public void MappingConfiguration_IsValid()
        {
            CreateMapper();
        }

        [Fact]
        public void Map_RegisterMotherboardDto_ToCommand_MapsAllMembers()
        {
            var mapper = CreateMapper();
            var dto = new RegisterMotherboardDto(
                "ROG Strix B650E", "Asus", Guid.NewGuid(),
                4, "DDR5", 128, "PCIe5", 3, 4);

            var command = mapper.Map<RegisterNewMotherboardCommand>(dto);

            Assert.Equal(dto.Name, command.Name);
            Assert.Equal(Manufacturer.Asus, command.Manufacturer);
            Assert.Equal(dto.SocketId, command.SocketId);
            Assert.Equal(4, command.RamSlots);
            Assert.Equal(RamType.DDR5, command.RamType);
            Assert.Equal(128, command.MaxRamCapacityGB);
            Assert.Equal(PCIeVersion.PCIe5, command.PcieVersion);
            Assert.Equal(3, command.M2Slots);
            Assert.Equal(4, command.SataPorts);
        }

        [Fact]
        public void Map_MotherboardProfile_ToDto_MapsAllMembers()
        {
            var mapper = CreateMapper();
            var profile = MotherboardProfile.Create(
                "ROG Strix B650E", Manufacturer.Asus, Guid.NewGuid(),
                ramSlots: 4, ramType: RamType.DDR5, maxRamCapacityGB: 128,
                pcieVersion: PCIeVersion.PCIe5, m2Slots: 3, sataPorts: 4);

            var dto = mapper.Map<MotherboardProfileDto>(profile);

            Assert.Equal(profile.Id.Value, dto.Id);
            Assert.Equal("ROG Strix B650E", dto.Name);
            Assert.Equal("Asus", dto.Manufacturer);
            Assert.Equal(profile.SocketId, dto.SocketId);
            Assert.Equal(4, dto.RamSlots);
            Assert.Equal("DDR5", dto.RamType);
            Assert.Equal(128, dto.MaxRamCapacityGB);
            Assert.Equal("PCIe5", dto.PcieVersion);
            Assert.Equal(3, dto.M2Slots);
            Assert.Equal(4, dto.SataPorts);
        }

        [Fact]
        public void Map_RegisterChipsetDto_ToCommand_MapsAllMembers()
        {
            var mapper = CreateMapper();
            var dto = new RegisterChipsetDto("B650", "AMD", Guid.NewGuid());

            var command = mapper.Map<RegisterNewChipsetCommand>(dto);

            Assert.Equal("B650", command.Name);
            Assert.Equal(ChipsetManufacturer.AMD, command.Manufacturer);
            Assert.Equal(dto.SocketId, command.SocketId);
        }

        [Fact]
        public void Map_ChipsetProfile_ToDto_MapsAllMembers()
        {
            var mapper = CreateMapper();
            var profile = ChipsetProfile.Create("B650", ChipsetManufacturer.AMD, Guid.NewGuid());

            var dto = mapper.Map<ChipsetProfileDto>(profile);

            Assert.Equal(profile.Id.Value, dto.Id);
            Assert.Equal("B650", dto.Name);
            Assert.Equal("AMD", dto.Manufacturer);
            Assert.Equal(profile.SocketId, dto.SocketId);
        }

        [Fact]
        public void Map_UpdateChipsetDto_ToCommand_MapsAllMembers()
        {
            var mapper = CreateMapper();
            var id = Guid.NewGuid();
            var socketId = Guid.NewGuid();
            var dto = new UpdateChipsetDto(id, "Z790", "Intel", socketId);

            var command = mapper.Map<UpdateChipsetCommand>(dto);

            Assert.Equal(id, command.Id.Value);
            Assert.Equal("Z790", command.Name);
            Assert.Equal(ChipsetManufacturer.Intel, command.Manufacturer);
            Assert.Equal(socketId, command.SocketId);
        }
    }
}

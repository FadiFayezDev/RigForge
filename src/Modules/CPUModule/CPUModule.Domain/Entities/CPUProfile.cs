using BuildingBlocks.Domain.Bases;
using CPUModule.Domain.Enums;
using CPUModule.Domain.Primitives.Identifiers;
using CPUModule.Domain.Primitives.ValueObjects;
using CPUModule.Domain.Events;
using Domain.Entities.CPU;

namespace CPUModule.Domain.Entities
{
    public class CPUProfile : AggregateRoot<CPUProfileId>
    {
        // =========================
        // Identity
        // =========================

        public string Name { get; private set; } = default!;

        public decimal Price { get; private set; }

        public Manufacturer Manufacturer { get; private set; }

        public CPUFamily Family { get; private set; }

        public CPUArchitectureId ArchitectureId { get; private set; }

        public CPUArchitecture? Architecture { get; private set; }

        public int ReleaseYear { get; private set; }


        // =========================
        // Performance
        // =========================

        public CPUCores Cores { get; private set; } = default!;

        public int Threads { get; private set; }

        public decimal BaseClockGHz { get; private set; }

        public decimal BoostClockGHz { get; private set; }


        // =========================
        // Cache
        // =========================

        public int L2CacheMB { get; private set; }

        public int L3CacheMB { get; private set; }


        // =========================
        // Power & Cooling
        // =========================

        public int TDPWatts { get; private set; }

        public bool CoolerIncluded { get; private set; }

        public CoolerType? IncludedCoolerType { get; private set; }

        public bool SupportsOverclocking { get; private set; }


        // =========================
        // Integrated Graphics
        // =========================

        public bool HasIntegratedGraphics { get; private set; }

        public string? IntegratedGraphicsModel { get; private set; }


        // =========================
        // Compatibility
        // =========================

        /// <summary>
        /// Reference to a socket owned by the Socket Module.
        /// Stored as a plain Guid so the CPU Module only depends on
        /// Socket.Contracts (Guid-based) and never on Socket Domain types.
        /// </summary>
        public Guid SocketId { get; private set; }

        public RamType SupportedRamType { get; private set; }

        public int MaxMemorySpeedMHz { get; private set; }

        public int MaxMemoryCapacityGB { get; private set; }

        public PCIeVersion PCIeVersion { get; private set; }

        public int PCIeLanes { get; private set; }


        // =========================
        // EF Core
        // =========================

        private CPUProfile()
        {
        }


        // =========================
        // Factory
        // =========================

        public static CPUProfile Create(
            string name,
            decimal price,

            Manufacturer manufacturer,
            CPUFamily family,
            CPUArchitectureId architectureId,
            int releaseYear,

            int performanceCores,
            int efficiencyCores,
            int threads,

            decimal baseClockGHz,
            decimal boostClockGHz,

            int l2CacheMB,
            int l3CacheMB,

            int tdpWatts,

            bool coolerIncluded,
            CoolerType? includedCoolerType,

            bool supportsOverclocking,

            bool hasIntegratedGraphics,
            string? integratedGraphicsModel,

            Guid socketId,

            RamType supportedRamType,
            int maxMemorySpeedMHz,
            int maxMemoryCapacityGB,

            PCIeVersion pcieVersion,
            int pcieLanes)
        {
            if (socketId == Guid.Empty)
                throw new ArgumentException(
                    "Socket id cannot be empty.",
                    nameof(socketId));

            Validate(
                name,
                price,
                releaseYear,
                threads,
                baseClockGHz,
                boostClockGHz,
                l2CacheMB,
                l3CacheMB,
                tdpWatts,
                maxMemorySpeedMHz,
                maxMemoryCapacityGB,
                pcieLanes);

            var cores = CPUCores.Create(
                performanceCores,
                efficiencyCores);

            var cpu = new CPUProfile
            {
                Id = CPUProfileId.New(),

                Name = name.Trim(),
                Price = price,

                Manufacturer = manufacturer,
                Family = family,
                ArchitectureId = architectureId,
                ReleaseYear = releaseYear,

                Cores = cores,

                Threads = threads,

                BaseClockGHz = baseClockGHz,
                BoostClockGHz = boostClockGHz,

                L2CacheMB = l2CacheMB,
                L3CacheMB = l3CacheMB,

                TDPWatts = tdpWatts,

                CoolerIncluded = coolerIncluded,
                IncludedCoolerType = includedCoolerType,

                SupportsOverclocking = supportsOverclocking,

                HasIntegratedGraphics = hasIntegratedGraphics,
                IntegratedGraphicsModel =
                    integratedGraphicsModel?.Trim(),

                SocketId = socketId,

                SupportedRamType = supportedRamType,
                MaxMemorySpeedMHz = maxMemorySpeedMHz,
                MaxMemoryCapacityGB = maxMemoryCapacityGB,

                PCIeVersion = pcieVersion,
                PCIeLanes = pcieLanes
            };

            // Domain invariants
            if (cpu.CoolerIncluded && cpu.IncludedCoolerType is null)
                throw new ArgumentException("Included cooler type must be provided when a cooler is included.");

            if (!cpu.CoolerIncluded && cpu.IncludedCoolerType is not null)
                throw new ArgumentException("Included cooler type must be null when no cooler is included.");

            if (cpu.HasIntegratedGraphics && string.IsNullOrWhiteSpace(cpu.IntegratedGraphicsModel))
                throw new ArgumentException("Integrated graphics model must be provided when CPU has integrated graphics.");

            if (!cpu.HasIntegratedGraphics && !string.IsNullOrWhiteSpace(cpu.IntegratedGraphicsModel))
                throw new ArgumentException("Integrated graphics model must be null when CPU has no integrated graphics.");

            if (cpu.Threads < cores.TotalCores)
                throw new ArgumentException("Threads cannot be less than total cores.");

            // Domain event
            cpu.AddDomainEvent(new CPUProfileCreatedEvent(cpu.Id, cpu.Name));

            return cpu;
        }


        // =========================
        // Domain Behavior
        // =========================

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "CPU name cannot be empty.",
                    nameof(name));

            Name = name.Trim();
            AddDomainEvent(new CPUProfileNameUpdatedEvent(Id, Name));
        }


        public void UpdatePrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(price));

            Price = price;
            AddDomainEvent(new CPUProfilePriceUpdatedEvent(Id, Price));
        }


        public void UpdateCores(
            int performanceCores,
            int efficiencyCores = 0)
        {
            Cores.SetCores(
                performanceCores,
                efficiencyCores);

            if (Threads < Cores.TotalCores)
                throw new ArgumentException("Threads cannot be less than total cores after updating cores.");

            AddDomainEvent(new CPUProfileCoresUpdatedEvent(
                Id,
                Cores.PerformanceCores,
                Cores.EfficiencyCores,
                Cores.TotalCores));
        }

        public void UpdateThreads(int threads)
        {
            if (threads <= 0)
                throw new ArgumentOutOfRangeException(nameof(threads));

            if (threads < Cores.TotalCores)
                throw new ArgumentException("Threads cannot be less than total cores.");

            Threads = threads;
            AddDomainEvent(new CPUProfileThreadsUpdatedEvent(Id, Threads));
        }


        public void UpdateClockSpeeds(
            decimal baseClockGHz,
            decimal boostClockGHz)
        {
            if (baseClockGHz <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(baseClockGHz));

            if (boostClockGHz <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(boostClockGHz));

            if (boostClockGHz < baseClockGHz)
                throw new ArgumentException(
                    "Boost clock cannot be lower than base clock.");

            BaseClockGHz = baseClockGHz;
            BoostClockGHz = boostClockGHz;
            AddDomainEvent(new CPUProfileClockSpeedsUpdatedEvent(Id, BaseClockGHz, BoostClockGHz));
        }


        public void UpdateCache(
            int l2CacheMB,
            int l3CacheMB)
        {
            if (l2CacheMB < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(l2CacheMB));

            if (l3CacheMB < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(l3CacheMB));

            L2CacheMB = l2CacheMB;
            L3CacheMB = l3CacheMB;
            AddDomainEvent(new CPUProfileCacheUpdatedEvent(Id, L2CacheMB, L3CacheMB));
        }


        public void UpdateCooling(
            int tdpWatts,
            bool coolerIncluded,
            CoolerType? coolerType)
        {
            if (tdpWatts <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(tdpWatts));

            if (coolerIncluded && coolerType is null)
                throw new ArgumentException("Included cooler type must be provided when coolerIncluded is true.");

            if (!coolerIncluded)
                coolerType = null;

            TDPWatts = tdpWatts;
            CoolerIncluded = coolerIncluded;
            IncludedCoolerType = coolerType;
            AddDomainEvent(new CPUProfileCoolingUpdatedEvent(Id, TDPWatts, CoolerIncluded, IncludedCoolerType));
        }


        public void UpdateIntegratedGraphics(
            bool hasIntegratedGraphics,
            string? graphicsModel = null)
        {
            if (hasIntegratedGraphics && string.IsNullOrWhiteSpace(graphicsModel))
                throw new ArgumentException("Graphics model must be provided when hasIntegratedGraphics is true.");

            if (!hasIntegratedGraphics)
                graphicsModel = null;

            HasIntegratedGraphics = hasIntegratedGraphics;

            IntegratedGraphicsModel = graphicsModel?.Trim();
            AddDomainEvent(new CPUProfileIntegratedGraphicsUpdatedEvent(Id, HasIntegratedGraphics, IntegratedGraphicsModel));
        }


        public void UpdateMemorySupport(
            RamType ramType,
            int maxMemorySpeedMHz,
            int maxMemoryCapacityGB)
        {
            if (maxMemorySpeedMHz <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(maxMemorySpeedMHz));

            if (maxMemoryCapacityGB <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(maxMemoryCapacityGB));

            SupportedRamType = ramType;
            MaxMemorySpeedMHz = maxMemorySpeedMHz;
            MaxMemoryCapacityGB = maxMemoryCapacityGB;
            AddDomainEvent(new CPUProfileMemorySupportUpdatedEvent(Id, SupportedRamType, MaxMemorySpeedMHz, MaxMemoryCapacityGB));
        }


        public void UpdatePCIe(
            PCIeVersion pcieVersion,
            int pcieLanes)
        {
            if (pcieLanes <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(pcieLanes));

            PCIeVersion = pcieVersion;
            PCIeLanes = pcieLanes;
            AddDomainEvent(new CPUProfilePCIeUpdatedEvent(Id, PCIeVersion, PCIeLanes));
        }


        public void UpdateSocket(Guid socketId)
        {
            if (socketId == Guid.Empty)
                throw new ArgumentException(
                    "Socket id cannot be empty.",
                    nameof(socketId));

            SocketId = socketId;
            AddDomainEvent(new CPUProfileSocketUpdatedEvent(Id, SocketId));
        }


        public void UpdateOverclocking(bool supportsOverclocking)
        {
            SupportsOverclocking = supportsOverclocking;
            AddDomainEvent(new CPUProfileOverclockingUpdatedEvent(Id, SupportsOverclocking));
        }


        // =========================
        // Validation
        // =========================

        private static void Validate(
            string name,
            decimal price,
            int releaseYear,
            int threads,
            decimal baseClockGHz,
            decimal boostClockGHz,
            int l2CacheMB,
            int l3CacheMB,
            int tdpWatts,
            int maxMemorySpeedMHz,
            int maxMemoryCapacityGB,
            int pcieLanes)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "CPU name cannot be empty.",
                    nameof(name));

            if (price < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(price));

            if (releaseYear <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(releaseYear));

            if (threads <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(threads));

            if (baseClockGHz <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(baseClockGHz));

            if (boostClockGHz <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(boostClockGHz));

            if (boostClockGHz < baseClockGHz)
                throw new ArgumentException(
                    "Boost clock cannot be lower than base clock.");

            if (l2CacheMB < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(l2CacheMB));

            if (l3CacheMB < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(l3CacheMB));

            if (tdpWatts <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(tdpWatts));

            if (maxMemorySpeedMHz <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(maxMemorySpeedMHz));

            if (maxMemoryCapacityGB <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(maxMemoryCapacityGB));

            if (pcieLanes <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(pcieLanes));
        }
    }
}
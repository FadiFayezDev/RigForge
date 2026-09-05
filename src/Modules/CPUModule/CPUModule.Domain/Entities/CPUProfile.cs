using BuildingBlocks.Domain.Bases;
using CPUModule.Domain.Enums;
using CPUModule.Domain.Primitives.Identifiers;
using CPUModule.Domain.Primitives.ValueObjects;
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

        public SocketProfileId SocketId { get; private set; }

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

            SocketProfileId socketId,

            RamType supportedRamType,
            int maxMemorySpeedMHz,
            int maxMemoryCapacityGB,

            PCIeVersion pcieVersion,
            int pcieLanes)
        {
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

            return new CPUProfile
            {
                Id = CPUProfileId.New(),

                Name = name.Trim(),
                Price = price,

                Manufacturer = manufacturer,
                Family = family,
                ArchitectureId = architectureId,
                ReleaseYear = releaseYear,

                Cores = CPUCores.Create(
                    performanceCores,
                    efficiencyCores),

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
        }


        public void UpdatePrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(price));

            Price = price;
        }


        public void UpdateCores(
            int performanceCores,
            int efficiencyCores = 0)
        {
            Cores.SetCores(
                performanceCores,
                efficiencyCores);
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
        }


        public void UpdateCooling(
            int tdpWatts,
            bool coolerIncluded,
            CoolerType? coolerType)
        {
            if (tdpWatts <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(tdpWatts));

            if (!coolerIncluded)
                coolerType = null;

            TDPWatts = tdpWatts;
            CoolerIncluded = coolerIncluded;
            IncludedCoolerType = coolerType;
        }


        public void UpdateIntegratedGraphics(
            bool hasIntegratedGraphics,
            string? graphicsModel = null)
        {
            if (!hasIntegratedGraphics)
                graphicsModel = null;

            HasIntegratedGraphics =
                hasIntegratedGraphics;

            IntegratedGraphicsModel =
                graphicsModel?.Trim();
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
        }


        public void UpdateSocket(SocketProfileId socketId)
        {
            SocketId = socketId;
        }


        public void UpdateOverclocking(bool supportsOverclocking)
        {
            SupportsOverclocking = supportsOverclocking;
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
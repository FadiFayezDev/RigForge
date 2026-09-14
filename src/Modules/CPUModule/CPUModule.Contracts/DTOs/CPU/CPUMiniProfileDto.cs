using System;
using System.Collections.Generic;
using System.Text;

namespace CPUModule.Contracts.DTOs.CPU
{
    public record CPUMiniProfileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public int Cores { get; set; }
        public int Threads { get; set; }
        // Use GHz decimals to match domain model units
        public decimal BaseClockGHz { get; set; }
        public decimal BoostClockGHz { get; set; }
        public decimal Price { get; set; }
        public int TDP { get; set; }

    }
}

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
        public int BaseClockMHz { get; set; }
        public int BoostClockMHz { get; set; }
        public decimal Price { get; set; }

    }
}

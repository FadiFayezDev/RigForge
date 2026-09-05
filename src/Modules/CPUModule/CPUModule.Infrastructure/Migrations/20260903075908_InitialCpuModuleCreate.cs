using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPUModule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCpuModuleCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CPU");

            migrationBuilder.CreateTable(
                name: "CPUArchitectures",
                schema: "CPU",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProcessNodeNM = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUArchitectures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocketProfile",
                schema: "CPU",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocketProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPUProfiles",
                schema: "CPU",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArchitectureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    PerformanceCores = table.Column<int>(type: "int", nullable: false),
                    EfficiencyCores = table.Column<int>(type: "int", nullable: false),
                    Threads = table.Column<int>(type: "int", nullable: false),
                    BaseClockGHz = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    BoostClockGHz = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    L2CacheMB = table.Column<int>(type: "int", nullable: false),
                    L3CacheMB = table.Column<int>(type: "int", nullable: false),
                    TDPWatts = table.Column<int>(type: "int", nullable: false),
                    CoolerIncluded = table.Column<bool>(type: "bit", nullable: false),
                    IncludedCoolerType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SupportsOverclocking = table.Column<bool>(type: "bit", nullable: false),
                    HasIntegratedGraphics = table.Column<bool>(type: "bit", nullable: false),
                    IntegratedGraphicsModel = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SocketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupportedRamType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaxMemorySpeedMHz = table.Column<int>(type: "int", nullable: false),
                    MaxMemoryCapacityGB = table.Column<int>(type: "int", nullable: false),
                    PCIeVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PCIeLanes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPUProfiles_CPUArchitectures_ArchitectureId",
                        column: x => x.ArchitectureId,
                        principalSchema: "CPU",
                        principalTable: "CPUArchitectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUProfiles_SocketProfile_SocketId",
                        column: x => x.SocketId,
                        principalSchema: "CPU",
                        principalTable: "SocketProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CPUProfiles_ArchitectureId",
                schema: "CPU",
                table: "CPUProfiles",
                column: "ArchitectureId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUProfiles_SocketId",
                schema: "CPU",
                table: "CPUProfiles",
                column: "SocketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CPUProfiles",
                schema: "CPU");

            migrationBuilder.DropTable(
                name: "CPUArchitectures",
                schema: "CPU");

            migrationBuilder.DropTable(
                name: "SocketProfile",
                schema: "CPU");
        }
    }
}

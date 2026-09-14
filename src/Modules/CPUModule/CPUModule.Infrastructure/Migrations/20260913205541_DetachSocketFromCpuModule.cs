using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPUModule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DetachSocketFromCpuModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUProfiles_SocketProfile_SocketId",
                schema: "CPU",
                table: "CPUProfiles");

            migrationBuilder.DropTable(
                name: "SocketProfile",
                schema: "CPU");

            migrationBuilder.DropIndex(
                name: "IX_CPUProfiles_SocketId",
                schema: "CPU",
                table: "CPUProfiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocketProfile",
                schema: "CPU",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocketProfile", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CPUProfiles_SocketId",
                schema: "CPU",
                table: "CPUProfiles",
                column: "SocketId");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUProfiles_SocketProfile_SocketId",
                schema: "CPU",
                table: "CPUProfiles",
                column: "SocketId",
                principalSchema: "CPU",
                principalTable: "SocketProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

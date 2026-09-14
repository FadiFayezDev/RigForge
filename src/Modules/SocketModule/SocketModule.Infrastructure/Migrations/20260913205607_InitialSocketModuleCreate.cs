using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocketModule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSocketModuleCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Socket");

            migrationBuilder.CreateTable(
                name: "SocketProfiles",
                schema: "Socket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocketProfiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocketProfiles",
                schema: "Socket");
        }
    }
}

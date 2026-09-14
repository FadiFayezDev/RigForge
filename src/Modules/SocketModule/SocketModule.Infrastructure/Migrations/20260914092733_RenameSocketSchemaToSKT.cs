using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocketModule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameSocketSchemaToSKT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SKT");

            migrationBuilder.RenameTable(
                name: "SocketProfiles",
                schema: "Socket",
                newName: "SocketProfiles",
                newSchema: "SKT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Socket");

            migrationBuilder.RenameTable(
                name: "SocketProfiles",
                schema: "SKT",
                newName: "SocketProfiles",
                newSchema: "Socket");
        }
    }
}

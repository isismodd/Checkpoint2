using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkpoint2.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarClienteIdNoJogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Jogos",
                type: "NUMBER(10)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Jogos");
        }
    }
}

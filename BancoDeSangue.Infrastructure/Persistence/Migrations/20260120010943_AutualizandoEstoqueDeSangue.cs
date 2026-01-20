using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoDeSangue.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AutualizandoEstoqueDeSangue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantidadeMinimaMl",
                table: "Estoques",
                type: "int",
                nullable: false,
                defaultValue: 5000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeMinimaMl",
                table: "Estoques");
        }
    }
}

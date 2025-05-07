using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_VidaPlus.Migrations
{
    /// <inheritdoc />
    public partial class arrumando_relacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultaId",
                table: "Prontuarios");

            migrationBuilder.DropColumn(
                name: "ExameId",
                table: "Prontuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultaId",
                table: "Prontuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExameId",
                table: "Prontuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

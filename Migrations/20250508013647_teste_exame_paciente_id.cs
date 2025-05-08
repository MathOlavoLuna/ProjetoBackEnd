using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_VidaPlus.Migrations
{
    /// <inheritdoc />
    public partial class teste_exame_paciente_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Exames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exames_PacienteId",
                table: "Exames",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_Usuarios_PacienteId",
                table: "Exames",
                column: "PacienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exames_Usuarios_PacienteId",
                table: "Exames");

            migrationBuilder.DropIndex(
                name: "IX_Exames_PacienteId",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Exames");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_VidaPlus.Migrations
{
    /// <inheritdoc />
    public partial class Leito_paciente_nullable_true : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leito_Usuarios_PacienteId",
                table: "Leito");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Leito",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Leito_Usuarios_PacienteId",
                table: "Leito",
                column: "PacienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leito_Usuarios_PacienteId",
                table: "Leito");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Leito",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Leito_Usuarios_PacienteId",
                table: "Leito",
                column: "PacienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_VidaPlus.Migrations
{
    /// <inheritdoc />
    public partial class relacionamento_prontuarios_consu_usua_exame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProntuarioId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProntuarioId",
                table: "Exames",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProntuarioId",
                table: "Consultas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descritivo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: false),
                    ExameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prontuarios_Usuarios_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_ProntuarioId",
                table: "Exames",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_ProntuarioId",
                table: "Consultas",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_PacienteId",
                table: "Prontuarios",
                column: "PacienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Prontuarios_ProntuarioId",
                table: "Consultas",
                column: "ProntuarioId",
                principalTable: "Prontuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_Prontuarios_ProntuarioId",
                table: "Exames",
                column: "ProntuarioId",
                principalTable: "Prontuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Prontuarios_ProntuarioId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Exames_Prontuarios_ProntuarioId",
                table: "Exames");

            migrationBuilder.DropTable(
                name: "Prontuarios");

            migrationBuilder.DropIndex(
                name: "IX_Exames_ProntuarioId",
                table: "Exames");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_ProntuarioId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "ProntuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ProntuarioId",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "ProntuarioId",
                table: "Consultas");
        }
    }
}

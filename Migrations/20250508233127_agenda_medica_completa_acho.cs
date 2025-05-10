using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_VidaPlus.Migrations
{
    /// <inheritdoc />
    public partial class agenda_medica_completa_acho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Exames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AgendaMedica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaMedica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaMedica_Usuarios_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_MedicoId",
                table: "Exames",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaMedica_MedicoId",
                table: "AgendaMedica",
                column: "MedicoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_Usuarios_MedicoId",
                table: "Exames",
                column: "MedicoId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exames_Usuarios_MedicoId",
                table: "Exames");

            migrationBuilder.DropTable(
                name: "AgendaMedica");

            migrationBuilder.DropIndex(
                name: "IX_Exames_MedicoId",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Exames");
        }
    }
}

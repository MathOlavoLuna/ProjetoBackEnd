using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_VidaPlus.Migrations
{
    /// <inheritdoc />
    public partial class OneToOneConsultasPrescricoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Prescricoes_PrescricaoId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_PrescricaoId",
                table: "Consultas");

            migrationBuilder.AddColumn<int>(
                name: "ConsultaId",
                table: "Prescricoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescricoes_ConsultaId",
                table: "Prescricoes",
                column: "ConsultaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescricoes_Consultas_ConsultaId",
                table: "Prescricoes",
                column: "ConsultaId",
                principalTable: "Consultas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescricoes_Consultas_ConsultaId",
                table: "Prescricoes");

            migrationBuilder.DropIndex(
                name: "IX_Prescricoes_ConsultaId",
                table: "Prescricoes");

            migrationBuilder.DropColumn(
                name: "ConsultaId",
                table: "Prescricoes");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PrescricaoId",
                table: "Consultas",
                column: "PrescricaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Prescricoes_PrescricaoId",
                table: "Consultas",
                column: "PrescricaoId",
                principalTable: "Prescricoes",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_VidaPlus.Migrations
{
    /// <inheritdoc />
    public partial class produto_perde_dependencia_de_estar_num_relatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_RelatoriosFinanceiros_RelatorioId",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "RelatorioId",
                table: "Produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_RelatoriosFinanceiros_RelatorioId",
                table: "Produtos",
                column: "RelatorioId",
                principalTable: "RelatoriosFinanceiros",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_RelatoriosFinanceiros_RelatorioId",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "RelatorioId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_RelatoriosFinanceiros_RelatorioId",
                table: "Produtos",
                column: "RelatorioId",
                principalTable: "RelatoriosFinanceiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

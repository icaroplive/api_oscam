using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class foreingkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_idCliente",
                table: "Financeiro",
                column: "idCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Financeiro_Cliente_idCliente",
                table: "Financeiro",
                column: "idCliente",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financeiro_Cliente_idCliente",
                table: "Financeiro");

            migrationBuilder.DropIndex(
                name: "IX_Financeiro_idCliente",
                table: "Financeiro");
        }
    }
}

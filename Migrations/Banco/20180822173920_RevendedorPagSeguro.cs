using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class RevendedorPagSeguro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tokenPagseguro",
                table: "Revendedor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tokenWidePay",
                table: "Revendedor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "transaction_id",
                table: "PagSeguro",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tokenPagseguro",
                table: "Revendedor");

            migrationBuilder.DropColumn(
                name: "tokenWidePay",
                table: "Revendedor");

            migrationBuilder.DropColumn(
                name: "transaction_id",
                table: "PagSeguro");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class dataVencimentoRevendedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "diaVencimento",
                table: "Revendedor",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "diaVencimento",
                table: "Revendedor");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class apagado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "apagado",
                table: "Financeiro",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "apagado",
                table: "Financeiro");
        }
    }
}

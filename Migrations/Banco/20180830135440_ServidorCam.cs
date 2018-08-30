using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class ServidorCam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "senhaCam",
                table: "Servidor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "servidorCam",
                table: "Servidor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userCam",
                table: "Servidor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "senhaCam",
                table: "Servidor");

            migrationBuilder.DropColumn(
                name: "servidorCam",
                table: "Servidor");

            migrationBuilder.DropColumn(
                name: "userCam",
                table: "Servidor");
        }
    }
}

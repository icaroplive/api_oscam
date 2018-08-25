using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class removeDataVencimentoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataVencimento",
                table: "Cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dataVencimento",
                table: "Cliente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

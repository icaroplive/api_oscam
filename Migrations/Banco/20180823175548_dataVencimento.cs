using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class dataVencimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "diaVencimento",
                table: "Cliente");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataVencimento",
                table: "Cliente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataVencimento",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "diaVencimento",
                table: "Cliente",
                nullable: false,
                defaultValue: 0);
        }
    }
}

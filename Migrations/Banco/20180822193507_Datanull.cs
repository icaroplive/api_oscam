using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class Datanull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "PagSeguro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "PagSeguro",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataVencimento",
                table: "Financeiro",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataBaixa",
                table: "Financeiro",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "PagSeguro");

            migrationBuilder.DropColumn(
                name: "token",
                table: "PagSeguro");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataVencimento",
                table: "Financeiro",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataBaixa",
                table: "Financeiro",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}

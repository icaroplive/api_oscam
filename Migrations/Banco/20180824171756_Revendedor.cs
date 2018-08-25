using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class Revendedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "origemPagamento",
                table: "Financeiro",
                newName: "origemPagamentoRevendedor");

            migrationBuilder.RenameColumn(
                name: "dataBaixa",
                table: "Financeiro",
                newName: "dataBaixaRevendedor");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataBaixaCliente",
                table: "Financeiro",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "origemPagamentoCliente",
                table: "Financeiro",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataBaixaCliente",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "origemPagamentoCliente",
                table: "Financeiro");

            migrationBuilder.RenameColumn(
                name: "origemPagamentoRevendedor",
                table: "Financeiro",
                newName: "origemPagamento");

            migrationBuilder.RenameColumn(
                name: "dataBaixaRevendedor",
                table: "Financeiro",
                newName: "dataBaixa");
        }
    }
}

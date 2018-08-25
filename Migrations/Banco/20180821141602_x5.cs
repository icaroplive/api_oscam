using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class x5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    login = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true),
                    dataCriado = table.Column<DateTime>(nullable: false),
                    diaVencimento = table.Column<int>(nullable: false),
                    valorCobrado = table.Column<decimal>(nullable: false),
                    idUser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Financeiro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    idCliente = table.Column<Guid>(nullable: false),
                    idUser = table.Column<Guid>(nullable: false),
                    valorCobrado = table.Column<decimal>(nullable: false),
                    valorLogin = table.Column<decimal>(nullable: false),
                    dataVencimento = table.Column<DateTime>(nullable: false),
                    dataBaixa = table.Column<DateTime>(nullable: false),
                    dataLancamento = table.Column<DateTime>(nullable: false),
                    origemPagamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PagSeguro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    financeiroId = table.Column<Guid>(nullable: false),
                    code_reference = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagSeguro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revendedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    idUser = table.Column<Guid>(nullable: false),
                    valorLogin = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revendedor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Financeiro");

            migrationBuilder.DropTable(
                name: "PagSeguro");

            migrationBuilder.DropTable(
                name: "Revendedor");
        }
    }
}

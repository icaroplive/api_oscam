using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations
{
    public partial class x : Migration
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
                    valorCobrado = table.Column<decimal>(nullable: false),
                    idUser = table.Column<Guid>(nullable: false),
                    ativo = table.Column<bool>(nullable: false),
                    apagado = table.Column<bool>(nullable: false),
                    dataApagado = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PagSeguro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    financeiroId = table.Column<Guid>(nullable: false),
                    code_reference = table.Column<string>(nullable: true),
                    transaction_id = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    token = table.Column<string>(nullable: true)
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
                    valorLogin = table.Column<decimal>(nullable: false),
                    emailPagseguro = table.Column<string>(nullable: true),
                    tokenPagseguro = table.Column<string>(nullable: true),
                    tokenWidePay = table.Column<string>(nullable: true),
                    diaVencimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revendedor", x => x.Id);
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
                    dataVencimento = table.Column<DateTime>(nullable: true),
                    dataBaixaCliente = table.Column<DateTime>(nullable: true),
                    dataBaixaRevendedor = table.Column<DateTime>(nullable: true),
                    dataLancamento = table.Column<DateTime>(nullable: false),
                    origemPagamentoCliente = table.Column<int>(nullable: false),
                    origemPagamentoRevendedor = table.Column<int>(nullable: false),
                    apagado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financeiro_Cliente_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_idCliente",
                table: "Financeiro",
                column: "idCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financeiro");

            migrationBuilder.DropTable(
                name: "PagSeguro");

            migrationBuilder.DropTable(
                name: "Revendedor");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}

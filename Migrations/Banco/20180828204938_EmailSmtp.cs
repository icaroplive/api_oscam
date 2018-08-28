using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class EmailSmtp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Smtp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    endereco = table.Column<string>(nullable: true),
                    porta = table.Column<int>(nullable: false),
                    sslTls = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smtp", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmailSmtp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    idUser = table.Column<Guid>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    idSmtp = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSmtp", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmailSmtp_Smtp_idSmtp",
                        column: x => x.idSmtp,
                        principalTable: "Smtp",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailSmtp_idSmtp",
                table: "EmailSmtp",
                column: "idSmtp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailSmtp");

            migrationBuilder.DropTable(
                name: "Smtp");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class ForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailSmtp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailSmtp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    Smtpid = table.Column<Guid>(nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    idSmtp = table.Column<Guid>(nullable: false),
                    idUser = table.Column<Guid>(nullable: false),
                    senha = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSmtp", x => x.id);
                    table.ForeignKey(
                        name: "FK_EmailSmtp_Smtp_Smtpid",
                        column: x => x.Smtpid,
                        principalTable: "Smtp",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailSmtp_Smtpid",
                table: "EmailSmtp",
                column: "Smtpid");
        }
    }
}

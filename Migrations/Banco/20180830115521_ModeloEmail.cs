using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class ModeloEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModeloEmail",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    titulo = table.Column<string>(maxLength: 50, nullable: true),
                    corpo = table.Column<string>(nullable: true),
                    tipo = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloEmail", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModeloEmail");
        }
    }
}

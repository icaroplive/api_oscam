using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations.Banco
{
    public partial class MaxLenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailSmtp_Smtp_idSmtp",
                table: "EmailSmtp");

            migrationBuilder.DropIndex(
                name: "IX_EmailSmtp_idSmtp",
                table: "EmailSmtp");

            migrationBuilder.AlterColumn<string>(
                name: "sslTls",
                table: "Smtp",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "endereco",
                table: "Smtp",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Smtp",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "senha",
                table: "EmailSmtp",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "EmailSmtp",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Smtpid",
                table: "EmailSmtp",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailSmtp_Smtpid",
                table: "EmailSmtp",
                column: "Smtpid");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailSmtp_Smtp_Smtpid",
                table: "EmailSmtp",
                column: "Smtpid",
                principalTable: "Smtp",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailSmtp_Smtp_Smtpid",
                table: "EmailSmtp");

            migrationBuilder.DropIndex(
                name: "IX_EmailSmtp_Smtpid",
                table: "EmailSmtp");

            migrationBuilder.DropColumn(
                name: "Smtpid",
                table: "EmailSmtp");

            migrationBuilder.AlterColumn<string>(
                name: "sslTls",
                table: "Smtp",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "endereco",
                table: "Smtp",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Smtp",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "senha",
                table: "EmailSmtp",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "EmailSmtp",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailSmtp_idSmtp",
                table: "EmailSmtp",
                column: "idSmtp");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailSmtp_Smtp_idSmtp",
                table: "EmailSmtp",
                column: "idSmtp",
                principalTable: "Smtp",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

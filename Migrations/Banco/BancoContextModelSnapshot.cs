﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.Entities;

namespace webapi.Migrations.Banco
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("webapi.Models.Cliente", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("apagado");

                    b.Property<bool>("ativo");

                    b.Property<DateTime?>("dataApagado");

                    b.Property<DateTime>("dataCriado");

                    b.Property<string>("email");

                    b.Property<Guid>("idUser");

                    b.Property<string>("login");

                    b.Property<string>("nome");

                    b.Property<string>("senha");

                    b.Property<string>("telefone");

                    b.Property<bool>("teste");

                    b.Property<decimal>("valorCobrado");

                    b.HasKey("id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("webapi.Models.Financeiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("apagado");

                    b.Property<DateTime?>("dataBaixaCliente");

                    b.Property<DateTime?>("dataBaixaRevendedor");

                    b.Property<DateTime>("dataLancamento");

                    b.Property<DateTime>("dataVencimento");

                    b.Property<Guid>("idCliente");

                    b.Property<Guid>("idUser");

                    b.Property<int>("origemPagamentoCliente");

                    b.Property<int>("origemPagamentoRevendedor");

                    b.Property<decimal>("valorCobrado");

                    b.Property<decimal>("valorLogin");

                    b.HasKey("Id");

                    b.HasIndex("idCliente");

                    b.ToTable("Financeiro");
                });

            modelBuilder.Entity("webapi.Models.LogEventos", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("data");

                    b.Property<Guid>("idUser");

                    b.Property<string>("log");

                    b.HasKey("id");

                    b.ToTable("LogEventos");
                });

            modelBuilder.Entity("webapi.Models.ModeloEmail", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("corpo");

                    b.Property<string>("tipo")
                        .HasMaxLength(20);

                    b.Property<string>("titulo")
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.ToTable("ModeloEmail");
                });

            modelBuilder.Entity("webapi.Models.PagSeguro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("code_reference");

                    b.Property<string>("email");

                    b.Property<Guid>("financeiroId");

                    b.Property<string>("token");

                    b.Property<string>("transaction_id");

                    b.HasKey("Id");

                    b.ToTable("PagSeguro");
                });

            modelBuilder.Entity("webapi.Models.Revendedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("diaVencimento");

                    b.Property<string>("emailPagseguro");

                    b.Property<string>("emailSmtp");

                    b.Property<Guid>("idSmtp");

                    b.Property<Guid>("idUser");

                    b.Property<string>("senha")
                        .HasMaxLength(100);

                    b.Property<string>("tokenPagseguro");

                    b.Property<string>("tokenWidePay");

                    b.Property<decimal>("valorLogin");

                    b.HasKey("Id");

                    b.ToTable("Revendedor");
                });

            modelBuilder.Entity("webapi.Models.Servidor", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("senhaCam");

                    b.Property<string>("servidorCam");

                    b.Property<string>("urlCam");

                    b.Property<string>("userCam");

                    b.HasKey("id");

                    b.ToTable("Servidor");
                });

            modelBuilder.Entity("webapi.Models.Smtp", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("descricao")
                        .HasMaxLength(100);

                    b.Property<string>("endereco")
                        .HasMaxLength(100);

                    b.Property<int>("porta");

                    b.Property<string>("sslTls")
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.ToTable("Smtp");
                });

            modelBuilder.Entity("webapi.Models.Financeiro", b =>
                {
                    b.HasOne("webapi.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("idCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

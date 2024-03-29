﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.Entities;

namespace webapi.Migrations.Banco
{
    [DbContext(typeof(BancoContext))]
    [Migration("20180828145355_datavencimento")]
    partial class datavencimento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid>("idUser");

                    b.Property<string>("tokenPagseguro");

                    b.Property<string>("tokenWidePay");

                    b.Property<decimal>("valorLogin");

                    b.HasKey("Id");

                    b.ToTable("Revendedor");
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

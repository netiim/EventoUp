﻿// <auto-generated />
using System;
using EventoUp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventoUp.Migrations
{
    [DbContext(typeof(EventoUpContext))]
    [Migration("20230804193335_Alterando-Capacidade-Int")]
    partial class AlterandoCapacidadeInt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EventoUp.Models.Evento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataDoEvento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("EventoUp.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}

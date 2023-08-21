﻿// <auto-generated />
using System;
using EventoUp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventoUp.Migrations
{
    [DbContext(typeof(EventoUpContext))]
    partial class EventoUpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EventoUp.Models.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventoId")
                        .IsUnique();

                    b.ToTable("Estoques", (string)null);
                });

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

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Eventos", (string)null);
                });

            modelBuilder.Entity("EventoUp.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EstoqueId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PrecoPago")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("PrecoRevenda")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("QuantidadeDisponivel")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeEstragada")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeVendida")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("EstoqueId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("EventoUp.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("EventoUp.Models.Estoque", b =>
                {
                    b.HasOne("EventoUp.Models.Evento", "Evento")
                        .WithOne("Estoque")
                        .HasForeignKey("EventoUp.Models.Estoque", "EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("EventoUp.Models.Evento", b =>
                {
                    b.HasOne("EventoUp.Models.Usuario", "UsuarioAdministrador")
                        .WithMany("EventosAdministrados")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioAdministrador");
                });

            modelBuilder.Entity("EventoUp.Models.Produto", b =>
                {
                    b.HasOne("EventoUp.Models.Estoque", "Estoque")
                        .WithMany("Produtos")
                        .HasForeignKey("EstoqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estoque");
                });

            modelBuilder.Entity("EventoUp.Models.Estoque", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("EventoUp.Models.Evento", b =>
                {
                    b.Navigation("Estoque");
                });

            modelBuilder.Entity("EventoUp.Models.Usuario", b =>
                {
                    b.Navigation("EventosAdministrados");
                });
#pragma warning restore 612, 618
        }
    }
}

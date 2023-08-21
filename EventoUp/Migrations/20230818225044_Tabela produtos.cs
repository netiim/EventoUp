using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventoUp.Migrations
{
    public partial class Tabelaprodutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Produtos_Estoques_EstoqueId",
            //    table: "Produtos");
            migrationBuilder.CreateTable(
              name: "Produtos",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                  Nome = table.Column<string>(type: "longtext", nullable: false)
                      .Annotation("MySql:CharSet", "utf8mb4"),
                  Quantidade = table.Column<int>(type: "int", nullable: false),
                  Preco = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Produtos", x => x.Id);
              })
              .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Produtos",
                newName: "QuantidadeVendida");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produtos",
                newName: "PrecoRevenda");

            migrationBuilder.AddColumn<int>(
                name: "EstoqueId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstoqueId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AlteradoEm",
                table: "Produtos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Produtos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoPago",
                table: "Produtos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDisponivel",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeEstragada",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Estoques_EstoqueId",
                table: "Produtos",
                column: "EstoqueId",
                principalTable: "Estoques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Estoques_EstoqueId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "AlteradoEm",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PrecoPago",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "QuantidadeDisponivel",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "QuantidadeEstragada",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "QuantidadeVendida",
                table: "Produtos",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "PrecoRevenda",
                table: "Produtos",
                newName: "Preco");

            migrationBuilder.AlterColumn<int>(
                name: "EstoqueId",
                table: "Produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Estoques_EstoqueId",
                table: "Produtos",
                column: "EstoqueId",
                principalTable: "Estoques",
                principalColumn: "Id");
        }
    }
}

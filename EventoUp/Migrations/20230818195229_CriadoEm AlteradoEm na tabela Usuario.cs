using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventoUp.Migrations
{
    public partial class CriadoEmAlteradoEmnatabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AlteradoEm",
                table: "Usuarios",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Usuarios",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlteradoEm",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Usuarios");
        }
    }
}

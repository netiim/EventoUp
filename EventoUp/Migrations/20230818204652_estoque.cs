using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventoUp.Migrations
{
    public partial class estoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Eventos_EventoId",
                table: "Estoque");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque");

            migrationBuilder.RenameTable(
                name: "Estoque",
                newName: "Estoques");

            migrationBuilder.RenameIndex(
                name: "IX_Estoque_EventoId",
                table: "Estoques",
                newName: "IX_Estoques_EventoId");

            migrationBuilder.AddColumn<int>(
                name: "EstoqueId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estoques",
                table: "Estoques",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EstoqueId",
                table: "Produtos",
                column: "EstoqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Eventos_EventoId",
                table: "Estoques",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Estoques_EstoqueId",
                table: "Produtos",
                column: "EstoqueId",
                principalTable: "Estoques",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Eventos_EventoId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Estoques_EstoqueId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_EstoqueId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estoques",
                table: "Estoques");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Estoques",
                newName: "Estoque");

            migrationBuilder.RenameIndex(
                name: "IX_Estoques_EventoId",
                table: "Estoque",
                newName: "IX_Estoque_EventoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estoque",
                table: "Estoque",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Eventos_EventoId",
                table: "Estoque",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

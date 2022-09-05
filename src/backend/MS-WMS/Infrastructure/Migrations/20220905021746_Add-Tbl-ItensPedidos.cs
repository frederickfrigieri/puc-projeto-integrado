using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddTblItensPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Armazens_ArmazemId",
                table: "Itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Produtos_ProdutoId",
                table: "Itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Itens_ItemPedidoId",
                schema: "WMS",
                table: "Estoques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Itens",
                table: "Itens");

            migrationBuilder.EnsureSchema(
                name: "OMS");

            migrationBuilder.RenameTable(
                name: "Itens",
                newName: "ItensPedidos",
                newSchema: "OMS");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_ProdutoId",
                schema: "OMS",
                table: "ItensPedidos",
                newName: "IX_ItensPedidos_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Itens_ArmazemId",
                schema: "OMS",
                table: "ItensPedidos",
                newName: "IX_ItensPedidos_ArmazemId");

            migrationBuilder.AlterColumn<byte>(
                name: "Quantidade",
                schema: "OMS",
                table: "ItensPedidos",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensPedidos",
                schema: "OMS",
                table: "ItensPedidos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Armazens_ArmazemId",
                schema: "OMS",
                table: "ItensPedidos",
                column: "ArmazemId",
                principalSchema: "WMS",
                principalTable: "Armazens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedidos_Produtos_ProdutoId",
                schema: "OMS",
                table: "ItensPedidos",
                column: "ProdutoId",
                principalSchema: "WMS",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_ItensPedidos_ItemPedidoId",
                schema: "WMS",
                table: "Estoques",
                column: "ItemPedidoId",
                principalSchema: "OMS",
                principalTable: "ItensPedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Armazens_ArmazemId",
                schema: "OMS",
                table: "ItensPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedidos_Produtos_ProdutoId",
                schema: "OMS",
                table: "ItensPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_ItensPedidos_ItemPedidoId",
                schema: "WMS",
                table: "Estoques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensPedidos",
                schema: "OMS",
                table: "ItensPedidos");

            migrationBuilder.RenameTable(
                name: "ItensPedidos",
                schema: "OMS",
                newName: "Itens");

            migrationBuilder.RenameIndex(
                name: "IX_ItensPedidos_ProdutoId",
                table: "Itens",
                newName: "IX_Itens_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensPedidos_ArmazemId",
                table: "Itens",
                newName: "IX_Itens_ArmazemId");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Itens",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Itens",
                table: "Itens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Armazens_ArmazemId",
                table: "Itens",
                column: "ArmazemId",
                principalSchema: "WMS",
                principalTable: "Armazens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Produtos_ProdutoId",
                table: "Itens",
                column: "ProdutoId",
                principalSchema: "WMS",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Itens_ItemPedidoId",
                schema: "WMS",
                table: "Estoques",
                column: "ItemPedidoId",
                principalTable: "Itens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemoverPropriedadeQuantidadeEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                schema: "WMS",
                table: "Estoques");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                schema: "WMS",
                table: "Estoques",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

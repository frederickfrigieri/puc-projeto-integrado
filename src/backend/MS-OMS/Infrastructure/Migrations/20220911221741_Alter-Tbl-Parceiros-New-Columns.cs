using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AlterTblParceirosNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChaveBling",
                schema: "OMS",
                table: "Parceiros",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "OMS",
                table: "Parceiros",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                schema: "OMS",
                table: "Parceiros",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                schema: "OMS",
                table: "Parceiros",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChaveBling",
                schema: "OMS",
                table: "Parceiros");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "OMS",
                table: "Parceiros");

            migrationBuilder.DropColumn(
                name: "Nome",
                schema: "OMS",
                table: "Parceiros");

            migrationBuilder.DropColumn(
                name: "Senha",
                schema: "OMS",
                table: "Parceiros");
        }
    }
}

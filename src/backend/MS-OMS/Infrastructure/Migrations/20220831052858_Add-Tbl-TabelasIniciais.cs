using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddTblTabelasIniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OMS");

            migrationBuilder.EnsureSchema(
                name: "WMS");

            migrationBuilder.EnsureSchema(
                name: "Jobs");

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                schema: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OccurredOn = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(unicode: false, maxLength: 8000, nullable: true),
                    Data = table.Column<string>(unicode: false, maxLength: 8000, nullable: true),
                    ProcessedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parceiros",
                schema: "OMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chave = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(14)", maxLength: 256, nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parceiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                schema: "OMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chave = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(100)", maxLength: 256, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,12)", nullable: false),
                    ParceiroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Parceiros_ParceiroId",
                        column: x => x.ParceiroId,
                        principalSchema: "OMS",
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                schema: "WMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chave = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", maxLength: 256, nullable: false),
                    Sku = table.Column<string>(type: "varchar(13)", maxLength: 256, nullable: false),
                    ParceiroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Parceiros_ParceiroId",
                        column: x => x.ParceiroId,
                        principalSchema: "OMS",
                        principalTable: "Parceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                schema: "OMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chave = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<byte>(type: "tinyint", nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    PedidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalSchema: "OMS",
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalSchema: "WMS",
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoId",
                schema: "OMS",
                table: "ItensPedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_ProdutoId",
                schema: "OMS",
                table: "ItensPedidos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ParceiroId",
                schema: "OMS",
                table: "Pedidos",
                column: "ParceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ParceiroId",
                schema: "WMS",
                table: "Produtos",
                column: "ParceiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutboxMessages",
                schema: "Jobs");

            migrationBuilder.DropTable(
                name: "ItensPedidos",
                schema: "OMS");

            migrationBuilder.DropTable(
                name: "Pedidos",
                schema: "OMS");

            migrationBuilder.DropTable(
                name: "Produtos",
                schema: "WMS");

            migrationBuilder.DropTable(
                name: "Parceiros",
                schema: "OMS");
        }
    }
}

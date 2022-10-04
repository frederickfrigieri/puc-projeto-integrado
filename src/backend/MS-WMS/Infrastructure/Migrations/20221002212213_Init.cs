using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WMS");

            migrationBuilder.CreateTable(
                name: "Armazens",
                schema: "WMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chave = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armazens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalCommands",
                schema: "WMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OccurredOn = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(type: "Varchar(250)", maxLength: 8000, nullable: true),
                    Data = table.Column<string>(type: "Varchar(Max)", maxLength: 8000, nullable: true),
                    ProcessedDate = table.Column<DateTime>(nullable: true),
                    Executando = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                schema: "WMS",
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
                    ChaveParceiro = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posicoes",
                schema: "WMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chave = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Letra = table.Column<string>(maxLength: 256, nullable: true),
                    ArmazemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posicoes_Armazens_ArmazemId",
                        column: x => x.ArmazemId,
                        principalSchema: "WMS",
                        principalTable: "Armazens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                schema: "WMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chave = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<byte>(type: "tinyint", nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    ChavePedido = table.Column<Guid>(nullable: false),
                    ChaveParceiro = table.Column<Guid>(nullable: false),
                    ArmazemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Armazens_ArmazemId",
                        column: x => x.ArmazemId,
                        principalSchema: "WMS",
                        principalTable: "Armazens",
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

            migrationBuilder.CreateTable(
                name: "Estoques",
                schema: "WMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chave = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    ChaveParceiro = table.Column<Guid>(nullable: false),
                    ArmazemId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    PedidoItemId = table.Column<int>(nullable: true),
                    PosicaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoques_Armazens_ArmazemId",
                        column: x => x.ArmazemId,
                        principalSchema: "WMS",
                        principalTable: "Armazens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estoques_ItensPedidos_PedidoItemId",
                        column: x => x.PedidoItemId,
                        principalSchema: "WMS",
                        principalTable: "ItensPedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estoques_Posicoes_PosicaoId",
                        column: x => x.PosicaoId,
                        principalSchema: "WMS",
                        principalTable: "Posicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estoques_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalSchema: "WMS",
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_ArmazemId",
                schema: "WMS",
                table: "Estoques",
                column: "ArmazemId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_PedidoItemId",
                schema: "WMS",
                table: "Estoques",
                column: "PedidoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_PosicaoId",
                schema: "WMS",
                table: "Estoques",
                column: "PosicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_ProdutoId",
                schema: "WMS",
                table: "Estoques",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_ArmazemId",
                schema: "WMS",
                table: "ItensPedidos",
                column: "ArmazemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_ProdutoId",
                schema: "WMS",
                table: "ItensPedidos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Posicoes_ArmazemId",
                schema: "WMS",
                table: "Posicoes",
                column: "ArmazemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoques",
                schema: "WMS");

            migrationBuilder.DropTable(
                name: "InternalCommands",
                schema: "WMS");

            migrationBuilder.DropTable(
                name: "OutboxMessages",
                schema: "WMS");

            migrationBuilder.DropTable(
                name: "ItensPedidos",
                schema: "WMS");

            migrationBuilder.DropTable(
                name: "Posicoes",
                schema: "WMS");

            migrationBuilder.DropTable(
                name: "Produtos",
                schema: "WMS");

            migrationBuilder.DropTable(
                name: "Armazens",
                schema: "WMS");
        }
    }
}

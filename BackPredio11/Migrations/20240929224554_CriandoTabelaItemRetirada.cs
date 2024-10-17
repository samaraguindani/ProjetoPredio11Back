using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaItemRetirada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItensRetirada",
                columns: table => new
                {
                    RetiradaId = table.Column<long>(type: "bigint", nullable: false),
                    BemId = table.Column<long>(type: "bigint", nullable: false),
                    QuantidadeBem = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensRetirada", x => new { x.RetiradaId, x.BemId });
                    table.ForeignKey(
                        name: "FK_ItensRetirada_Bem_BemId",
                        column: x => x.BemId,
                        principalTable: "Item",
                        principalColumn: "BemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensRetirada_Retiradas_RetiradaId",
                        column: x => x.RetiradaId,
                        principalTable: "Retiradas",
                        principalColumn: "RetiradaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensRetirada_BemId",
                table: "ItensRetirada",
                column: "BemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensRetirada");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoTabelasMediadoras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensReserva");

            migrationBuilder.DropTable(
                name: "ItensRetirada");

            migrationBuilder.AddColumn<long>(
                name: "BemId",
                table: "Retiradas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BemId",
                table: "Reservas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Retiradas_BemId",
                table: "Retiradas",
                column: "BemId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_BemId",
                table: "Reservas",
                column: "BemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Bem_BemId",
                table: "Reservas",
                column: "BemId",
                principalTable: "Item",
                principalColumn: "BemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Retiradas_Bem_BemId",
                table: "Retiradas",
                column: "BemId",
                principalTable: "Item",
                principalColumn: "BemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Bem_BemId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Retiradas_Bem_BemId",
                table: "Retiradas");

            migrationBuilder.DropIndex(
                name: "IX_Retiradas_BemId",
                table: "Retiradas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_BemId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "BemId",
                table: "Retiradas");

            migrationBuilder.DropColumn(
                name: "BemId",
                table: "Reservas");

            migrationBuilder.CreateTable(
                name: "ItensReserva",
                columns: table => new
                {
                    BemId = table.Column<long>(type: "bigint", nullable: false),
                    ReservaId = table.Column<long>(type: "bigint", nullable: false),
                    QuantidadeBem = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensReserva", x => new { x.BemId, x.ReservaId });
                    table.ForeignKey(
                        name: "FK_ItensReserva_Bem_BemId",
                        column: x => x.BemId,
                        principalTable: "Item",
                        principalColumn: "BemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensReserva_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_ItensReserva_ReservaId",
                table: "ItensReserva",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensRetirada_BemId",
                table: "ItensRetirada",
                column: "BemId");
        }
    }
}

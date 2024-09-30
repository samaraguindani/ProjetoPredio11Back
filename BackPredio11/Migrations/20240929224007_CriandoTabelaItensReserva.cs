using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaItensReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        principalTable: "Bem",
                        principalColumn: "BemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensReserva_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensReserva_ReservaId",
                table: "ItensReserva",
                column: "ReservaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensReserva");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelasBemTipoBemStatusBem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusItem",
                columns: table => new
                {
                    StatusBemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusNome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusBem", x => x.StatusBemId);
                });

            migrationBuilder.CreateTable(
                name: "TipoItem",
                columns: table => new
                {
                    TipoBemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoNome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoBem", x => x.TipoBemId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    BemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BemDescricao = table.Column<string>(type: "text", nullable: false),
                    BemPermitido = table.Column<int>(type: "integer", nullable: false),
                    StatusBemId = table.Column<long>(type: "bigint", nullable: false),
                    TipoBemId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bem", x => x.BemId);
                    table.ForeignKey(
                        name: "FK_Bem_StatusBem_StatusBemId",
                        column: x => x.StatusBemId,
                        principalTable: "StatusItem",
                        principalColumn: "StatusBemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bem_TipoBem_TipoBemId",
                        column: x => x.TipoBemId,
                        principalTable: "TipoItem",
                        principalColumn: "TipoBemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bem_StatusBemId",
                table: "Item",
                column: "StatusBemId");

            migrationBuilder.CreateIndex(
                name: "IX_Bem_TipoBemId",
                table: "Item",
                column: "TipoBemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "StatusItem");

            migrationBuilder.DropTable(
                name: "TipoItem");
        }
    }
}

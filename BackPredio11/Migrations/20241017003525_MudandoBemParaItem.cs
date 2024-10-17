using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class MudandoBemParaItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Bem_BemId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Retiradas_Bem_BemId",
                table: "Retiradas");

            migrationBuilder.DropTable(
                name: "Bem");

            migrationBuilder.DropTable(
                name: "StatusBem");

            migrationBuilder.DropTable(
                name: "TipoBem");

            migrationBuilder.DropIndex(
                name: "IX_Retiradas_BemId",
                table: "Retiradas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_BemId",
                table: "Reservas");

            migrationBuilder.AddColumn<long>(
                name: "ItemId",
                table: "Retiradas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ItemId",
                table: "Reservas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "StatusItems",
                columns: table => new
                {
                    StatusItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemDescricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusItems", x => x.StatusItemId);
                });

            migrationBuilder.CreateTable(
                name: "TipoItems",
                columns: table => new
                {
                    TipoItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemDescricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoItems", x => x.TipoItemId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemDescricao = table.Column<string>(type: "text", nullable: false),
                    ItemPermitido = table.Column<int>(type: "integer", nullable: false),
                    StatusItemId = table.Column<long>(type: "bigint", nullable: false),
                    TipoItemId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_StatusItems_StatusItemId",
                        column: x => x.StatusItemId,
                        principalTable: "StatusItems",
                        principalColumn: "StatusItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_TipoItems_TipoItemId",
                        column: x => x.TipoItemId,
                        principalTable: "TipoItems",
                        principalColumn: "TipoItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Retiradas_ItemId",
                table: "Retiradas",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ItemId",
                table: "Reservas",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_StatusItemId",
                table: "Items",
                column: "StatusItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TipoItemId",
                table: "Items",
                column: "TipoItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Items_ItemId",
                table: "Reservas",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Retiradas_Items_ItemId",
                table: "Retiradas",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Items_ItemId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Retiradas_Items_ItemId",
                table: "Retiradas");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "StatusItems");

            migrationBuilder.DropTable(
                name: "TipoItems");

            migrationBuilder.DropIndex(
                name: "IX_Retiradas_ItemId",
                table: "Retiradas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_ItemId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Retiradas");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Reservas");

            migrationBuilder.CreateTable(
                name: "StatusBem",
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
                name: "TipoBem",
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
                name: "Bem",
                columns: table => new
                {
                    BemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusBemId = table.Column<long>(type: "bigint", nullable: false),
                    TipoBemId = table.Column<long>(type: "bigint", nullable: false),
                    BemDescricao = table.Column<string>(type: "text", nullable: false),
                    BemPermitido = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bem", x => x.BemId);
                    table.ForeignKey(
                        name: "FK_Bem_StatusBem_StatusBemId",
                        column: x => x.StatusBemId,
                        principalTable: "StatusBem",
                        principalColumn: "StatusBemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bem_TipoBem_TipoBemId",
                        column: x => x.TipoBemId,
                        principalTable: "TipoBem",
                        principalColumn: "TipoBemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Retiradas_BemId",
                table: "Retiradas",
                column: "BemId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_BemId",
                table: "Reservas",
                column: "BemId");

            migrationBuilder.CreateIndex(
                name: "IX_Bem_StatusBemId",
                table: "Bem",
                column: "StatusBemId");

            migrationBuilder.CreateIndex(
                name: "IX_Bem_TipoBemId",
                table: "Bem",
                column: "TipoBemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Bem_BemId",
                table: "Reservas",
                column: "BemId",
                principalTable: "Bem",
                principalColumn: "BemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Retiradas_Bem_BemId",
                table: "Retiradas",
                column: "BemId",
                principalTable: "Bem",
                principalColumn: "BemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

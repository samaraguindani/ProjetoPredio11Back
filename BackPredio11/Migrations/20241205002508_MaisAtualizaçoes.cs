using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class MaisAtualizaçoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_StatusItems_StatusItemId1",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_TipoItems_TipoItemId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "StatusItems");

            migrationBuilder.DropTable(
                name: "TipoItems");

            migrationBuilder.DropIndex(
                name: "IX_Items_StatusItemId1",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_TipoItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StatusItemId1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TipoItemId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StatusItemId1",
                table: "Items",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipoItemId",
                table: "Items",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Items_StatusItemId1",
                table: "Items",
                column: "StatusItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TipoItemId",
                table: "Items",
                column: "TipoItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_StatusItems_StatusItemId1",
                table: "Items",
                column: "StatusItemId1",
                principalTable: "StatusItems",
                principalColumn: "StatusItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_TipoItems_TipoItemId",
                table: "Items",
                column: "TipoItemId",
                principalTable: "TipoItems",
                principalColumn: "TipoItemId");
        }
    }
}

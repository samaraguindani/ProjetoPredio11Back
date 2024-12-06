using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoTabelasDiversas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_StatusItems_StatusItemId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_TipoItems_TipoItemId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_StatusItemId",
                table: "Items");

            migrationBuilder.AlterColumn<long>(
                name: "TipoItemId",
                table: "Items",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "StatusItemId",
                table: "Items",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeItem",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "StatusItemId1",
                table: "Items",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoItem",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Items_StatusItemId1",
                table: "Items",
                column: "StatusItemId1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_StatusItems_StatusItemId1",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_TipoItems_TipoItemId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_StatusItemId1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "QuantidadeItem",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StatusItemId1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TipoItem",
                table: "Items");

            migrationBuilder.AlterColumn<long>(
                name: "TipoItemId",
                table: "Items",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StatusItemId",
                table: "Items",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Items_StatusItemId",
                table: "Items",
                column: "StatusItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_StatusItems_StatusItemId",
                table: "Items",
                column: "StatusItemId",
                principalTable: "StatusItems",
                principalColumn: "StatusItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_TipoItems_TipoItemId",
                table: "Items",
                column: "TipoItemId",
                principalTable: "TipoItems",
                principalColumn: "TipoItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

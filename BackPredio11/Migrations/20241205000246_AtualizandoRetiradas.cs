using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoRetiradas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Retiradas_Motivos_MotivoRetiradaId",
                table: "Retiradas");

            migrationBuilder.DropTable(
                name: "Motivos");

            migrationBuilder.DropIndex(
                name: "IX_Retiradas_MotivoRetiradaId",
                table: "Retiradas");

            migrationBuilder.DropColumn(
                name: "MotivoRetiradaId",
                table: "Retiradas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MotivoRetiradaId",
                table: "Retiradas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Motivos",
                columns: table => new
                {
                    MotivoRetiradaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MotivoDescricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivos", x => x.MotivoRetiradaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Retiradas_MotivoRetiradaId",
                table: "Retiradas",
                column: "MotivoRetiradaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Retiradas_Motivos_MotivoRetiradaId",
                table: "Retiradas",
                column: "MotivoRetiradaId",
                principalTable: "Motivos",
                principalColumn: "MotivoRetiradaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

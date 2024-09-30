using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaRetiradas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Retiradas",
                columns: table => new
                {
                    RetiradaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RetiradaData = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DevolucaoData = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LimiteData = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuantidadeBem = table.Column<int>(type: "integer", nullable: false),
                    RetiradaDescricao = table.Column<string>(type: "text", nullable: false),
                    MotivoRetiradaId = table.Column<long>(type: "bigint", nullable: false),
                    PessoaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retiradas", x => x.RetiradaId);
                    table.ForeignKey(
                        name: "FK_Retiradas_Motivos_MotivoRetiradaId",
                        column: x => x.MotivoRetiradaId,
                        principalTable: "Motivos",
                        principalColumn: "MotivoRetiradaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retiradas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Retiradas_MotivoRetiradaId",
                table: "Retiradas",
                column: "MotivoRetiradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Retiradas_PessoaId",
                table: "Retiradas",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Retiradas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoColunaPessoaUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Pessoas_PessoaId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_PessoaId",
                table: "Reservas");

            migrationBuilder.AddColumn<string>(
                name: "PessoaUsername",
                table: "Pessoas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PessoaUsername",
                table: "Pessoas");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PessoaId",
                table: "Reservas",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Pessoas_PessoaId",
                table: "Reservas",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

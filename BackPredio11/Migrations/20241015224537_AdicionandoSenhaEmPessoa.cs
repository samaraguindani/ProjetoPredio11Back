using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoSenhaEmPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PessoaSenha",
                table: "Pessoas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PessoaSenha",
                table: "Pessoas");
        }
    }
}

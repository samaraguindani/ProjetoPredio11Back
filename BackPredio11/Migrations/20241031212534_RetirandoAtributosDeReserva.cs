﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackPredio11.Migrations
{
    /// <inheritdoc />
    public partial class RetirandoAtributosDeReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Items_ItemId",
                table: "Reservas");

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "Reservas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Items_ItemId",
                table: "Reservas",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Items_ItemId",
                table: "Reservas");

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "Reservas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Items_ItemId",
                table: "Reservas",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

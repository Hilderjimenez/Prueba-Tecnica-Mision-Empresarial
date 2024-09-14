using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMercancías_JyC.Migrations
{
    /// <inheritdoc />
    public partial class AddFechaPedidoAndFechaEntrega : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPedido",
                table: "Pedidos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEntrega",
                table: "Pedidos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPedido",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaEntrega",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}

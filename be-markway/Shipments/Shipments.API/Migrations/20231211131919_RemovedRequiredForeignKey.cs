using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipments.API.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRequiredForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentCustoms_ShipmentsRoutes_RouteId",
                table: "ShipmentCustoms");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentLoadOnLocations_ShipmentsRoutes_RouteId",
                table: "ShipmentLoadOnLocations");

            migrationBuilder.AlterColumn<long>(
                name: "RouteId",
                table: "ShipmentLoadOnLocations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "RouteId",
                table: "ShipmentCustoms",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentCustoms_ShipmentsRoutes_RouteId",
                table: "ShipmentCustoms",
                column: "RouteId",
                principalTable: "ShipmentsRoutes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentLoadOnLocations_ShipmentsRoutes_RouteId",
                table: "ShipmentLoadOnLocations",
                column: "RouteId",
                principalTable: "ShipmentsRoutes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentCustoms_ShipmentsRoutes_RouteId",
                table: "ShipmentCustoms");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentLoadOnLocations_ShipmentsRoutes_RouteId",
                table: "ShipmentLoadOnLocations");

            migrationBuilder.AlterColumn<long>(
                name: "RouteId",
                table: "ShipmentLoadOnLocations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RouteId",
                table: "ShipmentCustoms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentCustoms_ShipmentsRoutes_RouteId",
                table: "ShipmentCustoms",
                column: "RouteId",
                principalTable: "ShipmentsRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentLoadOnLocations_ShipmentsRoutes_RouteId",
                table: "ShipmentLoadOnLocations",
                column: "RouteId",
                principalTable: "ShipmentsRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

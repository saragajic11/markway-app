using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipments.API.Migrations
{
    /// <inheritdoc />
    public partial class Removedrequiredforeignkeyinshipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentsRoutes_Shipments_ShipmentId",
                table: "ShipmentsRoutes");

            migrationBuilder.AlterColumn<long>(
                name: "ShipmentId",
                table: "ShipmentsRoutes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentsRoutes_Shipments_ShipmentId",
                table: "ShipmentsRoutes",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentsRoutes_Shipments_ShipmentId",
                table: "ShipmentsRoutes");

            migrationBuilder.AlterColumn<long>(
                name: "ShipmentId",
                table: "ShipmentsRoutes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentsRoutes_Shipments_ShipmentId",
                table: "ShipmentsRoutes",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipments.API.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableShipmentRouteAndLoadOnLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Notes_NoteId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_NoteId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "MerchAmount",
                table: "Shipments");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "ShipmentsRoutes",
                newName: "OutcomeCurrency");

            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Shipments",
                newName: "ExternalId");

            migrationBuilder.RenameColumn(
                name: "Merch",
                table: "Shipments",
                newName: "IncomeCurrency");

            migrationBuilder.AddColumn<long>(
                name: "DateOfPayment",
                table: "ShipmentsRoutes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "NoteId",
                table: "ShipmentsRoutes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Merch",
                table: "ShipmentLoadOnLocations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MerchAmount",
                table: "ShipmentLoadOnLocations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentsRoutes_NoteId",
                table: "ShipmentsRoutes",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentsRoutes_Notes_NoteId",
                table: "ShipmentsRoutes",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentsRoutes_Notes_NoteId",
                table: "ShipmentsRoutes");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentsRoutes_NoteId",
                table: "ShipmentsRoutes");

            migrationBuilder.DropColumn(
                name: "DateOfPayment",
                table: "ShipmentsRoutes");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "ShipmentsRoutes");

            migrationBuilder.DropColumn(
                name: "Merch",
                table: "ShipmentLoadOnLocations");

            migrationBuilder.DropColumn(
                name: "MerchAmount",
                table: "ShipmentLoadOnLocations");

            migrationBuilder.RenameColumn(
                name: "OutcomeCurrency",
                table: "ShipmentsRoutes",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "IncomeCurrency",
                table: "Shipments",
                newName: "Merch");

            migrationBuilder.RenameColumn(
                name: "ExternalId",
                table: "Shipments",
                newName: "NoteId");

            migrationBuilder.AddColumn<long>(
                name: "MerchAmount",
                table: "Shipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_NoteId",
                table: "Shipments",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Notes_NoteId",
                table: "Shipments",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

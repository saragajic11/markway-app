using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipments.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShipmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BorderCrossingId",
                table: "Shipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CarrierId",
                table: "Shipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "Shipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "NoteId",
                table: "Shipments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_BorderCrossingId",
                table: "Shipments",
                column: "BorderCrossingId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CarrierId",
                table: "Shipments",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CustomerId",
                table: "Shipments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_NoteId",
                table: "Shipments",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_BorderCrossings_BorderCrossingId",
                table: "Shipments",
                column: "BorderCrossingId",
                principalTable: "BorderCrossings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Carriers_CarrierId",
                table: "Shipments",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Customers_CustomerId",
                table: "Shipments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Notes_NoteId",
                table: "Shipments",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_BorderCrossings_BorderCrossingId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Carriers_CarrierId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Customers_CustomerId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Notes_NoteId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_BorderCrossingId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_CarrierId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_CustomerId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_NoteId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "BorderCrossingId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Shipments");
        }
    }
}

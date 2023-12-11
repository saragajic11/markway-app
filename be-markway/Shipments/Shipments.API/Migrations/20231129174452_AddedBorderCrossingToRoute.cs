using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipments.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedBorderCrossingToRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BorderCrossingId",
                table: "ShipmentsRoutes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentsRoutes_BorderCrossingId",
                table: "ShipmentsRoutes",
                column: "BorderCrossingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentsRoutes_BorderCrossings_BorderCrossingId",
                table: "ShipmentsRoutes",
                column: "BorderCrossingId",
                principalTable: "BorderCrossings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentsRoutes_BorderCrossings_BorderCrossingId",
                table: "ShipmentsRoutes");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentsRoutes_BorderCrossingId",
                table: "ShipmentsRoutes");

            migrationBuilder.DropColumn(
                name: "BorderCrossingId",
                table: "ShipmentsRoutes");
        }
    }
}

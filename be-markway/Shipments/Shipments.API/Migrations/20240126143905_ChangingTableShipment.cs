using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipments.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTableShipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ShipmentsRoutes");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Shipments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Shipments");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ShipmentsRoutes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

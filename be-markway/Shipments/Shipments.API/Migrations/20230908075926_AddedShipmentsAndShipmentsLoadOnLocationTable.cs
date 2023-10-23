using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shipments.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedShipmentsAndShipmentsLoadOnLocationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Merch = table.Column<string>(type: "text", nullable: false),
                    MerchAmount = table.Column<long>(type: "bigint", nullable: false),
                    VehicleType = table.Column<string>(type: "text", nullable: false),
                    LicencePlate = table.Column<string>(type: "text", nullable: false),
                    Income = table.Column<long>(type: "bigint", nullable: false),
                    Outcome = table.Column<long>(type: "bigint", nullable: false),
                    Profit = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentLoadOnLocations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    ShipmentId = table.Column<long>(type: "bigint", nullable: false),
                    LoadOnLocationId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentLoadOnLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentLoadOnLocations_LoadOnLocations_LoadOnLocationId",
                        column: x => x.LoadOnLocationId,
                        principalTable: "LoadOnLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentLoadOnLocations_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLoadOnLocations_LoadOnLocationId",
                table: "ShipmentLoadOnLocations",
                column: "LoadOnLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentLoadOnLocations_ShipmentId",
                table: "ShipmentLoadOnLocations",
                column: "ShipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipmentLoadOnLocations");

            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}

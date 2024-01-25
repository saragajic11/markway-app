using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipments.API.Migrations
{
    /// <inheritdoc />
    public partial class AlteredCustomerAndCarrierTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DateOfPayment",
                table: "Customers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Carriers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Carriers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Carriers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Iban",
                table: "Carriers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                table: "Carriers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Carriers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pib",
                table: "Carriers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Swift",
                table: "Carriers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfPayment",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "Iban",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "Pib",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "Swift",
                table: "Carriers");
        }
    }
}

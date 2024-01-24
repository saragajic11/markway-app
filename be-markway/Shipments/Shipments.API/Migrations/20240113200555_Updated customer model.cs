using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipments.API.Migrations
{
    /// <inheritdoc />
    public partial class Updatedcustomermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Iban",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pib",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Swift",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Iban",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Pib",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Swift",
                table: "Customers");
        }
    }
}

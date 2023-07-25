using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedColumnNameCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Property",
                table: "Customers",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "Property");
        }
    }
}

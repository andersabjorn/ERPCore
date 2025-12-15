using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPCore.ConsoleUI.Migrations
{
    /// <inheritdoc />
    public partial class RenameCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNUmber",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customers",
                newName: "PhoneNUmber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Customers",
                newName: "Name");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthCustomerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNameToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEN+7XeYOTXm5tmR0j4+JIvKNn6yhMmzBAwuquNjWh8EMJ+qkRHwEvhHn4jZz7bYWcQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJvUCvb0pBKQSm5oV2GpJWT5L9Zwc/i6Rh2LVi/7Vp11V6B5JlO0b+PkS8MR9ospaw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIyJbcUmFk/Glu6A25BILfVzZJA8LUagiXmBWee3IxLz+oWYvGBqL8pHCPaWVoa6HQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDEOgCFvlgHAN/NkmIp/dlMdL4TVBD4sptMtWHI365lj9WXJ/SaK4tL5uYxCcV/MOQ==");
        }
    }
}

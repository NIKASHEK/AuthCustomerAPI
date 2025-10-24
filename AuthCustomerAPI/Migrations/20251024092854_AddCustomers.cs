using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuthCustomerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone", "UserName" },
                values: new object[,]
                {
                    { 1, "test@example.com", "Test", "User", "555-123456", "user" },
                    { 2, "admin@example.com", "Admin", "Customer", "555-654321", "admin" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMdIWGKVlWQUSASv9P0iuBq1lIf9VfUP5dM0eToicRDyWauao0MBpSYMyLlbVzYSMg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHWQ7MX2zG7fFKVdA6MYsfvPaM841qR92UkKrE5UUTwSR/LMgUjsarvmHl6O+0al3w==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

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
    }
}

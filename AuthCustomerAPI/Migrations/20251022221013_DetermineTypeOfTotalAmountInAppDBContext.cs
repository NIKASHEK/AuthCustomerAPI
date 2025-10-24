using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthCustomerAPI.Migrations
{
    /// <inheritdoc />
    public partial class DetermineTypeOfTotalAmountInAppDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEETBjnUXFGX6T/zLzA32KEWr7PRKfHw8IRjrwMAnxdQTLud9FjKy4pqaE6c8b19muA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENpsuY1Ib/Gvmq3RzPb6bqZCmxZyQoB70M4Bv/taktlmYSU6cFPaMVinDCEBtiGXng==");
        }
    }
}

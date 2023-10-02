using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class orderedproductdto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterdDate", "SecurityStamp" },
                values: new object[] { "48ea8993-3445-4e28-8a67-98934d364784", "AQAAAAIAAYagAAAAEAn+6K1wKRnyfXKpDBeoZCDu+qwIRPFPcc2KJ4L2PHNlZr4iiYJ/JorER8uTk20ONA==", "29/08/2023 07:28:02 AM", "30329207-f1f1-4614-8dfd-8d22e9ce18fa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterdDate", "SecurityStamp" },
                values: new object[] { "a461dde6-b1c2-45a4-aafc-91364a11ce32", "AQAAAAIAAYagAAAAEFYvchsUN5wfc1aHy7gAHZFTDkVrjSIMEcG9kj9VtDL8dm3Mvpe3CAzwbFUFozzW0g==", "29/08/2023 04:46:43 AM", "cd560510-96b8-48ce-82c1-31c86cc3740d" });
        }
    }
}

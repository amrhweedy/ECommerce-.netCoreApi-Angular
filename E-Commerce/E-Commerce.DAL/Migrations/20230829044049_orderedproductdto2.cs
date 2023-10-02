using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class orderedproductdto2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterdDate", "SecurityStamp" },
                values: new object[] { "60c11ff7-2fc2-4009-b029-137080105601", "AQAAAAIAAYagAAAAEJCgVCIOK+tKC6++IIwm/1bAe7z9WOhaTA1Xs5NyeF3Iwuv845sXpTdYhQFrnhFZmg==", "29/08/2023 07:40:49 AM", "555860e2-805e-4420-8443-701a9a82fde3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterdDate", "SecurityStamp" },
                values: new object[] { "48ea8993-3445-4e28-8a67-98934d364784", "AQAAAAIAAYagAAAAEAn+6K1wKRnyfXKpDBeoZCDu+qwIRPFPcc2KJ4L2PHNlZr4iiYJ/JorER8uTk20ONA==", "29/08/2023 07:28:02 AM", "30329207-f1f1-4614-8dfd-8d22e9ce18fa" });
        }
    }
}

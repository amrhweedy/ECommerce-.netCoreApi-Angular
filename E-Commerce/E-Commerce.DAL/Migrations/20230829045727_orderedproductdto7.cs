using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class orderedproductdto7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deliveryType",
                table: "deliveryMethods");

            migrationBuilder.RenameColumn(
                name: "shortName",
                table: "deliveryMethods",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterdDate", "SecurityStamp" },
                values: new object[] { "8dd4e06b-5d40-4fe2-a6a2-0b14170bc96e", "AQAAAAIAAYagAAAAEKWedVqtOuuTn7Rh9TJ+N6/RF29e6YJ4NdK6pmtKfZtmlChJFTmav4fZHiK3ytbkdg==", "29/08/2023 07:57:26 AM", "811ea1b6-f4b2-4ed4-afa3-83964aeffafb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "deliveryMethods",
                newName: "shortName");

            migrationBuilder.AddColumn<string>(
                name: "deliveryType",
                table: "deliveryMethods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegisterdDate", "SecurityStamp" },
                values: new object[] { "60c11ff7-2fc2-4009-b029-137080105601", "AQAAAAIAAYagAAAAEJCgVCIOK+tKC6++IIwm/1bAe7z9WOhaTA1Xs5NyeF3Iwuv845sXpTdYhQFrnhFZmg==", "29/08/2023 07:40:49 AM", "555860e2-805e-4420-8443-701a9a82fde3" });
        }
    }
}

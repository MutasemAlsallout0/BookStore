using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class AddingCreatedAtCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BookSuggestions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "704e1006-0408-4f6d-a2e9-775bcaaa9272", "AQAAAAEAACcQAAAAECI/KTZRYgt9dV4VNhI8Ikc3kykTHQs61YhgTbR8b5THCTVFD4NFasa1MpEyPs/35g==", "fc6e0068-9792-4418-91e1-4b76e4890bbd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BookSuggestions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e9dc30b-7242-4bf0-b1ff-9ae88fc30252", "AQAAAAEAACcQAAAAEOst3Nw0+GmdYPqW/Qif2uUUHBu5nOcv0xVtcKzVDCDu6Y63eSyie1nFLgZEOzmQdA==", "89373571-8698-485c-a1b3-4c919b1d0a64" });
        }
    }
}

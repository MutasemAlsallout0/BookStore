using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class SeedDataForAdminUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bd66ca1f-10a4-4087-a1be-41a256153d39", "b5feebcf-f317-4117-81c5-f95c98e3999e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2de692d-ae6f-4514-b8df-427d4cf4c5fc", "AQAAAAEAACcQAAAAEHi2vbMh25gpHsXtvsZwsv0P6dsC4wW8NE/8s6IO67xEiwjvHOn+0u4J2PGPiBS7Dg==", "845c6b9c-ee69-4b15-8c20-742639fe564e" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "65574566-fef6-4857-903b-af23c2d795e9", 0, "b693b986-a9be-4ba4-beff-f7a9f51b7153", "admin@admin.com", true, "admin", true, "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEEUvBGYrRCmhaz/flKYMTGUmyXAASTvskRFlR7apr1aM+qz3umNsQS1jeNQX3lkfYQ==", null, false, "0fdc082a-49ba-45e3-99b0-4a387db1489b", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "80f3c65b-9f1c-4422-81b7-efaf1460cc8f", "65574566-fef6-4857-903b-af23c2d795e9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           


            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd66ca1f-10a4-4087-a1be-41a256153d39", "b5feebcf-f317-4117-81c5-f95c98e3999e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65574566-fef6-4857-903b-af23c2d795e9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80f3c65b-9f1c-4422-81b7-efaf1460cc8f", "e35b1c3e-cdef-412c-8c59-cbefb1f9bfd6", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd66ca1f-10a4-4087-a1be-41a256153d39", "5034fec4-3b95-4a3d-b329-7c2ef46413c3", "user", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99d2efea-7603-443a-be8b-2b4e116cee23", "AQAAAAEAACcQAAAAEAICSnGQs4/CyKIjFI71eEcaTz4EFAizhRQmGFJOv5sZEQtJyRq+xENSgeBzuL82EA==", "d92f7cb0-0448-4450-bb8b-f32347e2edf3" });
        }
    }
}

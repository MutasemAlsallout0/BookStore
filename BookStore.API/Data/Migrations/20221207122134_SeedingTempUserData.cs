using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class SeedingTempUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isActive" },
                values: new object[] { "b5feebcf-f317-4117-81c5-f95c98e3999e", 0, "842fd384-ccbd-4d90-9ce1-8a2db8bb988d", "user@user.com", true, "Mohamed", "alQadeery", false, null, "USER@USER.com", "MOHAMEDALQADEERY", "AQAAAAEAACcQAAAAEPQJNrNtMsggdUCBVsKl5BViNXkY/R9IuYzYam1rN5GbOGXvqw/D+g4DqHVIidLCPw==", null, false, "c5909915-3527-49a4-802a-6b86d6950222", false, "MohamedAlQadeery", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e");
        }
    }
}

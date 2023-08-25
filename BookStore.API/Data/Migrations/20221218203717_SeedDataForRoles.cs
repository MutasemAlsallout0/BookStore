using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class SeedDataForRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "AspNetUsers",
                newName: "IsActive");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5abb3901-d57d-429b-aea7-5d4b3a21ca81", "d768eef0-c947-450b-a936-f15a578fcb60", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d632f40a-f113-43a3-b3bd-cf69b22e43a8", "76b9c3c3-496c-413a-b81a-53c8b0aa032c", "user", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3947f90b-afdb-492c-9f9c-25271b934ffc", true, "AQAAAAEAACcQAAAAEMNt9D9XvsanHMZu8D7quXE6jYbxYGym7qb9nseXpk0S3nauE3F4FgjTqNklLNrYyA==", "cc7fe789-9caa-4c69-a022-238a1d06b49e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5abb3901-d57d-429b-aea7-5d4b3a21ca81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d632f40a-f113-43a3-b3bd-cf69b22e43a8");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "AspNetUsers",
                newName: "isActive");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "isActive" },
                values: new object[] { "b51348fd-1f83-4f96-bb7a-90eef7546a76", "AQAAAAEAACcQAAAAEI1CHOISorzrSxNyu+P1IK365InFukHXDOxxcdf/N8Tozd9RDVvmpzlDk8s6wUgk0A==", "6366edea-1e5a-4b80-ac1c-65a3d51137b8", false });
        }
    }
}

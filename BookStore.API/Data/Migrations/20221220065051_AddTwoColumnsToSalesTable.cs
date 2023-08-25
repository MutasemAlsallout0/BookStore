using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class AddTwoColumnsToSalesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5abb3901-d57d-429b-aea7-5d4b3a21ca81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d632f40a-f113-43a3-b3bd-cf69b22e43a8");

            migrationBuilder.AddColumn<DateTime>(
                name: "SoldDate",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80f3c65b-9f1c-4422-81b7-efaf1460cc8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd66ca1f-10a4-4087-a1be-41a256153d39");

            migrationBuilder.DropColumn(
                name: "SoldDate",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Sales");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3947f90b-afdb-492c-9f9c-25271b934ffc", "AQAAAAEAACcQAAAAEMNt9D9XvsanHMZu8D7quXE6jYbxYGym7qb9nseXpk0S3nauE3F4FgjTqNklLNrYyA==", "cc7fe789-9caa-4c69-a022-238a1d06b49e" });
        }
    }
}

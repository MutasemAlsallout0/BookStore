using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class TranslatorIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Translators_TranslatorId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "TranslatorId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b51348fd-1f83-4f96-bb7a-90eef7546a76", "AQAAAAEAACcQAAAAEI1CHOISorzrSxNyu+P1IK365InFukHXDOxxcdf/N8Tozd9RDVvmpzlDk8s6wUgk0A==", "6366edea-1e5a-4b80-ac1c-65a3d51137b8" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Translators_TranslatorId",
                table: "Books",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Translators_TranslatorId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "TranslatorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "704e1006-0408-4f6d-a2e9-775bcaaa9272", "AQAAAAEAACcQAAAAECI/KTZRYgt9dV4VNhI8Ikc3kykTHQs61YhgTbR8b5THCTVFD4NFasa1MpEyPs/35g==", "fc6e0068-9792-4418-91e1-4b76e4890bbd" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Translators_TranslatorId",
                table: "Books",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

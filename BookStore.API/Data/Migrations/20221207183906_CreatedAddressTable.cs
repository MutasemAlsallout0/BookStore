using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class CreatedAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Zones_ZoneId",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ZoneId",
                table: "Addresses",
                newName: "IX_Addresses_ZoneId");

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e9dc30b-7242-4bf0-b1ff-9ae88fc30252", "AQAAAAEAACcQAAAAEOst3Nw0+GmdYPqW/Qif2uUUHBu5nOcv0xVtcKzVDCDu6Y63eSyie1nFLgZEOzmQdA==", "89373571-8698-485c-a1b3-4c919b1d0a64" });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Zones_ZoneId",
                table: "Addresses",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Zones_ZoneId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_ZoneId",
                table: "Address",
                newName: "IX_Address_ZoneId");

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25630fcf-8300-4e1d-9732-154e4f3f9bc7", "AQAAAAEAACcQAAAAEECtwgES1Jc8BUoqoiS+B3AWvmeAK1kLD1WELgvn1ICJszFFFNBawaAC19kRA7HlvA==", "6ca750e2-0dd6-418b-8a39-58d5ce223b06" });

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Zones_ZoneId",
                table: "Address",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

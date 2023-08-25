using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class DefaultValueForOrderDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25630fcf-8300-4e1d-9732-154e4f3f9bc7", "AQAAAAEAACcQAAAAEECtwgES1Jc8BUoqoiS+B3AWvmeAK1kLD1WELgvn1ICJszFFFNBawaAC19kRA7HlvA==", "6ca750e2-0dd6-418b-8a39-58d5ce223b06" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "211caed6-0507-447c-8967-676c4e45badd", "AQAAAAEAACcQAAAAEHdhQIP5Yebb9WxNVUcB1TmafvH9qC31GtPwu6mCr7rMAHuYMMIbh8YQzHAndPcn2Q==", "99e387b5-0fa0-4079-bc1f-1a04649c9248" });
        }
    }
}

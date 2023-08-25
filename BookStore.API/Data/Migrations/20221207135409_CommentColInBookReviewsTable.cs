using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class CommentColInBookReviewsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "BookReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "211caed6-0507-447c-8967-676c4e45badd", "AQAAAAEAACcQAAAAEHdhQIP5Yebb9WxNVUcB1TmafvH9qC31GtPwu6mCr7rMAHuYMMIbh8YQzHAndPcn2Q==", "99e387b5-0fa0-4079-bc1f-1a04649c9248" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "BookReviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5feebcf-f317-4117-81c5-f95c98e3999e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "842fd384-ccbd-4d90-9ce1-8a2db8bb988d", "AQAAAAEAACcQAAAAEPQJNrNtMsggdUCBVsKl5BViNXkY/R9IuYzYam1rN5GbOGXvqw/D+g4DqHVIidLCPw==", "c5909915-3527-49a4-802a-6b86d6950222" });
        }
    }
}

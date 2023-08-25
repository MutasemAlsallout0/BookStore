using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Data.Migrations
{
    public partial class AddSlugColumnInStaticPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "StaticPages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

           

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "StaticPages");

          }
    }
}

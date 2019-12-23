using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Change_Name_ShopCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShopCourseId",
                table: "ShopCourseItems",
                newName: "ShopCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShopCartId",
                table: "ShopCourseItems",
                newName: "ShopCourseId");
        }
    }
}

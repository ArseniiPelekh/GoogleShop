using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Change_Table_ShopCourseItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShopCourseId",
                table: "ShopCourseItems",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShopCourseId",
                table: "ShopCourseItems",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

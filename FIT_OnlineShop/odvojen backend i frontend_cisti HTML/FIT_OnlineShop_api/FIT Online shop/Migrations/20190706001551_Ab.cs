using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Online_shop.Migrations
{
    public partial class Ab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeCounter",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeCounter",
                table: "Narudzba");
        }
    }
}

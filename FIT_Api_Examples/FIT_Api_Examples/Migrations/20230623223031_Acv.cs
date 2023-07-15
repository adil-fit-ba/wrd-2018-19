using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    public partial class Acv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ipAdresa",
                table: "Ispit20230624PosaljiZapis",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ipAdresa",
                table: "Ispit20230624PosaljiZapis");
        }
    }
}

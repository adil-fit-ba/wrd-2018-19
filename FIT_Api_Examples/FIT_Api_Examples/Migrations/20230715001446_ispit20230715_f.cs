using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    public partial class ispit20230715_f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DatumPolaska",
                table: "Ispit20230715PosaljiZapis",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumPolaska",
                table: "Ispit20230715PosaljiZapis");
        }
    }
}

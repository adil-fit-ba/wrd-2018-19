using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    public partial class ispit20230715_e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CijenaKM",
                table: "Ispit20230715PlaniranoPutovanje",
                newName: "CijenaEUR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CijenaEUR",
                table: "Ispit20230715PlaniranoPutovanje",
                newName: "CijenaKM");
        }
    }
}

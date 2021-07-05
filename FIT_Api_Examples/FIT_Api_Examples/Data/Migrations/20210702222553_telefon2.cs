using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Data.Migrations
{
    public partial class telefon2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZaposlenikID",
                table: "Ispit20210702Posalji");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ZaposlenikID",
                table: "Ispit20210702Posalji",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

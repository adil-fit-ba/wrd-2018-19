using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Online_shop.Migrations
{
    public partial class B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Proizvod",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Naziv",
                table: "Proizvod",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

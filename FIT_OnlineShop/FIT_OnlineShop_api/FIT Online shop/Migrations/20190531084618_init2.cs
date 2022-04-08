using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Online_shop.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KupacID",
                table: "Narudzba",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KupacID",
                table: "Narudzba",
                column: "KupacID");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_KorisnickiNalog_KupacID",
                table: "Narudzba",
                column: "KupacID",
                principalTable: "KorisnickiNalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_KorisnickiNalog_KupacID",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_KupacID",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "KupacID",
                table: "Narudzba");
        }
    }
}

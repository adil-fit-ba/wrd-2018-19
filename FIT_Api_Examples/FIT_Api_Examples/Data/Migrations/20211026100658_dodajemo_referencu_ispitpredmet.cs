using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Data.Migrations
{
    public partial class dodajemo_referencu_ispitpredmet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ispit_PredmetID",
                table: "Ispit",
                column: "PredmetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ispit_Predmet_PredmetID",
                table: "Ispit",
                column: "PredmetID",
                principalTable: "Predmet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ispit_Predmet_PredmetID",
                table: "Ispit");

            migrationBuilder.DropIndex(
                name: "IX_Ispit_PredmetID",
                table: "Ispit");
        }
    }
}

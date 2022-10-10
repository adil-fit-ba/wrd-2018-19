using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Data.Migrations
{
    public partial class _20220924c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinacijaVM20220924_TravelFirma_TravelFirmaID",
                table: "DestinacijaVM20220924");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelFirma",
                table: "TravelFirma");

            migrationBuilder.RenameTable(
                name: "TravelFirma",
                newName: "TravelFirma20220924");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelFirma20220924",
                table: "TravelFirma20220924",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinacijaVM20220924_TravelFirma20220924_TravelFirmaID",
                table: "DestinacijaVM20220924",
                column: "TravelFirmaID",
                principalTable: "TravelFirma20220924",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinacijaVM20220924_TravelFirma20220924_TravelFirmaID",
                table: "DestinacijaVM20220924");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelFirma20220924",
                table: "TravelFirma20220924");

            migrationBuilder.RenameTable(
                name: "TravelFirma20220924",
                newName: "TravelFirma");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelFirma",
                table: "TravelFirma",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinacijaVM20220924_TravelFirma_TravelFirmaID",
                table: "DestinacijaVM20220924",
                column: "TravelFirmaID",
                principalTable: "TravelFirma",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

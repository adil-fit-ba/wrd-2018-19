using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    public partial class ispit20230715_b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinacijaVM20230715_TravelFirma20220924_TravelFirmaID",
                table: "DestinacijaVM20230715");

            migrationBuilder.DropForeignKey(
                name: "FK_Ispit20230715PlaniranoPutovanje_DestinacijaVM20230715_Ispit20230715DestinacijaID",
                table: "Ispit20230715PlaniranoPutovanje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DestinacijaVM20230715",
                table: "DestinacijaVM20230715");

            migrationBuilder.RenameTable(
                name: "DestinacijaVM20230715",
                newName: "Ispit20230715Destinacija");

            migrationBuilder.RenameIndex(
                name: "IX_DestinacijaVM20230715_TravelFirmaID",
                table: "Ispit20230715Destinacija",
                newName: "IX_Ispit20230715Destinacija_TravelFirmaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ispit20230715Destinacija",
                table: "Ispit20230715Destinacija",
                column: "Ispit20230715DestinacijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ispit20230715Destinacija_TravelFirma20220924_TravelFirmaID",
                table: "Ispit20230715Destinacija",
                column: "TravelFirmaID",
                principalTable: "TravelFirma20220924",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ispit20230715PlaniranoPutovanje_Ispit20230715Destinacija_Ispit20230715DestinacijaID",
                table: "Ispit20230715PlaniranoPutovanje",
                column: "Ispit20230715DestinacijaID",
                principalTable: "Ispit20230715Destinacija",
                principalColumn: "Ispit20230715DestinacijaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ispit20230715Destinacija_TravelFirma20220924_TravelFirmaID",
                table: "Ispit20230715Destinacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Ispit20230715PlaniranoPutovanje_Ispit20230715Destinacija_Ispit20230715DestinacijaID",
                table: "Ispit20230715PlaniranoPutovanje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ispit20230715Destinacija",
                table: "Ispit20230715Destinacija");

            migrationBuilder.RenameTable(
                name: "Ispit20230715Destinacija",
                newName: "DestinacijaVM20230715");

            migrationBuilder.RenameIndex(
                name: "IX_Ispit20230715Destinacija_TravelFirmaID",
                table: "DestinacijaVM20230715",
                newName: "IX_DestinacijaVM20230715_TravelFirmaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DestinacijaVM20230715",
                table: "DestinacijaVM20230715",
                column: "Ispit20230715DestinacijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinacijaVM20230715_TravelFirma20220924_TravelFirmaID",
                table: "DestinacijaVM20230715",
                column: "TravelFirmaID",
                principalTable: "TravelFirma20220924",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ispit20230715PlaniranoPutovanje_DestinacijaVM20230715_Ispit20230715DestinacijaID",
                table: "Ispit20230715PlaniranoPutovanje",
                column: "Ispit20230715DestinacijaID",
                principalTable: "DestinacijaVM20230715",
                principalColumn: "Ispit20230715DestinacijaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

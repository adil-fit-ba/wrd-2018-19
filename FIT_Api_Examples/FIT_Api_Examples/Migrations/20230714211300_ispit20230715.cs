using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    public partial class ispit20230715 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinacijaVM20230715",
                columns: table => new
                {
                    Ispit20230715DestinacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MjestoDrzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpisPonude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelFirmaID = table.Column<int>(type: "int", nullable: false),
                    AkcijaPoruka = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinacijaVM20230715", x => x.Ispit20230715DestinacijaID);
                    table.ForeignKey(
                        name: "FK_DestinacijaVM20230715_TravelFirma20220924_TravelFirmaID",
                        column: x => x.TravelFirmaID,
                        principalTable: "TravelFirma20220924",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ispit20230715PlaniranoPutovanje",
                columns: table => new
                {
                    Ispit20230715PlaniranoPutovanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumPovratka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojSlobodnihMjesta = table.Column<int>(type: "int", nullable: false),
                    CijenaKM = table.Column<double>(type: "float", nullable: false),
                    VrstaPrevoza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelOpis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ispit20230715DestinacijaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispit20230715PlaniranoPutovanje", x => x.Ispit20230715PlaniranoPutovanjeID);
                    table.ForeignKey(
                        name: "FK_Ispit20230715PlaniranoPutovanje_DestinacijaVM20230715_Ispit20230715DestinacijaID",
                        column: x => x.Ispit20230715DestinacijaID,
                        principalTable: "DestinacijaVM20230715",
                        principalColumn: "Ispit20230715DestinacijaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinacijaVM20230715_TravelFirmaID",
                table: "DestinacijaVM20230715",
                column: "TravelFirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ispit20230715PlaniranoPutovanje_Ispit20230715DestinacijaID",
                table: "Ispit20230715PlaniranoPutovanje",
                column: "Ispit20230715DestinacijaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ispit20230715PlaniranoPutovanje");

            migrationBuilder.DropTable(
                name: "DestinacijaVM20230715");
        }
    }
}

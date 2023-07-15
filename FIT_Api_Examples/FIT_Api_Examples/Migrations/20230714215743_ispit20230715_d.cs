using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    public partial class ispit20230715_d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ispit20230715PlaniranoPutovanjeID",
                table: "Ispit20230715PlaniranoPutovanje",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Ispit20230715DestinacijaID",
                table: "Ispit20230715Destinacija",
                newName: "ID");

            migrationBuilder.CreateTable(
                name: "Ispit20230715PosaljiZapis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelFirma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinacijaDrzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojIndeksa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gosti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ispit20230715PlaniranoPutovanjeId = table.Column<int>(type: "int", nullable: true),
                    IpAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispit20230715PosaljiZapis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ispit20230715PosaljiZapis_Ispit20230715PlaniranoPutovanje_Ispit20230715PlaniranoPutovanjeId",
                        column: x => x.Ispit20230715PlaniranoPutovanjeId,
                        principalTable: "Ispit20230715PlaniranoPutovanje",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ispit20230715PosaljiZapis_Ispit20230715PlaniranoPutovanjeId",
                table: "Ispit20230715PosaljiZapis",
                column: "Ispit20230715PlaniranoPutovanjeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ispit20230715PosaljiZapis");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Ispit20230715PlaniranoPutovanje",
                newName: "Ispit20230715PlaniranoPutovanjeID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Ispit20230715Destinacija",
                newName: "Ispit20230715DestinacijaID");
        }
    }
}

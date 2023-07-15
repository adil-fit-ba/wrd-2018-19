using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    public partial class Ab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ispit20230624PosaljiZapis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinacijaDrzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojIndeksa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gosti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OznakaSoba = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispit20230624PosaljiZapis", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ispit20230624PosaljiZapis");
        }
    }
}

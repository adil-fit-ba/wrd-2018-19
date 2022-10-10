using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Data.Migrations
{
    public partial class _20220924b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelFirmaID",
                table: "DestinacijaVM20220924",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TravelFirma",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelFirma", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinacijaVM20220924_TravelFirmaID",
                table: "DestinacijaVM20220924",
                column: "TravelFirmaID");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinacijaVM20220924_TravelFirma_TravelFirmaID",
                table: "DestinacijaVM20220924",
                column: "TravelFirmaID",
                principalTable: "TravelFirma",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinacijaVM20220924_TravelFirma_TravelFirmaID",
                table: "DestinacijaVM20220924");

            migrationBuilder.DropTable(
                name: "TravelFirma");

            migrationBuilder.DropIndex(
                name: "IX_DestinacijaVM20220924_TravelFirmaID",
                table: "DestinacijaVM20220924");

            migrationBuilder.DropColumn(
                name: "TravelFirmaID",
                table: "DestinacijaVM20220924");
        }
    }
}

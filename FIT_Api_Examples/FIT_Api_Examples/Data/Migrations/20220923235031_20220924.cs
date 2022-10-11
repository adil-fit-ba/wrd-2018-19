using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Data.Migrations
{
    public partial class _20220924 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinacijaVM20220924",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MjestoDrzava = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    CijenaDolar = table.Column<double>(nullable: false),
                    OpisPonude = table.Column<string>(nullable: true),
                    _Opcije = table.Column<string>(nullable: true),
                    AkcijaPoruka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinacijaVM20220924", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinacijaVM20220924");
        }
    }
}

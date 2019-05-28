using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Online_shop.Migrations
{
    public partial class dostava2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Opstina_DostavaOpstinaIDId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "DostavaOpstina",
                table: "Narudzba");

            migrationBuilder.RenameColumn(
                name: "DostavaOpstinaIDId",
                table: "Narudzba",
                newName: "DostavaOpstinaID");

            migrationBuilder.RenameColumn(
                name: "Cijena",
                table: "Narudzba",
                newName: "IznosNarudzbe");

            migrationBuilder.RenameIndex(
                name: "IX_Narudzba_DostavaOpstinaIDId",
                table: "Narudzba",
                newName: "IX_Narudzba_DostavaOpstinaID");

            migrationBuilder.AddColumn<float>(
                name: "CijenaDostave",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Opstina_DostavaOpstinaID",
                table: "Narudzba",
                column: "DostavaOpstinaID",
                principalTable: "Opstina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Opstina_DostavaOpstinaID",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "CijenaDostave",
                table: "Narudzba");

            migrationBuilder.RenameColumn(
                name: "IznosNarudzbe",
                table: "Narudzba",
                newName: "Cijena");

            migrationBuilder.RenameColumn(
                name: "DostavaOpstinaID",
                table: "Narudzba",
                newName: "DostavaOpstinaIDId");

            migrationBuilder.RenameIndex(
                name: "IX_Narudzba_DostavaOpstinaID",
                table: "Narudzba",
                newName: "IX_Narudzba_DostavaOpstinaIDId");

            migrationBuilder.AddColumn<int>(
                name: "DostavaOpstina",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Opstina_DostavaOpstinaIDId",
                table: "Narudzba",
                column: "DostavaOpstinaIDId",
                principalTable: "Opstina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

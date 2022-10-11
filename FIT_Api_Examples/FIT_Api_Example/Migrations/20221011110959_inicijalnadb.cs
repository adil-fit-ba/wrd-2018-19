using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Example.Migrations
{
    public partial class inicijalnadb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employee_salary = table.Column<float>(type: "real", nullable: true),
                    employee_age = table.Column<int>(type: "int", nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    profile_image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ispit20210601Posalji",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicniBrojKupca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Upit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispit20210601Posalji", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ispit20210702Posalji",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poruka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispit20210702Posalji", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TravelFirma20220924",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelFirma20220924", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drzava_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.id);
                    table.ForeignKey(
                        name: "FK_Opstina_Drzava_drzava_id",
                        column: x => x.drzava_id,
                        principalTable: "Drzava",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTask",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    original_estimated_hours = table.Column<float>(type: "real", nullable: true),
                    spent_hours = table.Column<float>(type: "real", nullable: true),
                    percent_completed = table.Column<int>(type: "int", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTask", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProjectTask_Employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTask_Project_project_id",
                        column: x => x.project_id,
                        principalTable: "Project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DestinacijaVM20220924",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MjestoDrzava = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CijenaDolar = table.Column<double>(type: "float", nullable: false),
                    OpisPonude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelFirmaID = table.Column<int>(type: "int", nullable: false),
                    AkcijaPoruka = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinacijaVM20220924", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DestinacijaVM20220924_TravelFirma20220924_TravelFirmaID",
                        column: x => x.TravelFirmaID,
                        principalTable: "TravelFirma20220924",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    broj_indeksa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opstina_rodjenja_id = table.Column<int>(type: "int", nullable: true),
                    datum_rodjenja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    slika_studenta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                    table.ForeignKey(
                        name: "FK_Student_Opstina_opstina_rodjenja_id",
                        column: x => x.opstina_rodjenja_id,
                        principalTable: "Opstina",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "TimeTracking",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_task_id = table.Column<int>(type: "int", nullable: false),
                    start_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    spent_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTracking", x => x.id);
                    table.ForeignKey(
                        name: "FK_TimeTracking_ProjectTask_project_task_id",
                        column: x => x.project_task_id,
                        principalTable: "ProjectTask",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinacijaVM20220924_TravelFirmaID",
                table: "DestinacijaVM20220924",
                column: "TravelFirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Opstina_drzava_id",
                table: "Opstina",
                column: "drzava_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_employee_id",
                table: "ProjectTask",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_project_id",
                table: "ProjectTask",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_opstina_rodjenja_id",
                table: "Student",
                column: "opstina_rodjenja_id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_project_task_id",
                table: "TimeTracking",
                column: "project_task_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinacijaVM20220924");

            migrationBuilder.DropTable(
                name: "Ispit20210601Posalji");

            migrationBuilder.DropTable(
                name: "Ispit20210702Posalji");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "TimeTracking");

            migrationBuilder.DropTable(
                name: "TravelFirma20220924");

            migrationBuilder.DropTable(
                name: "Opstina");

            migrationBuilder.DropTable(
                name: "ProjectTask");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}

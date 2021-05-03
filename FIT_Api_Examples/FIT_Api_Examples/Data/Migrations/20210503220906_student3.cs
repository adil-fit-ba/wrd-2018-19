using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Data.Migrations
{
    public partial class student3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "TimeTracking");

            migrationBuilder.DropTable(
                name: "Opstina");

            migrationBuilder.DropTable(
                name: "ProjectTask");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "Project");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    original_estimated_hours = table.Column<float>(type: "real", nullable: true),
                    percent_completed = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    spent_hours = table.Column<float>(type: "real", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    broj_indeksa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    opstina_rodjenja_id = table.Column<int>(type: "int", nullable: true),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slika_studenta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                    table.ForeignKey(
                        name: "FK_Student_Opstina_opstina_rodjenja_id",
                        column: x => x.opstina_rodjenja_id,
                        principalTable: "Opstina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeTracking",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    end_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    project_task_id = table.Column<int>(type: "int", nullable: false),
                    spent_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    start_time = table.Column<DateTime>(type: "datetime2", nullable: false)
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
    }
}

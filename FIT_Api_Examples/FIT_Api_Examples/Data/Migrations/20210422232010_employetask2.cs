using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIT_Api_Examples.Data.Migrations
{
    public partial class employetask2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTask",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    original_estimated_hours = table.Column<float>(nullable: true),
                    spent_hours = table.Column<float>(nullable: true),
                    percent_completed = table.Column<int>(nullable: false),
                    created_time = table.Column<DateTime>(nullable: false),
                    employee_id = table.Column<int>(nullable: false),
                    project_id = table.Column<int>(nullable: false)
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
                name: "TimeTracking",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_task_id = table.Column<int>(nullable: false),
                    start_time = table.Column<DateTime>(nullable: false),
                    end_time = table.Column<DateTime>(nullable: false),
                    spent_time = table.Column<TimeSpan>(nullable: false),
                    description = table.Column<string>(nullable: true)
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
                name: "IX_ProjectTask_employee_id",
                table: "ProjectTask",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTask_project_id",
                table: "ProjectTask",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_project_task_id",
                table: "TimeTracking",
                column: "project_task_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeTracking");

            migrationBuilder.DropTable(
                name: "ProjectTask");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}

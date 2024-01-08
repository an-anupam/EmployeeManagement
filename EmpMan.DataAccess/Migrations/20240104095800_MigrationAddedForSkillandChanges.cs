using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmpMan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAddedForSkillandChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    allSkills = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false),
                    ratingsInSkill = table.Column<int>(type: "INTEGER", nullable: false),
                    experienceInSkill = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DOJ", "DepartmentId", "Designation", "Email", "FirstName", "LastName" },
                values: new object[] { 6, new DateOnly(2021, 12, 4), 4, "Frotend Developer", "SomeGuy@gmail.com", "Some", "Guy" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "allSkills" },
                values: new object[,]
                {
                    { 1, "JavaScript" },
                    { 2, "Java" },
                    { 3, "Python" },
                    { 4, ".Net Frameworks" },
                    { 5, "C++" },
                    { 6, "C" },
                    { 7, "AWS Cloud" },
                    { 8, "Azure Cloud" },
                    { 9, "Azure Cloud" },
                    { 10, "Azure Cloud" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "Id", "EmployeeId", "SkillId", "experienceInSkill", "ratingsInSkill" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 3, 2, 3, 4 },
                    { 3, 4, 4, 4, 4 },
                    { 4, 2, 6, 5, 8 },
                    { 5, 5, 8, 1, 1 },
                    { 6, 6, 9, 7, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeId",
                table: "EmployeeSkills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillId",
                table: "EmployeeSkills",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmpMan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationAddedForSkillModel : Migration
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
                    PrimarySkill = table.Column<string>(type: "TEXT", nullable: false),
                    SecondarySkill = table.Column<string>(type: "TEXT", nullable: false),
                    ratingsInSkill = table.Column<int>(type: "INTEGER", nullable: false),
                    experienceInSkill = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "PrimarySkill", "SecondarySkill", "experienceInSkill", "ratingsInSkill" },
                values: new object[,]
                {
                    { 1, "Java", "JavaScript", 3, 7 },
                    { 2, "C++", "Swift", 2, 6 },
                    { 3, "C#", "JavaScript", 1, 8 },
                    { 4, "Python", "Java", 2, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}

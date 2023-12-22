using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmpMan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    DOJ = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Designation = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DOJ", "Designation", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 11, 3), "Developer", "a@gmail.com", "Anupam", "Mohanty" },
                    { 2, new DateOnly(2022, 11, 3), "Developer", "avi@gmail.com", "Avinash", "Kumar" },
                    { 3, new DateOnly(2022, 10, 3), "Tester", "aditya@gmail.com", "Aditya", "Khadanga" },
                    { 4, new DateOnly(2021, 10, 3), "Architecture", "anubh@gmail.com", "Anubhab", "Mohanty" },
                    { 5, new DateOnly(2020, 10, 4), "Sr. Developer", "kurnal@gmail.com", "Kurnal", "Das" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

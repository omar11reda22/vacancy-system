using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysky_task.Migrations
{
    /// <inheritdoc />
    public partial class step2vacancyapplicant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    ExpireDae = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxApplications = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vacancyid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicants_vacancies_vacancyid",
                        column: x => x.vacancyid,
                        principalTable: "vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_applicants_vacancyid",
                table: "applicants",
                column: "vacancyid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicants");

            migrationBuilder.DropTable(
                name: "vacancies");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aibidia.Homework.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabaseAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Resume",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResumeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_Resume_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "dbo",
                        principalTable: "Resume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experience_Resume_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "dbo",
                        principalTable: "Resume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interest",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interest_Resume_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "dbo",
                        principalTable: "Resume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Resume_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "dbo",
                        principalTable: "Resume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Resume",
                columns: new[] { "Id", "Description", "Email", "FullName", "IsActive", "PhoneNumber", "Summary" },
                values: new object[,]
                {
                    { 1, "Looking for remote backend roles.", "owen@gmail.com", "Owen M", true, "07123 456 789", "Full Stack Developer with 5+ years of experience." },
                    { 2, "Open to contract opportunities.", "jane.doe@example.com", "Jane Doe", true, "07234 567 890", "Frontend Developer with a passion for UI/UX." },
                    { 3, "Open for anything.", "old-cv@old.com", "Joe Bloggs", false, "07654 567 098", "Junior front end dev." }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Education",
                columns: new[] { "Id", "EndDate", "Institution", "Qualification", "ResumeId", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "NZ University", "B.Sc. in Computer Science", 1, new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Microsoft", "AZ-900: Microsoft Azure Fundamentals", 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some other University", "B.Sc. in Information Technology", 2, new DateTime(2014, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Experience",
                columns: new[] { "Id", "CompanyName", "Description", "EndDate", "Position", "ResumeId", "StartDate", "Website" },
                values: new object[,]
                {
                    { 1, "Kainos", "Worked on lots of government projects.", null, "Software Engineer", 1, new DateTime(2021, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://kainos.com" },
                    { 2, "Mr Lender", "Ripped people off with high interest loans.", new DateTime(2020, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Developer", 1, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://mrlender.com" },
                    { 3, "Some Company", "Developed lots of web applications.", new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frontend Engineer", 2, new DateTime(2012, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://somecompany.com" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Interest",
                columns: new[] { "Id", "Name", "ResumeId" },
                values: new object[,]
                {
                    { 1, "Muay Thai", 1 },
                    { 2, "Diving", 1 },
                    { 3, "Traveling", 2 },
                    { 4, "Reading", 2 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Skill",
                columns: new[] { "Id", "Name", "ResumeId" },
                values: new object[,]
                {
                    { 1, "C#", 1 },
                    { 2, ".NET Core", 1 },
                    { 3, "Vue", 1 },
                    { 4, "VB", 2 },
                    { 5, ".NET", 2 },
                    { 6, "Blazor", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_ResumeId",
                schema: "dbo",
                table: "Education",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_ResumeId",
                schema: "dbo",
                table: "Experience",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Interest_ResumeId",
                schema: "dbo",
                table: "Interest",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_ResumeId",
                schema: "dbo",
                table: "Skill",
                column: "ResumeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Experience",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Interest",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Skill",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Resume",
                schema: "dbo");
        }
    }
}

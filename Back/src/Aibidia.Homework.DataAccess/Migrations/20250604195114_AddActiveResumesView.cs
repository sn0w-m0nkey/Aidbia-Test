using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aibidia.Homework.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddActiveResumesView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW ActiveResumeView AS
                SELECT
                    r.Id AS Id,
                    r.FullName,
                    r.Email,
                    r.PhoneNumber,
                    r.Summary,
                    r.Description,
                    r.IsActive,

                    -- Aggregate as JSON
                    (
                        SELECT e.CompanyName, e.Position, e.StartDate, e.EndDate, e.Description, e.Website
                        FROM Experience e
                        WHERE e.ResumeId = r.Id
                        FOR JSON PATH
                    ) AS ExperiencesJson,

                    (
                        SELECT ed.Institution, ed.Qualification, ed.StartDate, ed.EndDate
                        FROM Education ed
                        WHERE ed.ResumeId = r.Id
                        FOR JSON PATH
                    ) AS EducationsJson,

                    (
                        SELECT s.Name
                        FROM Skill s
                        WHERE s.ResumeId = r.Id
                        FOR JSON PATH
                    ) AS SkillsJson,

                    (
                        SELECT i.Name
                        FROM Interest i
                        WHERE i.ResumeId = r.Id
                        FOR JSON PATH
                    ) AS InterestsJson

                FROM Resume r
                WHERE IsActive = 1;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW ActiveResumeView");
        }
    }
}

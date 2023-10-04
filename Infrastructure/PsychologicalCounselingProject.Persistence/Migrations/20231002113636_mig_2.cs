using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologicalCounselingProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentNumber",
                table: "Users",
                newName: "UniversityNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UniversityNumber",
                table: "Users",
                newName: "StudentNumber");
        }
    }
}

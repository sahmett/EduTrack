using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CourseContentNameProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CourseContents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CourseContents");
        }
    }
}

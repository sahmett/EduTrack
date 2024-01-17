using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduTrack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContentLinkPropUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "CourseContents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "CourseContents");
        }
    }
}

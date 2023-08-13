using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class serpentImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostCopyright",
                table: "CommunityResearch",
                newName: "ResearchCopyright");

            migrationBuilder.AddColumn<byte[]>(
                name: "UserProfilePicture",
                table: "UserDetail",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "SerpentImage",
                table: "Serpent",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<bool>(
                name: "PostEdited",
                table: "CommunityPost",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserProfilePicture",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "SerpentImage",
                table: "Serpent");

            migrationBuilder.DropColumn(
                name: "PostEdited",
                table: "CommunityPost");

            migrationBuilder.RenameColumn(
                name: "ResearchCopyright",
                table: "CommunityResearch",
                newName: "PostCopyright");
        }
    }
}

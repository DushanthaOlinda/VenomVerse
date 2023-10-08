using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class instructionupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerpentId",
                table: "CommunityPost");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "SerpentInstruction",
                newName: "InsDetailSinhala");

            migrationBuilder.AddColumn<string>(
                name: "InsDetail",
                table: "SerpentInstruction",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsDetail",
                table: "SerpentInstruction");

            migrationBuilder.RenameColumn(
                name: "InsDetailSinhala",
                table: "SerpentInstruction",
                newName: "Description");

            migrationBuilder.AddColumn<long>(
                name: "SerpentId",
                table: "CommunityPost",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

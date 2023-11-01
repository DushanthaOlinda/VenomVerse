using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class oct25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CommunityArticle_ApprovedUserId",
                table: "CommunityArticle");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityArticle_ApprovedUserId",
                table: "CommunityArticle",
                column: "ApprovedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CommunityArticle_ApprovedUserId",
                table: "CommunityArticle");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityArticle_ApprovedUserId",
                table: "CommunityArticle",
                column: "ApprovedUserId",
                unique: true);
        }
    }
}

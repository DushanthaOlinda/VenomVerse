using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class sap122244 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CommunityPost_ApprovedAdmin",
                table: "CommunityPost",
                column: "ApprovedAdmin");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityPost_CommunityAdmin_ApprovedAdmin",
                table: "CommunityPost",
                column: "ApprovedAdmin",
                principalTable: "CommunityAdmin",
                principalColumn: "CommunityAdminId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityPost_CommunityAdmin_ApprovedAdmin",
                table: "CommunityPost");

            migrationBuilder.DropIndex(
                name: "IX_CommunityPost_ApprovedAdmin",
                table: "CommunityPost");
        }
    }
}

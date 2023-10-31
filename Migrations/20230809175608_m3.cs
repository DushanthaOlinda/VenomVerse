using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityAdmin_CommunityBook_CommunityBookId",
                table: "CommunityAdmin");

            migrationBuilder.DropIndex(
                name: "IX_CommunityAdmin_CommunityBookId",
                table: "CommunityAdmin");

            migrationBuilder.DropColumn(
                name: "CommunityBookId",
                table: "CommunityAdmin");

            migrationBuilder.RenameColumn(
                name: "PostCopyright",
                table: "CommunityResearch",
                newName: "ResearchCopyright");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResearchCopyright",
                table: "CommunityResearch",
                newName: "PostCopyright");

            migrationBuilder.AddColumn<long>(
                name: "CommunityBookId",
                table: "CommunityAdmin",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityAdmin_CommunityBookId",
                table: "CommunityAdmin",
                column: "CommunityBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityAdmin_CommunityBook_CommunityBookId",
                table: "CommunityAdmin",
                column: "CommunityBookId",
                principalTable: "CommunityBook",
                principalColumn: "CommunityBookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

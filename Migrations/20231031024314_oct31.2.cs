using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class oct312 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequestService_ReqUserId",
                table: "RequestService");

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_ReqUserId",
                table: "RequestService",
                column: "ReqUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequestService_ReqUserId",
                table: "RequestService");

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_ReqUserId",
                table: "RequestService",
                column: "ReqUserId",
                unique: true);
        }
    }
}

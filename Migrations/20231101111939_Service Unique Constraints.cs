using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class ServiceUniqueConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequestService_CatcherId",
                table: "RequestService");

            migrationBuilder.DropIndex(
                name: "IX_RequestService_ScannedImage",
                table: "RequestService");

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_CatcherId",
                table: "RequestService",
                column: "CatcherId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_ScannedImage",
                table: "RequestService",
                column: "ScannedImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequestService_CatcherId",
                table: "RequestService");

            migrationBuilder.DropIndex(
                name: "IX_RequestService_ScannedImage",
                table: "RequestService");

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_CatcherId",
                table: "RequestService",
                column: "CatcherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_ScannedImage",
                table: "RequestService",
                column: "ScannedImage",
                unique: true);
        }
    }
}

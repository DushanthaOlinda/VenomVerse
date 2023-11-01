using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class oct313 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequestService_SelectedSerpent",
                table: "RequestService");

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_SelectedSerpent",
                table: "RequestService",
                column: "SelectedSerpent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequestService_SelectedSerpent",
                table: "RequestService");

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_SelectedSerpent",
                table: "RequestService",
                column: "SelectedSerpent",
                unique: true);
        }
    }
}

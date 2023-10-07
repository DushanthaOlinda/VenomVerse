using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class QuizAttempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuizAttempt_UserId",
                table: "QuizAttempt");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempt_UserId",
                table: "QuizAttempt",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QuizAttempt_UserId",
                table: "QuizAttempt");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempt_UserId",
                table: "QuizAttempt",
                column: "UserId",
                unique: true);
        }
    }
}

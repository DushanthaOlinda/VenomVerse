using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class updatequizattempt3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "QuizUserAnswer");

            migrationBuilder.CreateIndex(
                name: "IX_QuizUserAnswer_QuestionId",
                table: "QuizUserAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizUserAnswer_QuizAttemptId",
                table: "QuizUserAnswer",
                column: "QuizAttemptId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUserAnswer_Question_QuestionId",
                table: "QuizUserAnswer",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUserAnswer_QuizAttempt_QuizAttemptId",
                table: "QuizUserAnswer",
                column: "QuizAttemptId",
                principalTable: "QuizAttempt",
                principalColumn: "QuizAttemptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizUserAnswer_Question_QuestionId",
                table: "QuizUserAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUserAnswer_QuizAttempt_QuizAttemptId",
                table: "QuizUserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_QuizUserAnswer_QuestionId",
                table: "QuizUserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_QuizUserAnswer_QuizAttemptId",
                table: "QuizUserAnswer");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "QuizUserAnswer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

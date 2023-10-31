using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class updatequizattempt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempt_QuizDetail_QuizId",
                table: "QuizAttempt");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUserAnswer_Question_QuestionId",
                table: "QuizUserAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUserAnswer_QuizAttempt_QuizAttemptId_UserId_SubmittedTi~",
                table: "QuizUserAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizUserAnswer",
                table: "QuizUserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_QuizUserAnswer_QuestionId",
                table: "QuizUserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_QuizUserAnswer_QuizAttemptId_UserId_SubmittedTime",
                table: "QuizUserAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizAttempt",
                table: "QuizAttempt");

            migrationBuilder.DropIndex(
                name: "IX_QuizAttempt_QuizId",
                table: "QuizAttempt");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "QuizAttempt",
                newName: "QuizAttemptId");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Question",
                newName: "QuizDetailId");

            migrationBuilder.AddColumn<long>(
                name: "QuizUserAnswerId",
                table: "QuizUserAnswer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "QuizAttemptId",
                table: "QuizAttempt",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizUserAnswer",
                table: "QuizUserAnswer",
                column: "QuizUserAnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizAttempt",
                table: "QuizAttempt",
                column: "QuizAttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempt_QuizDetailId",
                table: "QuizAttempt",
                column: "QuizDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizDetailId",
                table: "Question",
                column: "QuizDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_QuizDetail_QuizDetailId",
                table: "Question",
                column: "QuizDetailId",
                principalTable: "QuizDetail",
                principalColumn: "QuizDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttempt_QuizDetail_QuizDetailId",
                table: "QuizAttempt",
                column: "QuizDetailId",
                principalTable: "QuizDetail",
                principalColumn: "QuizDetailId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_QuizDetail_QuizDetailId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempt_QuizDetail_QuizDetailId",
                table: "QuizAttempt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizUserAnswer",
                table: "QuizUserAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizAttempt",
                table: "QuizAttempt");

            migrationBuilder.DropIndex(
                name: "IX_QuizAttempt_QuizDetailId",
                table: "QuizAttempt");

            migrationBuilder.DropIndex(
                name: "IX_Question_QuizDetailId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuizUserAnswerId",
                table: "QuizUserAnswer");

            migrationBuilder.RenameColumn(
                name: "QuizAttemptId",
                table: "QuizAttempt",
                newName: "QuizId");

            migrationBuilder.RenameColumn(
                name: "QuizDetailId",
                table: "Question",
                newName: "QuizId");

            migrationBuilder.AlterColumn<long>(
                name: "QuizId",
                table: "QuizAttempt",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizUserAnswer",
                table: "QuizUserAnswer",
                columns: new[] { "QuizAttemptId", "QuestionId", "UserId", "SubmittedTime" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizAttempt",
                table: "QuizAttempt",
                columns: new[] { "QuizDetailId", "UserId", "SubmittedTime" });

            migrationBuilder.CreateIndex(
                name: "IX_QuizUserAnswer_QuestionId",
                table: "QuizUserAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizUserAnswer_QuizAttemptId_UserId_SubmittedTime",
                table: "QuizUserAnswer",
                columns: new[] { "QuizAttemptId", "UserId", "SubmittedTime" });

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempt_QuizId",
                table: "QuizAttempt",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttempt_QuizDetail_QuizId",
                table: "QuizAttempt",
                column: "QuizId",
                principalTable: "QuizDetail",
                principalColumn: "QuizDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUserAnswer_Question_QuestionId",
                table: "QuizUserAnswer",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUserAnswer_QuizAttempt_QuizAttemptId_UserId_SubmittedTi~",
                table: "QuizUserAnswer",
                columns: new[] { "QuizAttemptId", "UserId", "SubmittedTime" },
                principalTable: "QuizAttempt",
                principalColumns: new[] { "QuizDetailId", "UserId", "SubmittedTime" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}

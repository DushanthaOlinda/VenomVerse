using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class quizdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizUserAnswer",
                table: "QuizUserAnswer");

            migrationBuilder.DropColumn(
                name: "QuizType",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Marks",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Question",
                newName: "QuestionStringSinhala");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Question",
                newName: "NoteSinhala");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "QuizUserAnswer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedTime",
                table: "QuizUserAnswer",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Question",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "QuizId",
                table: "Question",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizUserAnswer",
                table: "QuizUserAnswer",
                columns: new[] { "QuizId", "QuestionId", "UserId", "SubmittedTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizUserAnswer",
                table: "QuizUserAnswer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "QuizUserAnswer");

            migrationBuilder.DropColumn(
                name: "SubmittedTime",
                table: "QuizUserAnswer");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "QuestionStringSinhala",
                table: "Question",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "NoteSinhala",
                table: "Question",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "QuizType",
                table: "Quiz",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Question",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Marks",
                table: "Question",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizUserAnswer",
                table: "QuizUserAnswer",
                columns: new[] { "QuizId", "QuestionId" });
        }
    }
}

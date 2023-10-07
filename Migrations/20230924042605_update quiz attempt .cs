using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class updatequizattempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizUserAnswer_Quiz_QuizId_UserId_SubmittedTime",
                table: "QuizUserAnswer");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "QuizUserAnswer",
                newName: "QuizAttemptId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizUserAnswer_QuizId_UserId_SubmittedTime",
                table: "QuizUserAnswer",
                newName: "IX_QuizUserAnswer_QuizAttemptId_UserId_SubmittedTime");

            migrationBuilder.CreateTable(
                name: "QuizAttempt",
                columns: table => new
                {
                    QuizDetailId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SubmittedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalMarks = table.Column<float>(type: "real", nullable: true),
                    AttemptedMarks = table.Column<float>(type: "real", nullable: true),
                    PassMark = table.Column<float>(type: "real", nullable: true),
                    QuizId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAttempt", x => new { x.QuizDetailId, x.UserId, x.SubmittedTime });
                    table.ForeignKey(
                        name: "FK_QuizAttempt_QuizDetail_QuizId",
                        column: x => x.QuizId,
                        principalTable: "QuizDetail",
                        principalColumn: "QuizDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizAttempt_UserDetail_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempt_QuizId",
                table: "QuizAttempt",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempt_UserId",
                table: "QuizAttempt",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUserAnswer_QuizAttempt_QuizAttemptId_UserId_SubmittedTi~",
                table: "QuizUserAnswer",
                columns: new[] { "QuizAttemptId", "UserId", "SubmittedTime" },
                principalTable: "QuizAttempt",
                principalColumns: new[] { "QuizDetailId", "UserId", "SubmittedTime" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizUserAnswer_QuizAttempt_QuizAttemptId_UserId_SubmittedTi~",
                table: "QuizUserAnswer");

            migrationBuilder.DropTable(
                name: "QuizAttempt");

            migrationBuilder.RenameColumn(
                name: "QuizAttemptId",
                table: "QuizUserAnswer",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizUserAnswer_QuizAttemptId_UserId_SubmittedTime",
                table: "QuizUserAnswer",
                newName: "IX_QuizUserAnswer_QuizId_UserId_SubmittedTime");

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    QuizId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SubmittedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AttemptedMarks = table.Column<float>(type: "real", nullable: true),
                    PassMark = table.Column<float>(type: "real", nullable: true),
                    TotalMarks = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => new { x.QuizId, x.UserId, x.SubmittedTime });
                    table.ForeignKey(
                        name: "FK_Quiz_QuizDetail_QuizId",
                        column: x => x.QuizId,
                        principalTable: "QuizDetail",
                        principalColumn: "QuizDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quiz_UserDetail_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UserId",
                table: "Quiz",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUserAnswer_Quiz_QuizId_UserId_SubmittedTime",
                table: "QuizUserAnswer",
                columns: new[] { "QuizId", "UserId", "SubmittedTime" },
                principalTable: "Quiz",
                principalColumns: new[] { "QuizId", "UserId", "SubmittedTime" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}

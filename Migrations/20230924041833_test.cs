using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "RequestService",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "CatcherFeedback",
                table: "RequestService",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "CatcherMedia",
                table: "RequestService",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_QuizDetail_QuizId",
                table: "Quiz",
                column: "QuizId",
                principalTable: "QuizDetail",
                principalColumn: "QuizDetailId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_QuizDetail_QuizId",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "CatcherFeedback",
                table: "RequestService");

            migrationBuilder.DropColumn(
                name: "CatcherMedia",
                table: "RequestService");

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "RequestService",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}

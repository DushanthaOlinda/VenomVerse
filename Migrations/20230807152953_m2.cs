using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_Question_QuestionId",
                table: "UserDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_SerpentInstruction_NegativeVote",
                table: "UserDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_SerpentInstruction_PositiveVote",
                table: "UserDetail");

            migrationBuilder.AlterColumn<long>(
                name: "QuestionId",
                table: "UserDetail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PositiveVote",
                table: "UserDetail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "NegativeVote",
                table: "UserDetail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetail_Question_QuestionId",
                table: "UserDetail",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetail_SerpentInstruction_NegativeVote",
                table: "UserDetail",
                column: "NegativeVote",
                principalTable: "SerpentInstruction",
                principalColumn: "SerpentInstructionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetail_SerpentInstruction_PositiveVote",
                table: "UserDetail",
                column: "PositiveVote",
                principalTable: "SerpentInstruction",
                principalColumn: "SerpentInstructionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_Question_QuestionId",
                table: "UserDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_SerpentInstruction_NegativeVote",
                table: "UserDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_SerpentInstruction_PositiveVote",
                table: "UserDetail");

            migrationBuilder.AlterColumn<long>(
                name: "QuestionId",
                table: "UserDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PositiveVote",
                table: "UserDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NegativeVote",
                table: "UserDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetail_Question_QuestionId",
                table: "UserDetail",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetail_SerpentInstruction_NegativeVote",
                table: "UserDetail",
                column: "NegativeVote",
                principalTable: "SerpentInstruction",
                principalColumn: "SerpentInstructionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetail_SerpentInstruction_PositiveVote",
                table: "UserDetail",
                column: "PositiveVote",
                principalTable: "SerpentInstruction",
                principalColumn: "SerpentInstructionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

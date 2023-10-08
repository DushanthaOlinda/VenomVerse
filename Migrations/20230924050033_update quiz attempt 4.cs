using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class updatequizattempt4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Zoologist_ApprovedUserId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Zoologist_WriterId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_ApprovedUserId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_WriterId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ApprovedUserId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Question");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ApprovedUserId",
                table: "Question",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WriterId",
                table: "Question",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ApprovedUserId",
                table: "Question",
                column: "ApprovedUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_WriterId",
                table: "Question",
                column: "WriterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Zoologist_ApprovedUserId",
                table: "Question",
                column: "ApprovedUserId",
                principalTable: "Zoologist",
                principalColumn: "ZoologistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Zoologist_WriterId",
                table: "Question",
                column: "WriterId",
                principalTable: "Zoologist",
                principalColumn: "ZoologistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class sap122057 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizUserAnswer_Quiz_QuizId",
                table: "QuizUserAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_SerpentInstruction_NegativeVote",
                table: "UserDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_SerpentInstruction_PositiveVote",
                table: "UserDetail");

            migrationBuilder.DropIndex(
                name: "IX_UserDetail_NegativeVote",
                table: "UserDetail");

            migrationBuilder.DropIndex(
                name: "IX_UserDetail_PositiveVote",
                table: "UserDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "Certification",
                table: "Zoologist");

            migrationBuilder.DropColumn(
                name: "NegativeVote",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "PositiveVote",
                table: "UserDetail");

            migrationBuilder.RenameColumn(
                name: "PerssonName",
                table: "EmergencyContact",
                newName: "PersonName");

            migrationBuilder.AlterColumn<long>(
                name: "QuizId",
                table: "Quiz",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<long>(
                name: "ApprovedAdmin",
                table: "CommunityPost",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz",
                columns: new[] { "QuizId", "UserId", "SubmittedTime" });

            migrationBuilder.CreateTable(
                name: "RequestToBeZoologistEvidence",
                columns: table => new
                {
                    RequestToBeZoologistEvidenceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ZoologistId = table.Column<long>(type: "bigint", nullable: false),
                    DegreeName = table.Column<string>(type: "text", nullable: false),
                    University = table.Column<string>(type: "text", nullable: false),
                    GraduatedYear = table.Column<string>(type: "text", nullable: false),
                    SpecialDetails = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestToBeZoologistEvidence", x => x.RequestToBeZoologistEvidenceId);
                    table.ForeignKey(
                        name: "FK_RequestToBeZoologistEvidence_Zoologist_ZoologistId",
                        column: x => x.ZoologistId,
                        principalTable: "Zoologist",
                        principalColumn: "ZoologistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zoologist_ApprovedPersonId",
                table: "Zoologist",
                column: "ApprovedPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SerpentMedia_SerpentId",
                table: "SerpentMedia",
                column: "SerpentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizUserAnswer_QuizId_UserId_SubmittedTime",
                table: "QuizUserAnswer",
                columns: new[] { "QuizId", "UserId", "SubmittedTime" });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPostReport_ComAdminId",
                table: "CommunityPostReport",
                column: "ComAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Catcher_ApprovedPersonIdOne",
                table: "Catcher",
                column: "ApprovedPersonIdOne");

            migrationBuilder.CreateIndex(
                name: "IX_Catcher_ApprovedPersonIdThree",
                table: "Catcher",
                column: "ApprovedPersonIdThree");

            migrationBuilder.CreateIndex(
                name: "IX_Catcher_ApprovedPersonIdTwo",
                table: "Catcher",
                column: "ApprovedPersonIdTwo");

            migrationBuilder.CreateIndex(
                name: "IX_RequestToBeZoologistEvidence_ZoologistId",
                table: "RequestToBeZoologistEvidence",
                column: "ZoologistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdOne",
                table: "Catcher",
                column: "ApprovedPersonIdOne",
                principalTable: "Catcher",
                principalColumn: "CatcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdThree",
                table: "Catcher",
                column: "ApprovedPersonIdThree",
                principalTable: "Catcher",
                principalColumn: "CatcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdTwo",
                table: "Catcher",
                column: "ApprovedPersonIdTwo",
                principalTable: "Catcher",
                principalColumn: "CatcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityPostReport_CommunityAdmin_ComAdminId",
                table: "CommunityPostReport",
                column: "ComAdminId",
                principalTable: "CommunityAdmin",
                principalColumn: "CommunityAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUserAnswer_Quiz_QuizId_UserId_SubmittedTime",
                table: "QuizUserAnswer",
                columns: new[] { "QuizId", "UserId", "SubmittedTime" },
                principalTable: "Quiz",
                principalColumns: new[] { "QuizId", "UserId", "SubmittedTime" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SerpentMedia_Serpent_SerpentId",
                table: "SerpentMedia",
                column: "SerpentId",
                principalTable: "Serpent",
                principalColumn: "SerpentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zoologist_CommunityAdmin_ApprovedPersonId",
                table: "Zoologist",
                column: "ApprovedPersonId",
                principalTable: "CommunityAdmin",
                principalColumn: "CommunityAdminId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdOne",
                table: "Catcher");

            migrationBuilder.DropForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdThree",
                table: "Catcher");

            migrationBuilder.DropForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdTwo",
                table: "Catcher");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityPostReport_CommunityAdmin_ComAdminId",
                table: "CommunityPostReport");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizUserAnswer_Quiz_QuizId_UserId_SubmittedTime",
                table: "QuizUserAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_SerpentMedia_Serpent_SerpentId",
                table: "SerpentMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Zoologist_CommunityAdmin_ApprovedPersonId",
                table: "Zoologist");

            migrationBuilder.DropTable(
                name: "RequestToBeZoologistEvidence");

            migrationBuilder.DropIndex(
                name: "IX_Zoologist_ApprovedPersonId",
                table: "Zoologist");

            migrationBuilder.DropIndex(
                name: "IX_SerpentMedia_SerpentId",
                table: "SerpentMedia");

            migrationBuilder.DropIndex(
                name: "IX_QuizUserAnswer_QuizId_UserId_SubmittedTime",
                table: "QuizUserAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_CommunityPostReport_ComAdminId",
                table: "CommunityPostReport");

            migrationBuilder.DropIndex(
                name: "IX_Catcher_ApprovedPersonIdOne",
                table: "Catcher");

            migrationBuilder.DropIndex(
                name: "IX_Catcher_ApprovedPersonIdThree",
                table: "Catcher");

            migrationBuilder.DropIndex(
                name: "IX_Catcher_ApprovedPersonIdTwo",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedAdmin",
                table: "CommunityPost");

            migrationBuilder.RenameColumn(
                name: "PersonName",
                table: "EmergencyContact",
                newName: "PerssonName");

            migrationBuilder.AddColumn<string[]>(
                name: "Certification",
                table: "Zoologist",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<long>(
                name: "NegativeVote",
                table: "UserDetail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PositiveVote",
                table: "UserDetail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "QuizId",
                table: "Quiz",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_NegativeVote",
                table: "UserDetail",
                column: "NegativeVote");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_PositiveVote",
                table: "UserDetail",
                column: "PositiveVote");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizUserAnswer_Quiz_QuizId",
                table: "QuizUserAnswer",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);

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
    }
}

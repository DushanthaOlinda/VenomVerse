using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeyss19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerpentMedia",
                table: "Serpent");

            migrationBuilder.DropColumn(
                name: "SerpentSafetyInstruction",
                table: "Serpent");

            migrationBuilder.DropColumn(
                name: "OtherSerpentType",
                table: "ScannedImage");

            migrationBuilder.DropColumn(
                name: "PredictionVerification",
                table: "ScannedImage");

            migrationBuilder.DropColumn(
                name: "ServiceRating",
                table: "RequestService");

            migrationBuilder.DropColumn(
                name: "AnswerList",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "CommunityPost");

            migrationBuilder.DropColumn(
                name: "PostReport",
                table: "CommunityPost");

            migrationBuilder.DropColumn(
                name: "ApprovedUserId",
                table: "CommunityBook");

            migrationBuilder.DropColumn(
                name: "ArticleReport",
                table: "CommunityArticle");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "CommunityArticle");

            migrationBuilder.DropColumn(
                name: "CatcherRating",
                table: "Catcher");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "SystemReport",
                newName: "Type");

            migrationBuilder.AlterColumn<long>(
                name: "ZoologistId",
                table: "Zoologist",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<float>(
                name: "CurrentMarks",
                table: "UserDetail",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<long>(
                name: "NegativeVote",
                table: "UserDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PositiveVote",
                table: "UserDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "QuestionId",
                table: "UserDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "Venomous",
                table: "Serpent",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionSinhala",
                table: "Serpent",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpecialNoteSinhala",
                table: "Serpent",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceFeedback",
                table: "RequestService",
                type: "text",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SelectedSerpent",
                table: "RequestService",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ScannedImage",
                table: "RequestService",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CatcherId",
                table: "RequestService",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "RequestService",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RatingComment",
                table: "RequestService",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "ServiceFeedbackMedia",
                table: "RequestService",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedTime",
                table: "Quiz",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Answer01",
                table: "Question",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer02",
                table: "Question",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer03",
                table: "Question",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer04",
                table: "Question",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer05",
                table: "Question",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Correctness01",
                table: "Question",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Correctness02",
                table: "Question",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Correctness03",
                table: "Question",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Correctness04",
                table: "Question",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Correctness05",
                table: "Question",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MultipleAnswers",
                table: "Question",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PostStatus",
                table: "CommunityPost",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "CommunityPost",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ArticleStatus",
                table: "CommunityArticle",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "CommunityAdminId",
                table: "CommunityAdmin",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<long>(
                name: "CommunityBookId",
                table: "CommunityAdmin",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "CommunityArticleUserDetail",
                columns: table => new
                {
                    SavedArticle = table.Column<long>(type: "bigint", nullable: false),
                    UserSavedArticleCommunityArticleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityArticleUserDetail", x => new { x.SavedArticle, x.UserSavedArticleCommunityArticleId });
                    table.ForeignKey(
                        name: "FK_CommunityArticleUserDetail_CommunityArticle_UserSavedArticl~",
                        column: x => x.UserSavedArticleCommunityArticleId,
                        principalTable: "CommunityArticle",
                        principalColumn: "CommunityArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityArticleUserDetail_UserDetail_SavedArticle",
                        column: x => x.SavedArticle,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityArticleUserDetail1",
                columns: table => new
                {
                    React = table.Column<long>(type: "bigint", nullable: false),
                    UserReactUserDetailId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityArticleUserDetail1", x => new { x.React, x.UserReactUserDetailId });
                    table.ForeignKey(
                        name: "FK_CommunityArticleUserDetail1_CommunityArticle_React",
                        column: x => x.React,
                        principalTable: "CommunityArticle",
                        principalColumn: "CommunityArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityArticleUserDetail1_UserDetail_UserReactUserDetailId",
                        column: x => x.UserReactUserDetailId,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityBookUserDetail",
                columns: table => new
                {
                    CommunityBookPurchasedCommunityBookId = table.Column<long>(type: "bigint", nullable: false),
                    PurchasedBook = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityBookUserDetail", x => new { x.CommunityBookPurchasedCommunityBookId, x.PurchasedBook });
                    table.ForeignKey(
                        name: "FK_CommunityBookUserDetail_CommunityBook_CommunityBookPurchase~",
                        column: x => x.CommunityBookPurchasedCommunityBookId,
                        principalTable: "CommunityBook",
                        principalColumn: "CommunityBookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityBookUserDetail_UserDetail_PurchasedBook",
                        column: x => x.PurchasedBook,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityBookUserDetail1",
                columns: table => new
                {
                    CommunityBookSavedCommunityBookId = table.Column<long>(type: "bigint", nullable: false),
                    SavedBook = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityBookUserDetail1", x => new { x.CommunityBookSavedCommunityBookId, x.SavedBook });
                    table.ForeignKey(
                        name: "FK_CommunityBookUserDetail1_CommunityBook_CommunityBookSavedCo~",
                        column: x => x.CommunityBookSavedCommunityBookId,
                        principalTable: "CommunityBook",
                        principalColumn: "CommunityBookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityBookUserDetail1_UserDetail_SavedBook",
                        column: x => x.SavedBook,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityPostUserDetail",
                columns: table => new
                {
                    SavedPost = table.Column<long>(type: "bigint", nullable: false),
                    UserSavedPostCommunityPostId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityPostUserDetail", x => new { x.SavedPost, x.UserSavedPostCommunityPostId });
                    table.ForeignKey(
                        name: "FK_CommunityPostUserDetail_CommunityPost_UserSavedPostCommunit~",
                        column: x => x.UserSavedPostCommunityPostId,
                        principalTable: "CommunityPost",
                        principalColumn: "CommunityPostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityPostUserDetail_UserDetail_SavedPost",
                        column: x => x.SavedPost,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityPostUserDetail1",
                columns: table => new
                {
                    React = table.Column<long>(type: "bigint", nullable: false),
                    UserPostReactUserDetailId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityPostUserDetail1", x => new { x.React, x.UserPostReactUserDetailId });
                    table.ForeignKey(
                        name: "FK_CommunityPostUserDetail1_CommunityPost_React",
                        column: x => x.React,
                        principalTable: "CommunityPost",
                        principalColumn: "CommunityPostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityPostUserDetail1_UserDetail_UserPostReactUserDetail~",
                        column: x => x.UserPostReactUserDetailId,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityResearch",
                columns: table => new
                {
                    CommunityResearchId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Media = table.Column<string[]>(type: "text[]", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: true),
                    PublishedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PostCopyright = table.Column<string[]>(type: "text[]", nullable: true),
                    SavedResearch = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityResearch", x => x.CommunityResearchId);
                    table.ForeignKey(
                        name: "FK_CommunityResearch_UserDetail_SavedResearch",
                        column: x => x.SavedResearch,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId");
                    table.ForeignKey(
                        name: "FK_CommunityResearch_Zoologist_UserId",
                        column: x => x.UserId,
                        principalTable: "Zoologist",
                        principalColumn: "ZoologistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerpentInstruction",
                columns: table => new
                {
                    SerpentInstructionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SerpentId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    WittenUser = table.Column<long>(type: "bigint", nullable: false),
                    PositiveVote = table.Column<long[]>(type: "bigint[]", nullable: true),
                    NegativeVote = table.Column<long[]>(type: "bigint[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerpentInstruction", x => x.SerpentInstructionId);
                    table.ForeignKey(
                        name: "FK_SerpentInstruction_Serpent_SerpentId",
                        column: x => x.SerpentId,
                        principalTable: "Serpent",
                        principalColumn: "SerpentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerpentInstruction_UserDetail_WittenUser",
                        column: x => x.WittenUser,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_NegativeVote",
                table: "UserDetail",
                column: "NegativeVote");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_PositiveVote",
                table: "UserDetail",
                column: "PositiveVote");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_QuestionId",
                table: "UserDetail",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemReport_GeneratedUserId",
                table: "SystemReport",
                column: "GeneratedUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImage_ActualSerpentType",
                table: "ScannedImage",
                column: "ActualSerpentType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImage_PredictedSerpentType",
                table: "ScannedImage",
                column: "PredictedSerpentType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImage_UploadedUserId",
                table: "ScannedImage",
                column: "UploadedUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_CatcherId",
                table: "RequestService",
                column: "CatcherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_ReqUserId",
                table: "RequestService",
                column: "ReqUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_ScannedImage",
                table: "RequestService",
                column: "ScannedImage",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestService_SelectedSerpent",
                table: "RequestService",
                column: "SelectedSerpent",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UserId",
                table: "Quiz",
                column: "UserId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPost_UserId",
                table: "CommunityPost",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityBook_UploadedUserId",
                table: "CommunityBook",
                column: "UploadedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityArticle_ApprovedUserId",
                table: "CommunityArticle",
                column: "ApprovedUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityArticle_UserId",
                table: "CommunityArticle",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityAdmin_CommunityBookId",
                table: "CommunityAdmin",
                column: "CommunityBookId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityArticleUserDetail_UserSavedArticleCommunityArticle~",
                table: "CommunityArticleUserDetail",
                column: "UserSavedArticleCommunityArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityArticleUserDetail1_UserReactUserDetailId",
                table: "CommunityArticleUserDetail1",
                column: "UserReactUserDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityBookUserDetail_PurchasedBook",
                table: "CommunityBookUserDetail",
                column: "PurchasedBook");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityBookUserDetail1_SavedBook",
                table: "CommunityBookUserDetail1",
                column: "SavedBook");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPostUserDetail_UserSavedPostCommunityPostId",
                table: "CommunityPostUserDetail",
                column: "UserSavedPostCommunityPostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPostUserDetail1_UserPostReactUserDetailId",
                table: "CommunityPostUserDetail1",
                column: "UserPostReactUserDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityResearch_SavedResearch",
                table: "CommunityResearch",
                column: "SavedResearch");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityResearch_UserId",
                table: "CommunityResearch",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SerpentInstruction_SerpentId",
                table: "SerpentInstruction",
                column: "SerpentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SerpentInstruction_WittenUser",
                table: "SerpentInstruction",
                column: "WittenUser");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityAdmin_CommunityBook_CommunityBookId",
                table: "CommunityAdmin",
                column: "CommunityBookId",
                principalTable: "CommunityBook",
                principalColumn: "CommunityBookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityAdmin_UserDetail_CommunityAdminId",
                table: "CommunityAdmin",
                column: "CommunityAdminId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityArticle_CommunityAdmin_ApprovedUserId",
                table: "CommunityArticle",
                column: "ApprovedUserId",
                principalTable: "CommunityAdmin",
                principalColumn: "CommunityAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityArticle_UserDetail_UserId",
                table: "CommunityArticle",
                column: "UserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityBook_Zoologist_UploadedUserId",
                table: "CommunityBook",
                column: "UploadedUserId",
                principalTable: "Zoologist",
                principalColumn: "ZoologistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityPost_UserDetail_UserId",
                table: "CommunityPost",
                column: "UserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_UserDetail_UserId",
                table: "Notification",
                column: "UserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_UserDetail_UserId",
                table: "Quiz",
                column: "UserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService",
                column: "CatcherId",
                principalTable: "Catcher",
                principalColumn: "CatcherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestService_ScannedImage_ScannedImage",
                table: "RequestService",
                column: "ScannedImage",
                principalTable: "ScannedImage",
                principalColumn: "ScannedImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestService_Serpent_SelectedSerpent",
                table: "RequestService",
                column: "SelectedSerpent",
                principalTable: "Serpent",
                principalColumn: "SerpentId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestService_UserDetail_ReqUserId",
                table: "RequestService",
                column: "ReqUserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScannedImage_Serpent_ActualSerpentType",
                table: "ScannedImage",
                column: "ActualSerpentType",
                principalTable: "Serpent",
                principalColumn: "SerpentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScannedImage_Serpent_PredictedSerpentType",
                table: "ScannedImage",
                column: "PredictedSerpentType",
                principalTable: "Serpent",
                principalColumn: "SerpentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScannedImage_UserDetail_UploadedUserId",
                table: "ScannedImage",
                column: "UploadedUserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemReport_SystemAdmin_GeneratedUserId",
                table: "SystemReport",
                column: "GeneratedUserId",
                principalTable: "SystemAdmin",
                principalColumn: "SystemAdminId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Zoologist_UserDetail_ZoologistId",
                table: "Zoologist",
                column: "ZoologistId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommunityAdmin_CommunityBook_CommunityBookId",
                table: "CommunityAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityAdmin_UserDetail_CommunityAdminId",
                table: "CommunityAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityArticle_CommunityAdmin_ApprovedUserId",
                table: "CommunityArticle");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityArticle_UserDetail_UserId",
                table: "CommunityArticle");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityBook_Zoologist_UploadedUserId",
                table: "CommunityBook");

            migrationBuilder.DropForeignKey(
                name: "FK_CommunityPost_UserDetail_UserId",
                table: "CommunityPost");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_UserDetail_UserId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Zoologist_ApprovedUserId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Zoologist_WriterId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_UserDetail_UserId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestService_ScannedImage_ScannedImage",
                table: "RequestService");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestService_Serpent_SelectedSerpent",
                table: "RequestService");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestService_UserDetail_ReqUserId",
                table: "RequestService");

            migrationBuilder.DropForeignKey(
                name: "FK_ScannedImage_Serpent_ActualSerpentType",
                table: "ScannedImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ScannedImage_Serpent_PredictedSerpentType",
                table: "ScannedImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ScannedImage_UserDetail_UploadedUserId",
                table: "ScannedImage");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemReport_SystemAdmin_GeneratedUserId",
                table: "SystemReport");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_Question_QuestionId",
                table: "UserDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_SerpentInstruction_NegativeVote",
                table: "UserDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetail_SerpentInstruction_PositiveVote",
                table: "UserDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Zoologist_UserDetail_ZoologistId",
                table: "Zoologist");

            migrationBuilder.DropTable(
                name: "CommunityArticleUserDetail");

            migrationBuilder.DropTable(
                name: "CommunityArticleUserDetail1");

            migrationBuilder.DropTable(
                name: "CommunityBookUserDetail");

            migrationBuilder.DropTable(
                name: "CommunityBookUserDetail1");

            migrationBuilder.DropTable(
                name: "CommunityPostUserDetail");

            migrationBuilder.DropTable(
                name: "CommunityPostUserDetail1");

            migrationBuilder.DropTable(
                name: "CommunityResearch");

            migrationBuilder.DropTable(
                name: "SerpentInstruction");

            migrationBuilder.DropIndex(
                name: "IX_UserDetail_NegativeVote",
                table: "UserDetail");

            migrationBuilder.DropIndex(
                name: "IX_UserDetail_PositiveVote",
                table: "UserDetail");

            migrationBuilder.DropIndex(
                name: "IX_UserDetail_QuestionId",
                table: "UserDetail");

            migrationBuilder.DropIndex(
                name: "IX_SystemReport_GeneratedUserId",
                table: "SystemReport");

            migrationBuilder.DropIndex(
                name: "IX_ScannedImage_ActualSerpentType",
                table: "ScannedImage");

            migrationBuilder.DropIndex(
                name: "IX_ScannedImage_PredictedSerpentType",
                table: "ScannedImage");

            migrationBuilder.DropIndex(
                name: "IX_ScannedImage_UploadedUserId",
                table: "ScannedImage");

            migrationBuilder.DropIndex(
                name: "IX_RequestService_CatcherId",
                table: "RequestService");

            migrationBuilder.DropIndex(
                name: "IX_RequestService_ReqUserId",
                table: "RequestService");

            migrationBuilder.DropIndex(
                name: "IX_RequestService_ScannedImage",
                table: "RequestService");

            migrationBuilder.DropIndex(
                name: "IX_RequestService_SelectedSerpent",
                table: "RequestService");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_UserId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Question_ApprovedUserId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_WriterId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Notification_UserId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_CommunityPost_UserId",
                table: "CommunityPost");

            migrationBuilder.DropIndex(
                name: "IX_CommunityBook_UploadedUserId",
                table: "CommunityBook");

            migrationBuilder.DropIndex(
                name: "IX_CommunityArticle_ApprovedUserId",
                table: "CommunityArticle");

            migrationBuilder.DropIndex(
                name: "IX_CommunityArticle_UserId",
                table: "CommunityArticle");

            migrationBuilder.DropIndex(
                name: "IX_CommunityAdmin_CommunityBookId",
                table: "CommunityAdmin");

            migrationBuilder.DropColumn(
                name: "CurrentMarks",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "NegativeVote",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "PositiveVote",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "DescriptionSinhala",
                table: "Serpent");

            migrationBuilder.DropColumn(
                name: "SpecialNoteSinhala",
                table: "Serpent");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "RequestService");

            migrationBuilder.DropColumn(
                name: "RatingComment",
                table: "RequestService");

            migrationBuilder.DropColumn(
                name: "ServiceFeedbackMedia",
                table: "RequestService");

            migrationBuilder.DropColumn(
                name: "SubmittedTime",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "Answer01",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Answer02",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Answer03",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Answer04",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Answer05",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Correctness01",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Correctness02",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Correctness03",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Correctness04",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Correctness05",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "MultipleAnswers",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "PostStatus",
                table: "CommunityPost");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CommunityPost");

            migrationBuilder.DropColumn(
                name: "ArticleStatus",
                table: "CommunityArticle");

            migrationBuilder.DropColumn(
                name: "CommunityBookId",
                table: "CommunityAdmin");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "SystemReport",
                newName: "type");

            migrationBuilder.AlterColumn<long>(
                name: "ZoologistId",
                table: "Zoologist",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<float>(
                name: "Venomous",
                table: "Serpent",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string[]>(
                name: "SerpentMedia",
                table: "Serpent",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "SerpentSafetyInstruction",
                table: "Serpent",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherSerpentType",
                table: "ScannedImage",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "PredictionVerification",
                table: "ScannedImage",
                type: "text[]",
                nullable: true);

            migrationBuilder.AlterColumn<string[]>(
                name: "ServiceFeedback",
                table: "RequestService",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SelectedSerpent",
                table: "RequestService",
                type: "text",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string[]>(
                name: "ScannedImage",
                table: "RequestService",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CatcherId",
                table: "RequestService",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<float>(
                name: "ServiceRating",
                table: "RequestService",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "AnswerList",
                table: "Question",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "Comment",
                table: "CommunityPost",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "PostReport",
                table: "CommunityPost",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ApprovedUserId",
                table: "CommunityBook",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "ArticleReport",
                table: "CommunityArticle",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Comment",
                table: "CommunityArticle",
                type: "text[]",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CommunityAdminId",
                table: "CommunityAdmin",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<string[]>(
                name: "CatcherRating",
                table: "Catcher",
                type: "text[]",
                nullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class Modelspartialycreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedDateOne",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedDateThree",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedDateTwo",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedPersonIdOne",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedPersonIdThree",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedPersonIdTwo",
                table: "Catcher");

            migrationBuilder.RenameColumn(
                name: "ApprovedPersonId",
                table: "Zoologist",
                newName: "RequestId");

            migrationBuilder.AddColumn<long[]>(
                name: "PurchasedBook",
                table: "UserDetail",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<long[]>(
                name: "SavedArticle",
                table: "UserDetail",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<long[]>(
                name: "SavedBook",
                table: "UserDetail",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<long[]>(
                name: "SavedPost",
                table: "UserDetail",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<long[]>(
                name: "SavedResearch",
                table: "UserDetail",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<string[,]>(
                name: "Comment",
                table: "CommunityPost",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string[,]>(
                name: "PostReport",
                table: "CommunityPost",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<long[]>(
                name: "React",
                table: "CommunityPost",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RequestId",
                table: "Catcher",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "CommunityArticle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Media = table.Column<string[]>(type: "text[]", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: true),
                    ApprovedUserId = table.Column<long>(type: "bigint", nullable: true),
                    React = table.Column<long[]>(type: "bigint[]", nullable: true),
                    Comment = table.Column<string[,]>(type: "text[]", nullable: true),
                    ArticleReport = table.Column<string[,]>(type: "text[]", nullable: true),
                    ArticleCopyright = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityArticle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunityBook",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Availability = table.Column<bool>(type: "boolean", nullable: false),
                    Media = table.Column<string[]>(type: "text[]", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: true),
                    PublishedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UploadedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UploadedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedUserId = table.Column<long>(type: "bigint", nullable: true),
                    BookCopyright = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityBook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestService",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ReqUserId = table.Column<long>(type: "bigint", nullable: false),
                    catcherId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ScannedImage = table.Column<string[]>(type: "text[]", nullable: true),
                    SelectedSerpent = table.Column<string>(type: "text", nullable: true),
                    AcceptFlag = table.Column<bool>(type: "boolean", nullable: false),
                    CompleteFlag = table.Column<bool>(type: "boolean", nullable: false),
                    ServiceFeedback = table.Column<string[]>(type: "text[]", nullable: true),
                    ServiceRating = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestToBeCatcher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CatcherEvidence = table.Column<string[]>(type: "text[]", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SpecialNote = table.Column<string>(type: "text", nullable: false),
                    ApprovedPersonIdOne = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDateOne = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedPersonIdTwo = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDateTwo = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedPersonIdThree = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDateThree = table.Column<DateOnly>(type: "date", nullable: true),
                    JoinedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestToBeCatcher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestToBeZoologist",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SpecialNote = table.Column<string>(type: "text", nullable: false),
                    ZoologistCertification = table.Column<string[,]>(type: "text[]", nullable: false),
                    ApprovedPersonId = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestToBeZoologist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemAdmin",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    JoinedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserEmail = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Nic = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemReport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    type = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GeneratedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemReport", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityArticle");

            migrationBuilder.DropTable(
                name: "CommunityBook");

            migrationBuilder.DropTable(
                name: "RequestService");

            migrationBuilder.DropTable(
                name: "RequestToBeCatcher");

            migrationBuilder.DropTable(
                name: "RequestToBeZoologist");

            migrationBuilder.DropTable(
                name: "SystemAdmin");

            migrationBuilder.DropTable(
                name: "SystemReport");

            migrationBuilder.DropColumn(
                name: "PurchasedBook",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "SavedArticle",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "SavedBook",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "SavedPost",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "SavedResearch",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "CommunityPost");

            migrationBuilder.DropColumn(
                name: "PostReport",
                table: "CommunityPost");

            migrationBuilder.DropColumn(
                name: "React",
                table: "CommunityPost");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Catcher");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "Zoologist",
                newName: "ApprovedPersonId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ApprovedDateOne",
                table: "Catcher",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ApprovedDateThree",
                table: "Catcher",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ApprovedDateTwo",
                table: "Catcher",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ApprovedPersonIdOne",
                table: "Catcher",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ApprovedPersonIdThree",
                table: "Catcher",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ApprovedPersonIdTwo",
                table: "Catcher",
                type: "bigint",
                nullable: true);
        }
    }
}

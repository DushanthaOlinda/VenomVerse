using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
                columns: table => new
                {
                    EmergencyContactId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EmergencyContactNumber = table.Column<string>(type: "text", nullable: false),
                    HospitalName = table.Column<string>(type: "text", nullable: true),
                    PerssonName = table.Column<string>(type: "text", nullable: true),
                    Profession = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EmergencySpecialNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContact", x => x.EmergencyContactId);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationRequest",
                columns: table => new
                {
                    RegistrationRequestId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationRequest", x => x.RegistrationRequestId);
                });

            migrationBuilder.CreateTable(
                name: "Serpent",
                columns: table => new
                {
                    SerpentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ScientificName = table.Column<string>(type: "text", nullable: false),
                    EnglishName = table.Column<string>(type: "text", nullable: false),
                    SinhalaName = table.Column<string>(type: "text", nullable: false),
                    Venomous = table.Column<float>(type: "real", nullable: false),
                    Family = table.Column<string>(type: "text", nullable: false),
                    SubFamily = table.Column<string>(type: "text", nullable: false),
                    Genus = table.Column<string>(type: "text", nullable: false),
                    SpecialNote = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SerpentMedia = table.Column<string[,]>(type: "text[]", nullable: true),
                    SerpentSafetyInstruction = table.Column<string[,]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serpent", x => x.SerpentId);
                });

            migrationBuilder.CreateTable(
                name: "SystemAdmin",
                columns: table => new
                {
                    SystemAdminId = table.Column<long>(type: "bigint", nullable: false)
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
                    table.PrimaryKey("PK_SystemAdmin", x => x.SystemAdminId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemReport",
                columns: table => new
                {
                    SystemReportId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GeneratedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemReport", x => x.SystemReportId);
                    table.ForeignKey(
                        name: "FK_SystemReport_SystemAdmin_SystemReportId",
                        column: x => x.SystemReportId,
                        principalTable: "SystemAdmin",
                        principalColumn: "SystemAdminId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catcher",
                columns: table => new
                {
                    CatcherId = table.Column<long>(type: "bigint", nullable: false),
                    Availability = table.Column<bool>(type: "boolean", nullable: false),
                    ChargingFee = table.Column<float>(type: "real", nullable: true),
                    CatcherRating = table.Column<string[,]>(type: "text[]", nullable: true),
                    RequestedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CatcherEvidence = table.Column<string[]>(type: "text[]", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SpecialNote = table.Column<string>(type: "text", nullable: true),
                    ApprovedPersonIdOne = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDateOne = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedPersonIdTwo = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDateTwo = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedPersonIdThree = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDateThree = table.Column<DateOnly>(type: "date", nullable: true),
                    JoinedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedFlag = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catcher", x => x.CatcherId);
                });

            migrationBuilder.CreateTable(
                name: "CommunityAdmin",
                columns: table => new
                {
                    CommunityAdminId = table.Column<long>(type: "bigint", nullable: false),
                    JoinedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CommunityBookId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityAdmin", x => x.CommunityAdminId);
                });

            migrationBuilder.CreateTable(
                name: "CommunityArticle",
                columns: table => new
                {
                    CommunityArticleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_CommunityArticle", x => x.CommunityArticleId);
                    table.ForeignKey(
                        name: "FK_CommunityArticle_CommunityAdmin_ApprovedUserId",
                        column: x => x.ApprovedUserId,
                        principalTable: "CommunityAdmin",
                        principalColumn: "CommunityAdminId");
                });

            migrationBuilder.CreateTable(
                name: "CommunityBook",
                columns: table => new
                {
                    CommunityBookId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Availability = table.Column<bool>(type: "boolean", nullable: false),
                    Media = table.Column<string[]>(type: "text[]", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: false),
                    PublishedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UploadedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UploadedUserId = table.Column<long>(type: "bigint", nullable: false),
                    BookCopyright = table.Column<string[]>(type: "text[]", nullable: true),
                    SavedBook = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityBook", x => x.CommunityBookId);
                });

            migrationBuilder.CreateTable(
                name: "CommunityPost",
                columns: table => new
                {
                    CommunityPostId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Media = table.Column<string[]>(type: "text[]", nullable: true),
                    React = table.Column<long[]>(type: "bigint[]", nullable: true),
                    Comment = table.Column<string[,]>(type: "text[]", nullable: true),
                    PostReport = table.Column<string[,]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityPost", x => x.CommunityPostId);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    QuestionString = table.Column<string>(type: "text", nullable: false),
                    QuestionMedia = table.Column<string[]>(type: "text[]", nullable: true),
                    Difficulty = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Marks = table.Column<float>(type: "real", nullable: false),
                    WriterId = table.Column<long>(type: "bigint", nullable: false),
                    ApprovedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AnswerList = table.Column<string[,]>(type: "text[]", nullable: false),
                    Published = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    UserDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserEmail = table.Column<string>(type: "text", nullable: false),
                    CurrentMarks = table.Column<float>(type: "real", nullable: false),
                    Nic = table.Column<string>(type: "text", nullable: false),
                    Dob = table.Column<DateOnly>(type: "date", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ContactNo = table.Column<string>(type: "text", nullable: false),
                    WorkingStatus = table.Column<string>(type: "text", nullable: false),
                    SavedBook = table.Column<long[]>(type: "bigint[]", nullable: true),
                    SavedArticle = table.Column<long[]>(type: "bigint[]", nullable: true),
                    SavedPost = table.Column<long[]>(type: "bigint[]", nullable: true),
                    SavedResearch = table.Column<long[]>(type: "bigint[]", nullable: true),
                    PurchasedBook = table.Column<long[]>(type: "bigint[]", nullable: true),
                    ExpertPrevilege = table.Column<bool>(type: "boolean", nullable: false),
                    ZoologistPrevilege = table.Column<bool>(type: "boolean", nullable: false),
                    CatcherPrevilege = table.Column<bool>(type: "boolean", nullable: false),
                    CommunityAdminPrevilege = table.Column<bool>(type: "boolean", nullable: false),
                    AccountStatus = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.UserDetailId);
                    table.ForeignKey(
                        name: "FK_UserDetail_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    QuizId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    QuizType = table.Column<string>(type: "text", nullable: false),
                    TotalMarks = table.Column<float>(type: "real", nullable: true),
                    AttemptedMarks = table.Column<float>(type: "real", nullable: true),
                    PassMark = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.QuizId);
                    table.ForeignKey(
                        name: "FK_Quiz_UserDetail_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestService",
                columns: table => new
                {
                    RequestServiceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ReqUserId = table.Column<long>(type: "bigint", nullable: false),
                    CatcherId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ScannedImageId = table.Column<long>(type: "bigint", nullable: true),
                    SelectedSerpent = table.Column<long>(type: "bigint", nullable: true),
                    AcceptFlag = table.Column<bool>(type: "boolean", nullable: false),
                    CompleteFlag = table.Column<bool>(type: "boolean", nullable: false),
                    FakeReqFlag = table.Column<bool>(type: "boolean", nullable: false),
                    ServiceFeedback = table.Column<string[]>(type: "text[]", nullable: true),
                    ServiceRating = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestService", x => x.RequestServiceId);
                    table.ForeignKey(
                        name: "FK_RequestService_Catcher_CatcherId",
                        column: x => x.CatcherId,
                        principalTable: "Catcher",
                        principalColumn: "CatcherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestService_Serpent_SelectedSerpent",
                        column: x => x.SelectedSerpent,
                        principalTable: "Serpent",
                        principalColumn: "SerpentId");
                    table.ForeignKey(
                        name: "FK_RequestService_UserDetail_ReqUserId",
                        column: x => x.ReqUserId,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zoologist",
                columns: table => new
                {
                    ZoologistId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SpecialNote = table.Column<string>(type: "text", nullable: true),
                    Certification = table.Column<string[,]>(type: "text[]", nullable: false),
                    RequestedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApprovedPersonId = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoologist", x => x.ZoologistId);
                    table.ForeignKey(
                        name: "FK_Zoologist_UserDetail_ZoologistId",
                        column: x => x.ZoologistId,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedImage",
                columns: table => new
                {
                    ScannedImageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UploadedUserId = table.Column<long>(type: "bigint", nullable: false),
                    ScannedImageMedia = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PredictedSerpentType = table.Column<long>(type: "bigint", nullable: true),
                    ActualSerpentType = table.Column<long[]>(type: "bigint[]", nullable: true),
                    OtherSerpentType = table.Column<string>(type: "text", nullable: true),
                    Accuracy = table.Column<float>(type: "real", nullable: true),
                    PredictionSuccess = table.Column<bool>(type: "boolean", nullable: true),
                    PredictionVerification = table.Column<string[,]>(type: "text[]", nullable: true),
                    ScannedImgId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedImage", x => x.ScannedImageId);
                    table.ForeignKey(
                        name: "FK_ScannedImage_RequestService_ScannedImgId",
                        column: x => x.ScannedImgId,
                        principalTable: "RequestService",
                        principalColumn: "RequestServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScannedImage_Serpent_PredictedSerpentType",
                        column: x => x.PredictedSerpentType,
                        principalTable: "Serpent",
                        principalColumn: "SerpentId");
                    table.ForeignKey(
                        name: "FK_ScannedImage_UserDetail_UploadedUserId",
                        column: x => x.UploadedUserId,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScannedImageSerpent",
                columns: table => new
                {
                    ActualSerpentSerpentId = table.Column<long>(type: "bigint", nullable: false),
                    ScannedImageActualResultScannedImageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedImageSerpent", x => new { x.ActualSerpentSerpentId, x.ScannedImageActualResultScannedImageId });
                    table.ForeignKey(
                        name: "FK_ScannedImageSerpent_ScannedImage_ScannedImageActualResultSc~",
                        column: x => x.ScannedImageActualResultScannedImageId,
                        principalTable: "ScannedImage",
                        principalColumn: "ScannedImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScannedImageSerpent_Serpent_ActualSerpentSerpentId",
                        column: x => x.ActualSerpentSerpentId,
                        principalTable: "Serpent",
                        principalColumn: "SerpentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityAdmin_CommunityBookId",
                table: "CommunityAdmin",
                column: "CommunityBookId");

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
                name: "IX_CommunityBook_SavedBook",
                table: "CommunityBook",
                column: "SavedBook");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityBook_UploadedUserId",
                table: "CommunityBook",
                column: "UploadedUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPost_UserId",
                table: "CommunityPost",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ApprovedUserId",
                table: "Question",
                column: "ApprovedUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UserId",
                table: "Quiz",
                column: "UserId",
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
                name: "IX_RequestService_SelectedSerpent",
                table: "RequestService",
                column: "SelectedSerpent",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImage_PredictedSerpentType",
                table: "ScannedImage",
                column: "PredictedSerpentType");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImage_ScannedImgId",
                table: "ScannedImage",
                column: "ScannedImgId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImage_UploadedUserId",
                table: "ScannedImage",
                column: "UploadedUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImageSerpent_ScannedImageActualResultScannedImageId",
                table: "ScannedImageSerpent",
                column: "ScannedImageActualResultScannedImageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetail_QuestionId",
                table: "UserDetail",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_UserDetail_CatcherId",
                table: "Catcher",
                column: "CatcherId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_CommunityArticle_UserDetail_UserId",
                table: "CommunityArticle",
                column: "UserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityBook_UserDetail_SavedBook",
                table: "CommunityBook",
                column: "SavedBook",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zoologist_UserDetail_ZoologistId",
                table: "Zoologist");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CommunityArticle");

            migrationBuilder.DropTable(
                name: "CommunityPost");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "RegistrationRequest");

            migrationBuilder.DropTable(
                name: "ScannedImageSerpent");

            migrationBuilder.DropTable(
                name: "SystemReport");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CommunityAdmin");

            migrationBuilder.DropTable(
                name: "ScannedImage");

            migrationBuilder.DropTable(
                name: "SystemAdmin");

            migrationBuilder.DropTable(
                name: "CommunityBook");

            migrationBuilder.DropTable(
                name: "RequestService");

            migrationBuilder.DropTable(
                name: "Catcher");

            migrationBuilder.DropTable(
                name: "Serpent");

            migrationBuilder.DropTable(
                name: "UserDetail");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Zoologist");
        }
    }
}

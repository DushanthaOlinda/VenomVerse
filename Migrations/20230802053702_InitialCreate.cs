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
                name: "CommunityAdmin",
                columns: table => new
                {
                    CommunityAdminId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    JoinedDate = table.Column<DateOnly>(type: "date", nullable: true)
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
                    ApprovedUserId = table.Column<long>(type: "bigint", nullable: true),
                    BookCopyright = table.Column<string[]>(type: "text[]", nullable: true)
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
                name: "RequestService",
                columns: table => new
                {
                    RequestServiceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ReqUserId = table.Column<long>(type: "bigint", nullable: false),
                    CatcherId = table.Column<long>(type: "bigint", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ScannedImage = table.Column<string[]>(type: "text[]", nullable: true),
                    SelectedSerpent = table.Column<string>(type: "text", nullable: true),
                    AcceptFlag = table.Column<bool>(type: "boolean", nullable: false),
                    CompleteFlag = table.Column<bool>(type: "boolean", nullable: false),
                    FakeReqFlag = table.Column<bool>(type: "boolean", nullable: false),
                    ServiceFeedback = table.Column<string[]>(type: "text[]", nullable: true),
                    ServiceRating = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestService", x => x.RequestServiceId);
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
                    ActualSerpentType = table.Column<long>(type: "bigint", nullable: true),
                    OtherSerpentType = table.Column<string>(type: "text", nullable: true),
                    Accuracy = table.Column<float>(type: "real", nullable: true),
                    PredictionSuccess = table.Column<bool>(type: "boolean", nullable: true),
                    PredictionVerification = table.Column<string[,]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedImage", x => x.ScannedImageId);
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
                name: "SystemReport",
                columns: table => new
                {
                    SystemReportId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    type = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GeneratedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemReport", x => x.SystemReportId);
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
                    AccountStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.UserDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Zoologist",
                columns: table => new
                {
                    ZoologistId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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
                    table.ForeignKey(
                        name: "FK_Catcher_UserDetail_CatcherId",
                        column: x => x.CatcherId,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Catcher");

            migrationBuilder.DropTable(
                name: "CommunityAdmin");

            migrationBuilder.DropTable(
                name: "CommunityArticle");

            migrationBuilder.DropTable(
                name: "CommunityBook");

            migrationBuilder.DropTable(
                name: "CommunityPost");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "RegistrationRequest");

            migrationBuilder.DropTable(
                name: "RequestService");

            migrationBuilder.DropTable(
                name: "ScannedImage");

            migrationBuilder.DropTable(
                name: "Serpent");

            migrationBuilder.DropTable(
                name: "SystemAdmin");

            migrationBuilder.DropTable(
                name: "SystemReport");

            migrationBuilder.DropTable(
                name: "Zoologist");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserDetail");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class relationshipfixed9 : Migration
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
                    Venomous = table.Column<int>(type: "integer", nullable: false),
                    Family = table.Column<string>(type: "text", nullable: false),
                    SubFamily = table.Column<string>(type: "text", nullable: false),
                    Genus = table.Column<string>(type: "text", nullable: false),
                    SpecialNote = table.Column<string>(type: "text", nullable: true),
                    SpecialNoteSinhala = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DescriptionSinhala = table.Column<string>(type: "text", nullable: false)
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
                name: "SerpentMedia",
                columns: table => new
                {
                    SerpentMediaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    SerpentId = table.Column<long>(type: "bigint", nullable: false),
                    SerpentMediaDescription = table.Column<string>(type: "text", nullable: true),
                    SerpentMediaAltText = table.Column<string>(type: "text", nullable: true),
                    SerpentMediaSource = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerpentMedia", x => x.SerpentMediaId);
                    table.ForeignKey(
                        name: "FK_SerpentMedia_Serpent_SerpentId",
                        column: x => x.SerpentId,
                        principalTable: "Serpent",
                        principalColumn: "SerpentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemReport",
                columns: table => new
                {
                    SystemReportId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GeneratedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemReport", x => x.SystemReportId);
                    table.ForeignKey(
                        name: "FK_SystemReport_SystemAdmin_GeneratedUserId",
                        column: x => x.GeneratedUserId,
                        principalTable: "SystemAdmin",
                        principalColumn: "SystemAdminId");
                });

            migrationBuilder.CreateTable(
                name: "Catcher",
                columns: table => new
                {
                    CatcherId = table.Column<long>(type: "bigint", nullable: false),
                    Availability = table.Column<bool>(type: "boolean", nullable: false),
                    ChargingFee = table.Column<float>(type: "real", nullable: true),
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
                name: "CatcherRating",
                columns: table => new
                {
                    CatcherRatingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CatcherId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Rate = table.Column<int>(type: "integer", nullable: false),
                    RatingComment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatcherRating", x => x.CatcherRatingId);
                    table.ForeignKey(
                        name: "FK_CatcherRating_Catcher_CatcherId",
                        column: x => x.CatcherId,
                        principalTable: "Catcher",
                        principalColumn: "CatcherId",
                        onDelete: ReferentialAction.Cascade);
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
                    ArticleStatus = table.Column<int>(type: "integer", nullable: false),
                    ApprovedUserId = table.Column<long>(type: "bigint", nullable: true),
                    React = table.Column<long[]>(type: "bigint[]", nullable: true),
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
                name: "CommunityArticleComment",
                columns: table => new
                {
                    CommunityArticleCommentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommunityArticleId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityArticleComment", x => x.CommunityArticleCommentId);
                    table.ForeignKey(
                        name: "FK_CommunityArticleComment_CommunityArticle_CommunityArticleId",
                        column: x => x.CommunityArticleId,
                        principalTable: "CommunityArticle",
                        principalColumn: "CommunityArticleId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    BookCopyright = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityBook", x => x.CommunityBookId);
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
                    PostStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityPost", x => x.CommunityPostId);
                });

            migrationBuilder.CreateTable(
                name: "CommunityPostComment",
                columns: table => new
                {
                    CommunityPostCommentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommunityPostId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityPostComment", x => x.CommunityPostCommentId);
                    table.ForeignKey(
                        name: "FK_CommunityPostComment_CommunityPost_CommunityPostId",
                        column: x => x.CommunityPostId,
                        principalTable: "CommunityPost",
                        principalColumn: "CommunityPostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityPostReport",
                columns: table => new
                {
                    CommunityPostReportId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommunityPostId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ComAdminId = table.Column<long>(type: "bigint", nullable: true),
                    Response = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityPostReport", x => x.CommunityPostReportId);
                    table.ForeignKey(
                        name: "FK_CommunityPostReport_CommunityPost_CommunityPostId",
                        column: x => x.CommunityPostId,
                        principalTable: "CommunityPost",
                        principalColumn: "CommunityPostId",
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
                    MultipleAnswers = table.Column<bool>(type: "boolean", nullable: false),
                    Marks = table.Column<float>(type: "real", nullable: false),
                    WriterId = table.Column<long>(type: "bigint", nullable: false),
                    ApprovedUserId = table.Column<long>(type: "bigint", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Published = table.Column<bool>(type: "boolean", nullable: false),
                    Answer01 = table.Column<string>(type: "text", nullable: false),
                    Correctness01 = table.Column<bool>(type: "boolean", nullable: false),
                    Answer02 = table.Column<string>(type: "text", nullable: false),
                    Correctness02 = table.Column<bool>(type: "boolean", nullable: false),
                    Answer03 = table.Column<string>(type: "text", nullable: false),
                    Correctness03 = table.Column<bool>(type: "boolean", nullable: false),
                    Answer04 = table.Column<string>(type: "text", nullable: false),
                    Correctness04 = table.Column<bool>(type: "boolean", nullable: false),
                    Answer05 = table.Column<string>(type: "text", nullable: true),
                    Correctness05 = table.Column<bool>(type: "boolean", nullable: true)
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
                    SubmittedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                name: "QuizUserAnswer",
                columns: table => new
                {
                    QuizId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    Select01 = table.Column<bool>(type: "boolean", nullable: false),
                    Correctness01 = table.Column<bool>(type: "boolean", nullable: false),
                    Select02 = table.Column<bool>(type: "boolean", nullable: false),
                    Correctness02 = table.Column<bool>(type: "boolean", nullable: false),
                    Select03 = table.Column<bool>(type: "boolean", nullable: false),
                    Correctness03 = table.Column<bool>(type: "boolean", nullable: false),
                    Select04 = table.Column<bool>(type: "boolean", nullable: false),
                    Correctness04 = table.Column<bool>(type: "boolean", nullable: false),
                    Select05 = table.Column<bool>(type: "boolean", nullable: true),
                    Correctness05 = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizUserAnswer", x => new { x.QuizId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_QuizUserAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizUserAnswer_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "QuizId",
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
                    ScannedImage = table.Column<long>(type: "bigint", nullable: true),
                    SelectedSerpent = table.Column<long>(type: "bigint", nullable: true),
                    AcceptFlag = table.Column<bool>(type: "boolean", nullable: false),
                    CompleteFlag = table.Column<bool>(type: "boolean", nullable: false),
                    FakeReqFlag = table.Column<bool>(type: "boolean", nullable: false),
                    Rate = table.Column<int>(type: "integer", nullable: false),
                    RatingComment = table.Column<string>(type: "text", nullable: true),
                    ServiceFeedback = table.Column<string>(type: "text", nullable: true),
                    ServiceFeedbackMedia = table.Column<string[]>(type: "text[]", nullable: true)
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
                    Accuracy = table.Column<float>(type: "real", nullable: true),
                    ActualSerpentType = table.Column<long>(type: "bigint", nullable: true),
                    PredictionSuccess = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedImage", x => x.ScannedImageId);
                    table.ForeignKey(
                        name: "FK_ScannedImage_Serpent_ActualSerpentType",
                        column: x => x.ActualSerpentType,
                        principalTable: "Serpent",
                        principalColumn: "SerpentId");
                    table.ForeignKey(
                        name: "FK_ScannedImage_Serpent_PredictedSerpentType",
                        column: x => x.PredictedSerpentType,
                        principalTable: "Serpent",
                        principalColumn: "SerpentId");
                });

            migrationBuilder.CreateTable(
                name: "ScannedImageReview",
                columns: table => new
                {
                    ScannedImageReviewId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ScannedImageId = table.Column<long>(type: "bigint", nullable: false),
                    ReviewedUserId = table.Column<long>(type: "bigint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PredictedSerpentType = table.Column<long>(type: "bigint", nullable: false),
                    ActualSerpentType = table.Column<long>(type: "bigint", nullable: true),
                    PredictionSuccess = table.Column<bool>(type: "boolean", nullable: true),
                    RequestServiceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScannedImageReview", x => x.ScannedImageReviewId);
                    table.ForeignKey(
                        name: "FK_ScannedImageReview_RequestService_RequestServiceId",
                        column: x => x.RequestServiceId,
                        principalTable: "RequestService",
                        principalColumn: "RequestServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScannedImageReview_ScannedImage_ScannedImageId",
                        column: x => x.ScannedImageId,
                        principalTable: "ScannedImage",
                        principalColumn: "ScannedImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScannedImageReview_Serpent_ActualSerpentType",
                        column: x => x.ActualSerpentType,
                        principalTable: "Serpent",
                        principalColumn: "SerpentId");
                    table.ForeignKey(
                        name: "FK_ScannedImageReview_Serpent_PredictedSerpentType",
                        column: x => x.PredictedSerpentType,
                        principalTable: "Serpent",
                        principalColumn: "SerpentId",
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
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    PositiveVote = table.Column<long>(type: "bigint", nullable: false),
                    NegativeVote = table.Column<long>(type: "bigint", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_UserDetail_SerpentInstruction_NegativeVote",
                        column: x => x.NegativeVote,
                        principalTable: "SerpentInstruction",
                        principalColumn: "SerpentInstructionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDetail_SerpentInstruction_PositiveVote",
                        column: x => x.PositiveVote,
                        principalTable: "SerpentInstruction",
                        principalColumn: "SerpentInstructionId",
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
                name: "IX_CatcherRating_CatcherId",
                table: "CatcherRating",
                column: "CatcherId");

            migrationBuilder.CreateIndex(
                name: "IX_CatcherRating_UserId",
                table: "CatcherRating",
                column: "UserId");

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
                name: "IX_CommunityArticleComment_CommunityArticleId",
                table: "CommunityArticleComment",
                column: "CommunityArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityArticleComment_UserId",
                table: "CommunityArticleComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityArticleUserDetail_UserSavedArticleCommunityArticle~",
                table: "CommunityArticleUserDetail",
                column: "UserSavedArticleCommunityArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityArticleUserDetail1_UserReactUserDetailId",
                table: "CommunityArticleUserDetail1",
                column: "UserReactUserDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityBook_UploadedUserId",
                table: "CommunityBook",
                column: "UploadedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityBookUserDetail_PurchasedBook",
                table: "CommunityBookUserDetail",
                column: "PurchasedBook");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityBookUserDetail1_SavedBook",
                table: "CommunityBookUserDetail1",
                column: "SavedBook");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPost_UserId",
                table: "CommunityPost",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPostComment_CommunityPostId",
                table: "CommunityPostComment",
                column: "CommunityPostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPostComment_UserId",
                table: "CommunityPostComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPostReport_CommunityPostId",
                table: "CommunityPostReport",
                column: "CommunityPostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPostReport_UserId",
                table: "CommunityPostReport",
                column: "UserId");

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
                name: "IX_Question_WriterId",
                table: "Question",
                column: "WriterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UserId",
                table: "Quiz",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizUserAnswer_QuestionId",
                table: "QuizUserAnswer",
                column: "QuestionId");

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
                name: "IX_ScannedImageReview_ActualSerpentType",
                table: "ScannedImageReview",
                column: "ActualSerpentType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImageReview_PredictedSerpentType",
                table: "ScannedImageReview",
                column: "PredictedSerpentType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImageReview_RequestServiceId",
                table: "ScannedImageReview",
                column: "RequestServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImageReview_ReviewedUserId",
                table: "ScannedImageReview",
                column: "ReviewedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImageReview_ScannedImageId",
                table: "ScannedImageReview",
                column: "ScannedImageId",
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

            migrationBuilder.CreateIndex(
                name: "IX_SerpentMedia_SerpentId",
                table: "SerpentMedia",
                column: "SerpentId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemReport_GeneratedUserId",
                table: "SystemReport",
                column: "GeneratedUserId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_UserDetail_CatcherId",
                table: "Catcher",
                column: "CatcherId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatcherRating_UserDetail_UserId",
                table: "CatcherRating",
                column: "UserId",
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
                name: "FK_CommunityArticleComment_UserDetail_UserId",
                table: "CommunityArticleComment",
                column: "UserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityArticleUserDetail_UserDetail_SavedArticle",
                table: "CommunityArticleUserDetail",
                column: "SavedArticle",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityArticleUserDetail1_UserDetail_UserReactUserDetailId",
                table: "CommunityArticleUserDetail1",
                column: "UserReactUserDetailId",
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
                name: "FK_CommunityBookUserDetail_UserDetail_PurchasedBook",
                table: "CommunityBookUserDetail",
                column: "PurchasedBook",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityBookUserDetail1_UserDetail_SavedBook",
                table: "CommunityBookUserDetail1",
                column: "SavedBook",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityPost_UserDetail_UserId",
                table: "CommunityPost",
                column: "UserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityPostComment_UserDetail_UserId",
                table: "CommunityPostComment",
                column: "UserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityPostReport_UserDetail_UserId",
                table: "CommunityPostReport",
                column: "UserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityPostUserDetail_UserDetail_SavedPost",
                table: "CommunityPostUserDetail",
                column: "SavedPost",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityPostUserDetail1_UserDetail_UserPostReactUserDetail~",
                table: "CommunityPostUserDetail1",
                column: "UserPostReactUserDetailId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityResearch_UserDetail_SavedResearch",
                table: "CommunityResearch",
                column: "SavedResearch",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommunityResearch_Zoologist_UserId",
                table: "CommunityResearch",
                column: "UserId",
                principalTable: "Zoologist",
                principalColumn: "ZoologistId",
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
                name: "FK_RequestService_ScannedImage_ScannedImage",
                table: "RequestService",
                column: "ScannedImage",
                principalTable: "ScannedImage",
                principalColumn: "ScannedImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestService_UserDetail_ReqUserId",
                table: "RequestService",
                column: "ReqUserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScannedImage_UserDetail_UploadedUserId",
                table: "ScannedImage",
                column: "UploadedUserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScannedImageReview_UserDetail_ReviewedUserId",
                table: "ScannedImageReview",
                column: "ReviewedUserId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SerpentInstruction_UserDetail_WittenUser",
                table: "SerpentInstruction",
                column: "WittenUser",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerpentInstruction_UserDetail_WittenUser",
                table: "SerpentInstruction");

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
                name: "CatcherRating");

            migrationBuilder.DropTable(
                name: "CommunityArticleComment");

            migrationBuilder.DropTable(
                name: "CommunityArticleUserDetail");

            migrationBuilder.DropTable(
                name: "CommunityArticleUserDetail1");

            migrationBuilder.DropTable(
                name: "CommunityBookUserDetail");

            migrationBuilder.DropTable(
                name: "CommunityBookUserDetail1");

            migrationBuilder.DropTable(
                name: "CommunityPostComment");

            migrationBuilder.DropTable(
                name: "CommunityPostReport");

            migrationBuilder.DropTable(
                name: "CommunityPostUserDetail");

            migrationBuilder.DropTable(
                name: "CommunityPostUserDetail1");

            migrationBuilder.DropTable(
                name: "CommunityResearch");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "QuizUserAnswer");

            migrationBuilder.DropTable(
                name: "RegistrationRequest");

            migrationBuilder.DropTable(
                name: "ScannedImageReview");

            migrationBuilder.DropTable(
                name: "SerpentMedia");

            migrationBuilder.DropTable(
                name: "SystemReport");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CommunityArticle");

            migrationBuilder.DropTable(
                name: "CommunityPost");

            migrationBuilder.DropTable(
                name: "Quiz");

            migrationBuilder.DropTable(
                name: "RequestService");

            migrationBuilder.DropTable(
                name: "SystemAdmin");

            migrationBuilder.DropTable(
                name: "CommunityAdmin");

            migrationBuilder.DropTable(
                name: "Catcher");

            migrationBuilder.DropTable(
                name: "ScannedImage");

            migrationBuilder.DropTable(
                name: "CommunityBook");

            migrationBuilder.DropTable(
                name: "UserDetail");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "SerpentInstruction");

            migrationBuilder.DropTable(
                name: "Zoologist");

            migrationBuilder.DropTable(
                name: "Serpent");
        }
    }
}

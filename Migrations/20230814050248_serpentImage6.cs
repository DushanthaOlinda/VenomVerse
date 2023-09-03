using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class serpentImage6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserProfilePicture",
                table: "UserDetail");

            migrationBuilder.CreateTable(
                name: "CommunityVideo",
                columns: table => new
                {
                    CommunityVideoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    VideoTitle = table.Column<string>(type: "text", nullable: false),
                    VideoDescription = table.Column<string>(type: "text", nullable: false),
                    VideoLink = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityVideo", x => x.CommunityVideoId);
                    table.ForeignKey(
                        name: "FK_CommunityVideo_UserDetail_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetail",
                        principalColumn: "UserDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommunityVideo_UserId",
                table: "CommunityVideo",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityVideo");

            migrationBuilder.AddColumn<byte[]>(
                name: "UserProfilePicture",
                table: "UserDetail",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}

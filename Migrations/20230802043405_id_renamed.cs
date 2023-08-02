using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class idrenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Zoologist",
                newName: "ZoologistId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserDetail",
                newName: "UserDetailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SystemReport",
                newName: "SystemReportId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SystemAdmin",
                newName: "SystemAdminId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Serpent",
                newName: "SerpentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ScannedImage",
                newName: "ScannedImageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RequestService",
                newName: "RequestServiceId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RegistrationRequest",
                newName: "RegistrationRequestId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Quiz",
                newName: "QuizId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Question",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notification",
                newName: "NotificationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmergencyContact",
                newName: "EmergencyContactId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CommunityPost",
                newName: "CommunityPostId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CommunityBook",
                newName: "CommunityBookId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CommunityArticle",
                newName: "CommunityArticleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CommunityAdmin",
                newName: "CommunityAdminId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Catcher",
                newName: "CatcherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZoologistId",
                table: "Zoologist",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserDetailId",
                table: "UserDetail",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SystemReportId",
                table: "SystemReport",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SystemAdminId",
                table: "SystemAdmin",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SerpentId",
                table: "Serpent",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ScannedImageId",
                table: "ScannedImage",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RequestServiceId",
                table: "RequestService",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RegistrationRequestId",
                table: "RegistrationRequest",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Quiz",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Question",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NotificationId",
                table: "Notification",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmergencyContactId",
                table: "EmergencyContact",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommunityPostId",
                table: "CommunityPost",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommunityBookId",
                table: "CommunityBook",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommunityArticleId",
                table: "CommunityArticle",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommunityAdminId",
                table: "CommunityAdmin",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CatcherId",
                table: "Catcher",
                newName: "Id");
        }
    }
}

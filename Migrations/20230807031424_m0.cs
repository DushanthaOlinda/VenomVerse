using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class m0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZoologistPrevilege",
                table: "UserDetail",
                newName: "ZoologistPrivilege");

            migrationBuilder.RenameColumn(
                name: "ExpertPrevilege",
                table: "UserDetail",
                newName: "ExpertPrivilege");

            migrationBuilder.RenameColumn(
                name: "CommunityAdminPrevilege",
                table: "UserDetail",
                newName: "CommunityAdminPrivilege");

            migrationBuilder.RenameColumn(
                name: "CatcherPrevilege",
                table: "UserDetail",
                newName: "CatcherPrivilege");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZoologistPrivilege",
                table: "UserDetail",
                newName: "ZoologistPrevilege");

            migrationBuilder.RenameColumn(
                name: "ExpertPrivilege",
                table: "UserDetail",
                newName: "ExpertPrevilege");

            migrationBuilder.RenameColumn(
                name: "CommunityAdminPrivilege",
                table: "UserDetail",
                newName: "CommunityAdminPrevilege");

            migrationBuilder.RenameColumn(
                name: "CatcherPrivilege",
                table: "UserDetail",
                newName: "CatcherPrevilege");
        }
    }
}

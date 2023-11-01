using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class updateCatcherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Catcher_UserDetail_CatcherId",
                table: "Catcher");

            migrationBuilder.DropForeignKey(
                name: "FK_CatcherRating_Catcher_CatcherId",
                table: "CatcherRating");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catcher",
                table: "Catcher");

            migrationBuilder.RenameColumn(
                name: "CatcherId",
                table: "Catcher",
                newName: "ReqCatcher");

            migrationBuilder.AddColumn<long>(
                name: "ReqId",
                table: "Catcher",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<bool>(
                name: "ApprovedStatusOne",
                table: "Catcher",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ApprovedStatusThree",
                table: "Catcher",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ApprovedStatusTwo",
                table: "Catcher",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catcher",
                table: "Catcher",
                column: "ReqId");

            migrationBuilder.CreateIndex(
                name: "IX_Catcher_ReqCatcher",
                table: "Catcher",
                column: "ReqCatcher",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdOne",
                table: "Catcher",
                column: "ApprovedPersonIdOne",
                principalTable: "Catcher",
                principalColumn: "ReqId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdThree",
                table: "Catcher",
                column: "ApprovedPersonIdThree",
                principalTable: "Catcher",
                principalColumn: "ReqId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdTwo",
                table: "Catcher",
                column: "ApprovedPersonIdTwo",
                principalTable: "Catcher",
                principalColumn: "ReqId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_UserDetail_ReqCatcher",
                table: "Catcher",
                column: "ReqCatcher",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatcherRating_Catcher_CatcherId",
                table: "CatcherRating",
                column: "CatcherId",
                principalTable: "Catcher",
                principalColumn: "ReqId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService",
                column: "CatcherId",
                principalTable: "Catcher",
                principalColumn: "ReqId");
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
                name: "FK_Catcher_UserDetail_ReqCatcher",
                table: "Catcher");

            migrationBuilder.DropForeignKey(
                name: "FK_CatcherRating_Catcher_CatcherId",
                table: "CatcherRating");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catcher",
                table: "Catcher");

            migrationBuilder.DropIndex(
                name: "IX_Catcher_ReqCatcher",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ReqId",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedStatusOne",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedStatusThree",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedStatusTwo",
                table: "Catcher");

            migrationBuilder.RenameColumn(
                name: "ReqCatcher",
                table: "Catcher",
                newName: "CatcherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catcher",
                table: "Catcher",
                column: "CatcherId");

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
                name: "FK_Catcher_UserDetail_CatcherId",
                table: "Catcher",
                column: "CatcherId",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatcherRating_Catcher_CatcherId",
                table: "CatcherRating",
                column: "CatcherId",
                principalTable: "Catcher",
                principalColumn: "CatcherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService",
                column: "CatcherId",
                principalTable: "Catcher",
                principalColumn: "CatcherId");
        }
    }
}

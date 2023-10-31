using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class oct24 : Migration
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

            migrationBuilder.AlterColumn<long>(
                name: "ReqId",
                table: "Catcher",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catcher",
                table: "Catcher",
                column: "ReqCatcher");

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdOne",
                table: "Catcher",
                column: "ApprovedPersonIdOne",
                principalTable: "Catcher",
                principalColumn: "ReqCatcher");

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdThree",
                table: "Catcher",
                column: "ApprovedPersonIdThree",
                principalTable: "Catcher",
                principalColumn: "ReqCatcher");

            migrationBuilder.AddForeignKey(
                name: "FK_Catcher_Catcher_ApprovedPersonIdTwo",
                table: "Catcher",
                column: "ApprovedPersonIdTwo",
                principalTable: "Catcher",
                principalColumn: "ReqCatcher");

            migrationBuilder.AddForeignKey(
                name: "FK_CatcherRating_Catcher_CatcherId",
                table: "CatcherRating",
                column: "CatcherId",
                principalTable: "Catcher",
                principalColumn: "ReqCatcher",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService",
                column: "CatcherId",
                principalTable: "Catcher",
                principalColumn: "ReqCatcher");
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
                name: "FK_CatcherRating_Catcher_CatcherId",
                table: "CatcherRating");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catcher",
                table: "Catcher");

            migrationBuilder.AlterColumn<long>(
                name: "ReqId",
                table: "Catcher",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

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
    }
}

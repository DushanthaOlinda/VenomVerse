using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class sep151544 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService");

            migrationBuilder.AlterColumn<long>(
                name: "CatcherId",
                table: "RequestService",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService",
                column: "CatcherId",
                principalTable: "Catcher",
                principalColumn: "CatcherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService");

            migrationBuilder.AlterColumn<long>(
                name: "CatcherId",
                table: "RequestService",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestService_Catcher_CatcherId",
                table: "RequestService",
                column: "CatcherId",
                principalTable: "Catcher",
                principalColumn: "CatcherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

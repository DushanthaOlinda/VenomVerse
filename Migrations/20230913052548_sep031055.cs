using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class sep031055 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerpentInstruction_UserDetail_WittenUser",
                table: "SerpentInstruction");

            migrationBuilder.AddForeignKey(
                name: "FK_SerpentInstruction_Zoologist_WittenUser",
                table: "SerpentInstruction",
                column: "WittenUser",
                principalTable: "Zoologist",
                principalColumn: "ZoologistId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerpentInstruction_Zoologist_WittenUser",
                table: "SerpentInstruction");

            migrationBuilder.AddForeignKey(
                name: "FK_SerpentInstruction_UserDetail_WittenUser",
                table: "SerpentInstruction",
                column: "WittenUser",
                principalTable: "UserDetail",
                principalColumn: "UserDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

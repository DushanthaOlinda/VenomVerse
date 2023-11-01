using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class sap91252 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NegativeVote",
                table: "SerpentInstruction");

            migrationBuilder.DropColumn(
                name: "PositiveVote",
                table: "SerpentInstruction");

            migrationBuilder.AlterColumn<string[]>(
                name: "SerpentMedia",
                table: "Serpent",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0],
                oldClrType: typeof(long[]),
                oldType: "bigint[]",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SerpentId",
                table: "CommunityPost",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerpentId",
                table: "CommunityPost");

            migrationBuilder.AddColumn<long[]>(
                name: "NegativeVote",
                table: "SerpentInstruction",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AddColumn<long[]>(
                name: "PositiveVote",
                table: "SerpentInstruction",
                type: "bigint[]",
                nullable: true);

            migrationBuilder.AlterColumn<long[]>(
                name: "SerpentMedia",
                table: "Serpent",
                type: "bigint[]",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "text[]");
        }
    }
}

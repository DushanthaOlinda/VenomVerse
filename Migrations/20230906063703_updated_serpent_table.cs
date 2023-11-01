using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedserpenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerpentMedia_Serpent_SerpentId",
                table: "SerpentMedia");

            migrationBuilder.DropIndex(
                name: "IX_SerpentMedia_SerpentId",
                table: "SerpentMedia");

            migrationBuilder.AddColumn<long[]>(
                name: "SerpentMedia",
                table: "Serpent",
                type: "bigint[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerpentMedia",
                table: "Serpent");

            migrationBuilder.CreateIndex(
                name: "IX_SerpentMedia_SerpentId",
                table: "SerpentMedia",
                column: "SerpentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SerpentMedia_Serpent_SerpentId",
                table: "SerpentMedia",
                column: "SerpentId",
                principalTable: "Serpent",
                principalColumn: "SerpentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

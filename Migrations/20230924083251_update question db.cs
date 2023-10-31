using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class updatequestiondb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer01Sinhala",
                table: "Question",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer02Sinhala",
                table: "Question",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer03Sinhala",
                table: "Question",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer04Sinhala",
                table: "Question",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer05Sinhala",
                table: "Question",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer01Sinhala",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Answer02Sinhala",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Answer03Sinhala",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Answer04Sinhala",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Answer05Sinhala",
                table: "Question");
        }
    }
}

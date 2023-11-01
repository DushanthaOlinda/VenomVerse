using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class ZoologistUpdate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Certificate",
                table: "Zoologist",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DegreeName",
                table: "Zoologist",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GraduatedYear",
                table: "Zoologist",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpecialDetails",
                table: "Zoologist",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "Zoologist",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certificate",
                table: "Zoologist");

            migrationBuilder.DropColumn(
                name: "DegreeName",
                table: "Zoologist");

            migrationBuilder.DropColumn(
                name: "GraduatedYear",
                table: "Zoologist");

            migrationBuilder.DropColumn(
                name: "SpecialDetails",
                table: "Zoologist");

            migrationBuilder.DropColumn(
                name: "University",
                table: "Zoologist");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedrequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestToBeCatcher");

            migrationBuilder.DropTable(
                name: "RequestToBeZoologist");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Zoologist");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Catcher");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Notification",
                newName: "Type");

            migrationBuilder.AlterColumn<string[,]>(
                name: "Certification",
                table: "Zoologist",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0],
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ApprovedDate",
                table: "Zoologist",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<long>(
                name: "ApprovedPersonId",
                table: "Zoologist",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Zoologist",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedDateTime",
                table: "Zoologist",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SpecialNote",
                table: "Zoologist",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ApprovedDateOne",
                table: "Catcher",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ApprovedDateThree",
                table: "Catcher",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ApprovedDateTwo",
                table: "Catcher",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ApprovedFlag",
                table: "Catcher",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ApprovedPersonIdOne",
                table: "Catcher",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ApprovedPersonIdThree",
                table: "Catcher",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ApprovedPersonIdTwo",
                table: "Catcher",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "CatcherEvidence",
                table: "Catcher",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Catcher",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedDateTime",
                table: "Catcher",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SpecialNote",
                table: "Catcher",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedPersonId",
                table: "Zoologist");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Zoologist");

            migrationBuilder.DropColumn(
                name: "RequestedDateTime",
                table: "Zoologist");

            migrationBuilder.DropColumn(
                name: "SpecialNote",
                table: "Zoologist");

            migrationBuilder.DropColumn(
                name: "ApprovedDateOne",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedDateThree",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedDateTwo",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedFlag",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedPersonIdOne",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedPersonIdThree",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "ApprovedPersonIdTwo",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "CatcherEvidence",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "RequestedDateTime",
                table: "Catcher");

            migrationBuilder.DropColumn(
                name: "SpecialNote",
                table: "Catcher");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Notification",
                newName: "type");

            migrationBuilder.AlterColumn<string[]>(
                name: "Certification",
                table: "Zoologist",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string[,]),
                oldType: "text[]");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ApprovedDate",
                table: "Zoologist",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RequestId",
                table: "Zoologist",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RequestId",
                table: "Catcher",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "RequestToBeCatcher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ApprovedDateOne = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedDateThree = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedDateTwo = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedPersonIdOne = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedPersonIdThree = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedPersonIdTwo = table.Column<long>(type: "bigint", nullable: true),
                    CatcherEvidence = table.Column<string[]>(type: "text[]", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    JoinedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SpecialNote = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestToBeCatcher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestToBeZoologist",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ApprovedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedPersonId = table.Column<long>(type: "bigint", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SpecialNote = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ZoologistCertification = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestToBeZoologist", x => x.Id);
                });
        }
    }
}

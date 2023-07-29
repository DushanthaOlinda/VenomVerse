using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class UserModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItem");

            migrationBuilder.DropTable(
                name: "VenomVerseItems");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "UserDetail",
                newName: "WorkingStatus");

            migrationBuilder.AddColumn<string>(
                name: "AccountStatus",
                table: "UserDetail",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserDetail",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "CatcherPrevilege",
                table: "UserDetail",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CommunityAdminPrevilege",
                table: "UserDetail",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "UserDetail",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "UserDetail",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Dob",
                table: "UserDetail",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "ExpertPrevilege",
                table: "UserDetail",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserDetail",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UserDetail",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nic",
                table: "UserDetail",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ZoologistPrevilege",
                table: "UserDetail",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountStatus",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "CatcherPrevilege",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "CommunityAdminPrevilege",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "District",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "Dob",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "ExpertPrevilege",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "Nic",
                table: "UserDetail");

            migrationBuilder.DropColumn(
                name: "ZoologistPrevilege",
                table: "UserDetail");

            migrationBuilder.RenameColumn(
                name: "WorkingStatus",
                table: "UserDetail",
                newName: "Password");

            migrationBuilder.CreateTable(
                name: "TaskItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsComplete = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VenomVerseItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IsComplete = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenomVerseItems", x => x.Id);
                });
        }
    }
}

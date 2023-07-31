using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class ZoologistModel4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catcher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Availability = table.Column<bool>(type: "boolean", nullable: false),
                    JoinedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedPersonIdOne = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDateOne = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedPersonIdTwo = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDateTwo = table.Column<DateOnly>(type: "date", nullable: true),
                    ApprovedPersonIdThree = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedDateThree = table.Column<DateOnly>(type: "date", nullable: true),
                    ChargingFee = table.Column<float>(type: "real", nullable: true),
                    CatcherRating = table.Column<string[,]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catcher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunityAdmin",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    JoinedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zoologist",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ApprovedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ApprovedPersonId = table.Column<long>(type: "bigint", nullable: false),
                    Certification = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoologist", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catcher");

            migrationBuilder.DropTable(
                name: "CommunityAdmin");

            migrationBuilder.DropTable(
                name: "Zoologist");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class serpentImage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerpentImage",
                table: "Serpent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "SerpentImage",
                table: "Serpent",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}

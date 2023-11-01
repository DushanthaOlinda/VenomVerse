using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenomVerseApi.Migrations
{
    /// <inheritdoc />
    public partial class sep30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScannedImage_Serpent_PredictedSerpentType",
                table: "ScannedImage");

            migrationBuilder.DropIndex(
                name: "IX_ScannedImage_PredictedSerpentType",
                table: "ScannedImage");

            migrationBuilder.DropIndex(
                name: "IX_ScannedImage_UploadedUserId",
                table: "ScannedImage");

            migrationBuilder.AlterColumn<long>(
                name: "PredictedSerpentType",
                table: "ScannedImage",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Accuracy",
                table: "ScannedImage",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyContactNumber",
                table: "EmergencyContact",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImage_PredictedSerpentType",
                table: "ScannedImage",
                column: "PredictedSerpentType");

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImage_UploadedUserId",
                table: "ScannedImage",
                column: "UploadedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScannedImage_Serpent_PredictedSerpentType",
                table: "ScannedImage",
                column: "PredictedSerpentType",
                principalTable: "Serpent",
                principalColumn: "SerpentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScannedImage_Serpent_PredictedSerpentType",
                table: "ScannedImage");

            migrationBuilder.DropIndex(
                name: "IX_ScannedImage_PredictedSerpentType",
                table: "ScannedImage");

            migrationBuilder.DropIndex(
                name: "IX_ScannedImage_UploadedUserId",
                table: "ScannedImage");

            migrationBuilder.AlterColumn<long>(
                name: "PredictedSerpentType",
                table: "ScannedImage",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<float>(
                name: "Accuracy",
                table: "ScannedImage",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "EmergencyContactNumber",
                table: "EmergencyContact",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImage_PredictedSerpentType",
                table: "ScannedImage",
                column: "PredictedSerpentType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScannedImage_UploadedUserId",
                table: "ScannedImage",
                column: "UploadedUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScannedImage_Serpent_PredictedSerpentType",
                table: "ScannedImage",
                column: "PredictedSerpentType",
                principalTable: "Serpent",
                principalColumn: "SerpentId");
        }
    }
}

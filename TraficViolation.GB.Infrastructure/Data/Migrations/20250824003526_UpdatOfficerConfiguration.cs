using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraficViolation.GB.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatOfficerConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BadgeNumber",
                table: "Officer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Officer_BadgeNumber",
                table: "Officer",
                column: "BadgeNumber",
                unique: true,
                filter: "[BadgeNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Officer_BadgeNumber",
                table: "Officer");

            migrationBuilder.AlterColumn<string>(
                name: "BadgeNumber",
                table: "Officer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraficViolation.GB.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOfficerTableAndMakeThierRelationBetweenAppUserAndViolations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violations_AspNetUsers_UserId",
                table: "Violations");

            migrationBuilder.DropIndex(
                name: "IX_Violations_UserId",
                table: "Violations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Violations");

            migrationBuilder.AddColumn<int>(
                name: "OfficerId",
                table: "Violations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Licensenumber",
                table: "VehicleOwners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Officer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BadgeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Officer_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Violations_OfficerId",
                table: "Violations",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_Officer_AppUserId",
                table: "Officer",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Violations_Officer_OfficerId",
                table: "Violations",
                column: "OfficerId",
                principalTable: "Officer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violations_Officer_OfficerId",
                table: "Violations");

            migrationBuilder.DropTable(
                name: "Officer");

            migrationBuilder.DropIndex(
                name: "IX_Violations_OfficerId",
                table: "Violations");

            migrationBuilder.DropColumn(
                name: "OfficerId",
                table: "Violations");

            migrationBuilder.DropColumn(
                name: "Licensenumber",
                table: "VehicleOwners");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Violations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Violations_UserId",
                table: "Violations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Violations_AspNetUsers_UserId",
                table: "Violations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

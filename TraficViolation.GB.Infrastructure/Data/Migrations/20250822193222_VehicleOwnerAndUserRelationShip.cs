using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraficViolation.GB.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleOwnerAndUserRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLog_AspNetUsers_UserId",
                table: "AuditLog");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportLog_AspNetUsers_UserId",
                table: "ReportLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Violation_AspNetUsers_UserId",
                table: "Violation");

            migrationBuilder.DropForeignKey(
                name: "FK_Violation_VehicleOwner_VehicleOwnerId",
                table: "Violation");

            migrationBuilder.DropForeignKey(
                name: "FK_Violation_ViolationType_ViolationTypeId",
                table: "Violation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ViolationType",
                table: "ViolationType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Violation",
                table: "Violation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleOwner",
                table: "VehicleOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportLog",
                table: "ReportLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditLog",
                table: "AuditLog");

            migrationBuilder.RenameTable(
                name: "ViolationType",
                newName: "ViolationTypes");

            migrationBuilder.RenameTable(
                name: "Violation",
                newName: "Violations");

            migrationBuilder.RenameTable(
                name: "VehicleOwner",
                newName: "VehicleOwners");

            migrationBuilder.RenameTable(
                name: "ReportLog",
                newName: "ReportLogs");

            migrationBuilder.RenameTable(
                name: "AuditLog",
                newName: "AuditLogs");

            migrationBuilder.RenameIndex(
                name: "IX_Violation_ViolationTypeId",
                table: "Violations",
                newName: "IX_Violations_ViolationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Violation_VehicleOwnerId",
                table: "Violations",
                newName: "IX_Violations_VehicleOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Violation_UserId",
                table: "Violations",
                newName: "IX_Violations_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportLog_UserId",
                table: "ReportLogs",
                newName: "IX_ReportLogs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditLog_UserId",
                table: "AuditLogs",
                newName: "IX_AuditLogs_UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "VehicleOwners",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ViolationTypes",
                table: "ViolationTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Violations",
                table: "Violations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleOwners",
                table: "VehicleOwners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportLogs",
                table: "ReportLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditLogs",
                table: "AuditLogs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_UserId",
                table: "VehicleOwners",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_AspNetUsers_UserId",
                table: "AuditLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportLogs_AspNetUsers_UserId",
                table: "ReportLogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleOwners_AspNetUsers_UserId",
                table: "VehicleOwners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Violations_AspNetUsers_UserId",
                table: "Violations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Violations_VehicleOwners_VehicleOwnerId",
                table: "Violations",
                column: "VehicleOwnerId",
                principalTable: "VehicleOwners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Violations_ViolationTypes_ViolationTypeId",
                table: "Violations",
                column: "ViolationTypeId",
                principalTable: "ViolationTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_AspNetUsers_UserId",
                table: "AuditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportLogs_AspNetUsers_UserId",
                table: "ReportLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleOwners_AspNetUsers_UserId",
                table: "VehicleOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Violations_AspNetUsers_UserId",
                table: "Violations");

            migrationBuilder.DropForeignKey(
                name: "FK_Violations_VehicleOwners_VehicleOwnerId",
                table: "Violations");

            migrationBuilder.DropForeignKey(
                name: "FK_Violations_ViolationTypes_ViolationTypeId",
                table: "Violations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ViolationTypes",
                table: "ViolationTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Violations",
                table: "Violations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleOwners",
                table: "VehicleOwners");

            migrationBuilder.DropIndex(
                name: "IX_VehicleOwners_UserId",
                table: "VehicleOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportLogs",
                table: "ReportLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditLogs",
                table: "AuditLogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "VehicleOwners");

            migrationBuilder.RenameTable(
                name: "ViolationTypes",
                newName: "ViolationType");

            migrationBuilder.RenameTable(
                name: "Violations",
                newName: "Violation");

            migrationBuilder.RenameTable(
                name: "VehicleOwners",
                newName: "VehicleOwner");

            migrationBuilder.RenameTable(
                name: "ReportLogs",
                newName: "ReportLog");

            migrationBuilder.RenameTable(
                name: "AuditLogs",
                newName: "AuditLog");

            migrationBuilder.RenameIndex(
                name: "IX_Violations_ViolationTypeId",
                table: "Violation",
                newName: "IX_Violation_ViolationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Violations_VehicleOwnerId",
                table: "Violation",
                newName: "IX_Violation_VehicleOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Violations_UserId",
                table: "Violation",
                newName: "IX_Violation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportLogs_UserId",
                table: "ReportLog",
                newName: "IX_ReportLog_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditLogs_UserId",
                table: "AuditLog",
                newName: "IX_AuditLog_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ViolationType",
                table: "ViolationType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Violation",
                table: "Violation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleOwner",
                table: "VehicleOwner",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportLog",
                table: "ReportLog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditLog",
                table: "AuditLog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLog_AspNetUsers_UserId",
                table: "AuditLog",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportLog_AspNetUsers_UserId",
                table: "ReportLog",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Violation_AspNetUsers_UserId",
                table: "Violation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Violation_VehicleOwner_VehicleOwnerId",
                table: "Violation",
                column: "VehicleOwnerId",
                principalTable: "VehicleOwner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Violation_ViolationType_ViolationTypeId",
                table: "Violation",
                column: "ViolationTypeId",
                principalTable: "ViolationType",
                principalColumn: "Id");
        }
    }
}

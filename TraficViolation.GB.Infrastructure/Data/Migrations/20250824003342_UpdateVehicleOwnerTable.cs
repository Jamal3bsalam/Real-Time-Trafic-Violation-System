using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraficViolation.GB.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVehicleOwnerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "VehicleOwners");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "VehicleOwners");

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "VehicleOwners",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarPlateNumber",
                table: "VehicleOwners",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_CarPlateNumber",
                table: "VehicleOwners",
                column: "CarPlateNumber",
                unique: true,
                filter: "[CarPlateNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_NationalId",
                table: "VehicleOwners",
                column: "NationalId",
                unique: true,
                filter: "[NationalId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleOwners_CarPlateNumber",
                table: "VehicleOwners");

            migrationBuilder.DropIndex(
                name: "IX_VehicleOwners_NationalId",
                table: "VehicleOwners");

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "VehicleOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarPlateNumber",
                table: "VehicleOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "VehicleOwners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "VehicleOwners",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

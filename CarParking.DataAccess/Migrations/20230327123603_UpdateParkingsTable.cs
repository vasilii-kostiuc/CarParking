using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarParking.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateParkingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Users_UserId",
                table: "Parkings");

            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Vehicles_VehicleId",
                table: "Parkings");

            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Zones_ZoneId",
                table: "Parkings");

            migrationBuilder.AlterColumn<int>(
                name: "ZoneId",
                table: "Parkings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Parkings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Parkings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Users_UserId",
                table: "Parkings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Vehicles_VehicleId",
                table: "Parkings",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Zones_ZoneId",
                table: "Parkings",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Users_UserId",
                table: "Parkings");

            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Vehicles_VehicleId",
                table: "Parkings");

            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Zones_ZoneId",
                table: "Parkings");

            migrationBuilder.AlterColumn<int>(
                name: "ZoneId",
                table: "Parkings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Parkings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Parkings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Users_UserId",
                table: "Parkings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Vehicles_VehicleId",
                table: "Parkings",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Zones_ZoneId",
                table: "Parkings",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

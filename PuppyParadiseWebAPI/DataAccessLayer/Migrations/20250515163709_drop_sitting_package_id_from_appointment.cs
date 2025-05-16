using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class drop_sitting_package_id_from_appointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentSittings_SittingPackages_SittingPackageId",
                table: "AppointmentSittings");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentSittings_SittingPackageId",
                table: "AppointmentSittings");

            migrationBuilder.DropColumn(
                name: "SittingPackageId",
                table: "AppointmentSittings");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "AppointmentTrainings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "AppointmentSittings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "AppointmentTrainings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "AppointmentSittings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SittingPackageId",
                table: "AppointmentSittings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSittings_SittingPackageId",
                table: "AppointmentSittings",
                column: "SittingPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentSittings_SittingPackages_SittingPackageId",
                table: "AppointmentSittings",
                column: "SittingPackageId",
                principalTable: "SittingPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

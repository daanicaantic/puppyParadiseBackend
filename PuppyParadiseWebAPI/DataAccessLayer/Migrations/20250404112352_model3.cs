using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class model3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Appointments_GroomingPackageId",
                table: "Appointments",
                column: "GroomingPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_GroomingPackages_GroomingPackageId",
                table: "Appointments",
                column: "GroomingPackageId",
                principalTable: "GroomingPackages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_GroomingPackages_GroomingPackageId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_GroomingPackageId",
                table: "Appointments");
        }
    }
}

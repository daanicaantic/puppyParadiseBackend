using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class model7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroomingServices_AppointmentGroomings_AppointmentGroomingId",
                table: "GroomingServices");

            migrationBuilder.DropIndex(
                name: "IX_GroomingServices_AppointmentGroomingId",
                table: "GroomingServices");

            migrationBuilder.DropColumn(
                name: "AppointmentGroomingId",
                table: "GroomingServices");

            migrationBuilder.CreateTable(
                name: "GroomingServiceAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentGroomingId = table.Column<int>(type: "int", nullable: false),
                    GroomingServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroomingServiceAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroomingServiceAppointments_AppointmentGroomings_AppointmentGroomingId",
                        column: x => x.AppointmentGroomingId,
                        principalTable: "AppointmentGroomings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroomingServiceAppointments_GroomingServices_GroomingServiceId",
                        column: x => x.GroomingServiceId,
                        principalTable: "GroomingServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroomingServiceAppointments_AppointmentGroomingId",
                table: "GroomingServiceAppointments",
                column: "AppointmentGroomingId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingServiceAppointments_GroomingServiceId",
                table: "GroomingServiceAppointments",
                column: "GroomingServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroomingServiceAppointments");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentGroomingId",
                table: "GroomingServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroomingServices_AppointmentGroomingId",
                table: "GroomingServices",
                column: "AppointmentGroomingId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroomingServices_AppointmentGroomings_AppointmentGroomingId",
                table: "GroomingServices",
                column: "AppointmentGroomingId",
                principalTable: "AppointmentGroomings",
                principalColumn: "Id");
        }
    }
}

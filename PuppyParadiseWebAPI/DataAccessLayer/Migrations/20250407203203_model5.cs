using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class model5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_GroomingPackages_GroomingPackageId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ServiceTypes_ServiceTypeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_GroomingServices_Appointments_AppointmentId",
                table: "GroomingServices");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_GroomingPackageId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ServiceTypeId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "GroomingPackageId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "GroomingServices",
                newName: "GroomingDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_GroomingServices_AppointmentId",
                table: "GroomingServices",
                newName: "IX_GroomingServices_GroomingDetailsId");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "Appointments",
                newName: "AppointmentDateTime");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DogSizeId",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DogSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinWeight = table.Column<double>(type: "float", nullable: false),
                    MaxWeight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroomingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroomingPackageId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroomingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroomingDetails_GroomingPackages_GroomingPackageId",
                        column: x => x.GroomingPackageId,
                        principalTable: "GroomingPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SittingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropoffTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SittingDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPackage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    SessionsPerWeek = table.Column<int>(type: "int", nullable: false),
                    SessionDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    PriceSmall = table.Column<double>(type: "float", nullable: false),
                    PriceMedium = table.Column<double>(type: "float", nullable: false),
                    PriceLarge = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPackage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalkingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    PickupTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkingDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingPackageId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDetails_TrainingPackage_TrainingPackageId",
                        column: x => x.TrainingPackageId,
                        principalTable: "TrainingPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    GroomingDetailsId = table.Column<int>(type: "int", nullable: false),
                    WalkingDetailsId = table.Column<int>(type: "int", nullable: false),
                    SittingDetailsId = table.Column<int>(type: "int", nullable: false),
                    TrainingDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentService_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentService_GroomingDetails_GroomingDetailsId",
                        column: x => x.GroomingDetailsId,
                        principalTable: "GroomingDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentService_ServiceTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentService_SittingDetails_SittingDetailsId",
                        column: x => x.SittingDetailsId,
                        principalTable: "SittingDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentService_TrainingDetails_TrainingDetailsId",
                        column: x => x.TrainingDetailsId,
                        principalTable: "TrainingDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentService_WalkingDetails_WalkingDetailsId",
                        column: x => x.WalkingDetailsId,
                        principalTable: "WalkingDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_DogSizeId",
                table: "Dogs",
                column: "DogSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentService_AppointmentId",
                table: "AppointmentService",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentService_GroomingDetailsId",
                table: "AppointmentService",
                column: "GroomingDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentService_SittingDetailsId",
                table: "AppointmentService",
                column: "SittingDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentService_TrainingDetailsId",
                table: "AppointmentService",
                column: "TrainingDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentService_TypeId",
                table: "AppointmentService",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentService_WalkingDetailsId",
                table: "AppointmentService",
                column: "WalkingDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingDetails_GroomingPackageId",
                table: "GroomingDetails",
                column: "GroomingPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDetails_TrainingPackageId",
                table: "TrainingDetails",
                column: "TrainingPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_DogSize_DogSizeId",
                table: "Dogs",
                column: "DogSizeId",
                principalTable: "DogSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroomingServices_GroomingDetails_GroomingDetailsId",
                table: "GroomingServices",
                column: "GroomingDetailsId",
                principalTable: "GroomingDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_DogSize_DogSizeId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_GroomingServices_GroomingDetails_GroomingDetailsId",
                table: "GroomingServices");

            migrationBuilder.DropTable(
                name: "AppointmentService");

            migrationBuilder.DropTable(
                name: "DogSize");

            migrationBuilder.DropTable(
                name: "GroomingDetails");

            migrationBuilder.DropTable(
                name: "SittingDetails");

            migrationBuilder.DropTable(
                name: "TrainingDetails");

            migrationBuilder.DropTable(
                name: "WalkingDetails");

            migrationBuilder.DropTable(
                name: "TrainingPackage");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_DogSizeId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DogSizeId",
                table: "Dogs");

            migrationBuilder.RenameColumn(
                name: "GroomingDetailsId",
                table: "GroomingServices",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_GroomingServices_GroomingDetailsId",
                table: "GroomingServices",
                newName: "IX_GroomingServices_AppointmentId");

            migrationBuilder.RenameColumn(
                name: "AppointmentDateTime",
                table: "Appointments",
                newName: "AppointmentDate");

            migrationBuilder.AddColumn<int>(
                name: "GroomingPackageId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_GroomingPackageId",
                table: "Appointments",
                column: "GroomingPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceTypeId",
                table: "Appointments",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_GroomingPackages_GroomingPackageId",
                table: "Appointments",
                column: "GroomingPackageId",
                principalTable: "GroomingPackages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ServiceTypes_ServiceTypeId",
                table: "Appointments",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroomingServices_Appointments_AppointmentId",
                table: "GroomingServices",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }
    }
}

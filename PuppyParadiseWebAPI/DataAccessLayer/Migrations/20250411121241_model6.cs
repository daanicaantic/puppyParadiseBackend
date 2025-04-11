using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class model6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "GroomingPackageServices");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "GroomingDetails");

            migrationBuilder.DropTable(
                name: "SittingDetails");

            migrationBuilder.DropTable(
                name: "TrainingDetails");

            migrationBuilder.DropTable(
                name: "WalkingDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPackage",
                table: "TrainingPackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DogSize",
                table: "DogSize");

            migrationBuilder.DropColumn(
                name: "LargeDogPrice",
                table: "GroomingPackages");

            migrationBuilder.DropColumn(
                name: "MediumDogPrice",
                table: "GroomingPackages");

            migrationBuilder.DropColumn(
                name: "PriceLarge",
                table: "TrainingPackage");

            migrationBuilder.DropColumn(
                name: "PriceMedium",
                table: "TrainingPackage");

            migrationBuilder.RenameTable(
                name: "TrainingPackage",
                newName: "TrainingPackages");

            migrationBuilder.RenameTable(
                name: "DogSize",
                newName: "DogSizes");

            migrationBuilder.RenameColumn(
                name: "GroomingDetailsId",
                table: "GroomingServices",
                newName: "AppointmentGroomingId");

            migrationBuilder.RenameIndex(
                name: "IX_GroomingServices_GroomingDetailsId",
                table: "GroomingServices",
                newName: "IX_GroomingServices_AppointmentGroomingId");

            migrationBuilder.RenameColumn(
                name: "SmallDogPrice",
                table: "GroomingPackages",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "PriceSmall",
                table: "TrainingPackages",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "TrainingPackages",
                newName: "DurationInWeeks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPackages",
                table: "TrainingPackages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DogSizes",
                table: "DogSizes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppointmentGroomings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AppointmentTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    GroomingPackageId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentGroomings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentGroomings_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentGroomings_GroomingPackages_GroomingPackageId",
                        column: x => x.GroomingPackageId,
                        principalTable: "GroomingPackages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentGroomings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppointmentTrainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TrainingPackageId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentTrainings_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentTrainings_TrainingPackages_TrainingPackageId",
                        column: x => x.TrainingPackageId,
                        principalTable: "TrainingPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentTrainings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SittingPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SittingPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalkingPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkingPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentSittings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DropoffDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DropoffTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    PickupDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PickupTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    SittingPackageId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSittings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentSittings_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentSittings_SittingPackages_SittingPackageId",
                        column: x => x.SittingPackageId,
                        principalTable: "SittingPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentSittings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppointmentWalkings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PickupDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PickupTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    PickupAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalkingPackageId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentWalkings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentWalkings_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentWalkings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppointmentWalkings_WalkingPackages_WalkingPackageId",
                        column: x => x.WalkingPackageId,
                        principalTable: "WalkingPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DogSizes",
                columns: new[] { "Id", "MaxWeight", "MinWeight", "Name" },
                values: new object[,]
                {
                    { 1, 10.0, 0.0, "Small" },
                    { 2, 25.0, 10.1, "Medium" },
                    { 3, 50.0, 25.100000000000001, "Large" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentGroomings_DogId",
                table: "AppointmentGroomings",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentGroomings_GroomingPackageId",
                table: "AppointmentGroomings",
                column: "GroomingPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentGroomings_UserId",
                table: "AppointmentGroomings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSittings_DogId",
                table: "AppointmentSittings",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSittings_SittingPackageId",
                table: "AppointmentSittings",
                column: "SittingPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSittings_UserId",
                table: "AppointmentSittings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTrainings_DogId",
                table: "AppointmentTrainings",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTrainings_TrainingPackageId",
                table: "AppointmentTrainings",
                column: "TrainingPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTrainings_UserId",
                table: "AppointmentTrainings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentWalkings_DogId",
                table: "AppointmentWalkings",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentWalkings_UserId",
                table: "AppointmentWalkings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentWalkings_WalkingPackageId",
                table: "AppointmentWalkings",
                column: "WalkingPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_DogSizes_DogSizeId",
                table: "Dogs",
                column: "DogSizeId",
                principalTable: "DogSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroomingServices_AppointmentGroomings_AppointmentGroomingId",
                table: "GroomingServices",
                column: "AppointmentGroomingId",
                principalTable: "AppointmentGroomings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_DogSizes_DogSizeId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_GroomingServices_AppointmentGroomings_AppointmentGroomingId",
                table: "GroomingServices");

            migrationBuilder.DropTable(
                name: "AppointmentGroomings");

            migrationBuilder.DropTable(
                name: "AppointmentSittings");

            migrationBuilder.DropTable(
                name: "AppointmentTrainings");

            migrationBuilder.DropTable(
                name: "AppointmentWalkings");

            migrationBuilder.DropTable(
                name: "SittingPackages");

            migrationBuilder.DropTable(
                name: "WalkingPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingPackages",
                table: "TrainingPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DogSizes",
                table: "DogSizes");

            migrationBuilder.DeleteData(
                table: "DogSizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DogSizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DogSizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "TrainingPackages",
                newName: "TrainingPackage");

            migrationBuilder.RenameTable(
                name: "DogSizes",
                newName: "DogSize");

            migrationBuilder.RenameColumn(
                name: "AppointmentGroomingId",
                table: "GroomingServices",
                newName: "GroomingDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_GroomingServices_AppointmentGroomingId",
                table: "GroomingServices",
                newName: "IX_GroomingServices_GroomingDetailsId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "GroomingPackages",
                newName: "SmallDogPrice");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "TrainingPackage",
                newName: "PriceSmall");

            migrationBuilder.RenameColumn(
                name: "DurationInWeeks",
                table: "TrainingPackage",
                newName: "Duration");

            migrationBuilder.AddColumn<double>(
                name: "LargeDogPrice",
                table: "GroomingPackages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MediumDogPrice",
                table: "GroomingPackages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceLarge",
                table: "TrainingPackage",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceMedium",
                table: "TrainingPackage",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingPackage",
                table: "TrainingPackage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DogSize",
                table: "DogSize",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "GroomingPackageServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroomingPackageId = table.Column<int>(type: "int", nullable: false),
                    GroomingServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroomingPackageServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroomingPackageServices_GroomingPackages_GroomingPackageId",
                        column: x => x.GroomingPackageId,
                        principalTable: "GroomingPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroomingPackageServices_GroomingServices_GroomingServiceId",
                        column: x => x.GroomingServiceId,
                        principalTable: "GroomingServices",
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
                name: "WalkingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    PickupAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ReturnAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkingDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    GroomingDetailsId = table.Column<int>(type: "int", nullable: false),
                    SittingDetailsId = table.Column<int>(type: "int", nullable: false),
                    TrainingDetailsId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    WalkingDetailsId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Appointments_DogId",
                table: "Appointments",
                column: "DogId");

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
                name: "IX_GroomingPackageServices_GroomingPackageId",
                table: "GroomingPackageServices",
                column: "GroomingPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_GroomingPackageServices_GroomingServiceId",
                table: "GroomingPackageServices",
                column: "GroomingServiceId");

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
    }
}

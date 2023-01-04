using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e7la2ly_Api.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    brandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brandName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    numBranches = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.brandID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    locId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    zone = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.locId);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    branchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branchName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    opiningTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    closeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    locationId = table.Column<int>(type: "int", nullable: false),
                    brandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.branchId);
                    table.ForeignKey(
                        name: "FK_Branches_Brands_brandId",
                        column: x => x.brandId,
                        principalTable: "Brands",
                        principalColumn: "brandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branches_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "locId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    locationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "locId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    nationalId = table.Column<int>(type: "int", maxLength: 14, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    branchId = table.Column<int>(type: "int", nullable: false),
                    locId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.empid);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_branchId",
                        column: x => x.branchId,
                        principalTable: "Branches",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Locations_locId",
                        column: x => x.locId,
                        principalTable: "Locations",
                        principalColumn: "locId");
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    shiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shiftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    branchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.shiftId);
                    table.ForeignKey(
                        name: "FK_Shifts_Branches_branchId",
                        column: x => x.branchId,
                        principalTable: "Branches",
                        principalColumn: "branchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpWorkings",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false),
                    from = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpWorkings", x => new { x.empid, x.from, x.To });
                    table.ForeignKey(
                        name: "FK_EmpWorkings_Clients_clientId",
                        column: x => x.clientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                });

            migrationBuilder.CreateTable(
                name: "EmpShifts",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false),
                    shiftDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    shiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpShifts", x => new { x.empid, x.shiftDate });
                    table.ForeignKey(
                        name: "FK_EmpShifts_Shifts_shiftId",
                        column: x => x.shiftId,
                        principalTable: "Shifts",
                        principalColumn: "shiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_brandId",
                table: "Branches",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_locationId",
                table: "Branches",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_locationId",
                table: "Clients",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_branchId",
                table: "Employees",
                column: "branchId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_locId",
                table: "Employees",
                column: "locId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpShifts_shiftId",
                table: "EmpShifts",
                column: "shiftId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpWorkings_clientId",
                table: "EmpWorkings",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_branchId",
                table: "Shifts",
                column: "branchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmpShifts");

            migrationBuilder.DropTable(
                name: "EmpWorkings");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNCMaintenanceAutomation.Data.Migrations
{
    public partial class AddMaintenanceServiceCardMaintenanceServiceGeneralMaintenanceServiceDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceServiceCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<int>(nullable: false),
                    MaintenanceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceServiceCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceServiceCards_CncMachines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "CncMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceServiceCards_MaintenanceTypes_MaintenanceTypeId",
                        column: x => x.MaintenanceTypeId,
                        principalTable: "MaintenanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceServiceGenerals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineOperationTime = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    MachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceServiceGenerals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceServiceGenerals_CncMachines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "CncMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceServiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceServiceGeneralId = table.Column<int>(nullable: false),
                    MaintenanceServieGeneralId = table.Column<int>(nullable: true),
                    MaintenanceTypeId = table.Column<int>(nullable: false),
                    MaintenanceId = table.Column<int>(nullable: true),
                    MaintenancePrice = table.Column<double>(nullable: false),
                    MaintenanceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceServiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceServiceDetails_MaintenanceTypes_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "MaintenanceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceServiceDetails_MaintenanceServiceGenerals_MaintenanceServieGeneralId",
                        column: x => x.MaintenanceServieGeneralId,
                        principalTable: "MaintenanceServiceGenerals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceCards_MachineId",
                table: "MaintenanceServiceCards",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceCards_MaintenanceTypeId",
                table: "MaintenanceServiceCards",
                column: "MaintenanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceDetails_MaintenanceId",
                table: "MaintenanceServiceDetails",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceDetails_MaintenanceServieGeneralId",
                table: "MaintenanceServiceDetails",
                column: "MaintenanceServieGeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServiceGenerals_MachineId",
                table: "MaintenanceServiceGenerals",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceServiceCards");

            migrationBuilder.DropTable(
                name: "MaintenanceServiceDetails");

            migrationBuilder.DropTable(
                name: "MaintenanceServiceGenerals");
        }
    }
}
